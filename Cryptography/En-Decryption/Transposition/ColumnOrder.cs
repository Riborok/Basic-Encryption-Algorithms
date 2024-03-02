using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption.Transposition
{
    internal static class ColumnOrder
    {
        public static IEnumerable<int> Create(string keyword)
        {
            var sortedIndexMap = CreateSortedIndexMap(keyword);
            return FlattenSortedIndexMap(sortedIndexMap);
        }

        private static IEnumerable<int> FlattenSortedIndexMap(SortedDictionary<char, List<int>> sortedIndexMap)
        {
            return sortedIndexMap.SelectMany(pair => pair.Value);
        }
        
        private static SortedDictionary<char, List<int>> CreateSortedIndexMap(string keyword)
        {
            var sortedIndexMap = new SortedDictionary<char, List<int>>();

            for (int i = 0; i < keyword.Length; i++)
            {
                char c = keyword[i];
                if (!sortedIndexMap.ContainsKey(c))
                    sortedIndexMap[c] = new List<int>();

                sortedIndexMap[c].Add(i);
            }

            return sortedIndexMap;
        }
    }
}