using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramConsole
{
    public class AnagramController
    {
        IIndexable indexedInput;
        
        public AnagramController(IIndexable indexedInput)
        {
            this.indexedInput = indexedInput;
        }
        
        public string GetAnagrams()
        {
            var groupedAnagrams = this.GetGroupedAnagrams();

            var maxAnagramsAmount = groupedAnagrams.Max(a => a.Count());
            var maxWordSize = this.indexedInput.GetIndexed().Max(mws => mws.Value.Length);

            var outputAnagrams = new StringBuilder();
            var longestAnagrams = new StringBuilder();
            var bigAnagramsSeq = new StringBuilder();

            foreach (var anagramList in groupedAnagrams)
            {
                var isBigAnagram = anagramList.Count().Equals(maxAnagramsAmount);
                foreach (var anagram in anagramList)
                {
                    if (anagram.Length.Equals(maxWordSize))
                    {
                        longestAnagrams.Append(anagram).Append(" ");
                    }

                    if (isBigAnagram)
                    {
                        bigAnagramsSeq.Append(anagram).Append(" ");
                    }

                    outputAnagrams.Append(anagram).Append(" ");
                }
                outputAnagrams.AppendLine();
            }

            return outputAnagrams.AppendLine()
                 .AppendLine("Printing anagrams with more words: ")
                 .AppendLine(bigAnagramsSeq.ToString())
                 .AppendLine()
                 .AppendLine("Printing biggest words that are anagrams: ")
                 .AppendLine(longestAnagrams.ToString())
                 .AppendLine().ToString();
        }

        protected IList<IList<string>> GetGroupedAnagrams()
        {
            var lastValue = string.Empty;
            var groupedAnagrams = new List<IList<string>>();
            IList<string> tempAnagramsList = new List<string>();

            foreach (var word in indexedInput.GetSortedList())
            {
                if (!lastValue.Equals(word.Value) && !lastValue.Equals(string.Empty))
                {
                    groupedAnagrams.Add(tempAnagramsList);
                    tempAnagramsList = new List<string>();
                }

                tempAnagramsList.Add(indexedInput.GetUnmodifiedList()[word.Key]);
                lastValue = word.Value;
            }

            if(tempAnagramsList.Count > 1)
            {
                groupedAnagrams.Add(tempAnagramsList);
            }

            return groupedAnagrams;
        }
    }
}
