using System.Collections.Generic;
using System.Linq;

namespace AnagramConsole
{
    public interface IIndexable
    {
        IDictionary<int, string> GetIndexed();
        IOrderedEnumerable<KeyValuePair<int, string>> GetSortedList();
        string[] GetUnmodifiedList();
    }
}
