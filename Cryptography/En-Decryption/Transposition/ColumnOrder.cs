using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption.Transposition
{
    internal static class ColumnOrder
    {
        public static IEnumerable<int> Create(string keyword, Alphabet alphabet)
        {
            var sortedIndexMap = CreateSortedIndexMap(keyword, alphabet);
            return FlattenSortedIndexMap(sortedIndexMap);
        }

        private static IEnumerable<int> FlattenSortedIndexMap(SortedDictionary<char, List<int>> sortedIndexMap)
        {
            return sortedIndexMap.SelectMany(pair => pair.Value);
        }
        
        private static SortedDictionary<char, List<int>> CreateSortedIndexMap(string keyword, Alphabet alphabet)
        {
            var sortedIndexMap = new SortedDictionary<char, List<int>>(Comparer<char>.Create((x, y) =>
            {
                int indexX = alphabet.GetIndex(x);
                int indexY = alphabet.GetIndex(y);
                return indexX.CompareTo(indexY);
            }));
            
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