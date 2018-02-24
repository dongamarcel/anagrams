using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramConsole
{
    public class AnagramsTextFile : IIndexable
    {
        private string[] lines;
        private IDictionary<int, string> indexedList;

        public AnagramsTextFile(string[] lines)
        {
            this.lines = lines;
            this.indexedList = new Dictionary<int, string>();
        }

        public IDictionary<int, string> GetIndexed()
        {
            if (indexedList.Count.Equals(0))
            {
                indexedList = new Dictionary<int, string>();
                for (int i = 0; i < this.lines.Count(); i++)
                {
                    indexedList.Add(i, SortLetters(lines[i]));
                }
            }

            return indexedList;
        }

        public string[] GetUnmodifiedList()
        {
            return this.lines;
        }

        public IOrderedEnumerable<KeyValuePair<int, string>> GetSortedList()
        {
            return this.GetIndexed()
                       .GroupBy(sv => sv.Value)
                       .SelectMany(sm => sm)
                       .OrderBy(o => o.Value);
        }

        private string SortLetters(string word)
        {
            var arr = word.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }
    }
}
