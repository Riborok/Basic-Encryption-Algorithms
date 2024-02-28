using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption
{
    public class TranspositionCipher : Cipher
    {
        public TranspositionCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet)
        {
        }

        protected override string Encrypt(string plaintext, string keyword)
        {
            var (transpositionTableFiller, textGenerator) = TranspositionCipherTools.Create(plaintext.Length, keyword.Length);
            
            transpositionTableFiller.FillWithPlaintext(plaintext);
            return textGenerator.GenerateCiphertext(ColumnOrder.Create(keyword));
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var (transpositionTableFiller, textGenerator) = TranspositionCipherTools.Create(ciphertext.Length, keyword.Length);
            
            transpositionTableFiller.FillWithCiphertext(ciphertext, ColumnOrder.Create(keyword));
            return textGenerator.GeneratePlaintext();
        }
    }
    
    internal static class TranspositionCipherTools
    {
        public static (TranspositionTableFiller filler, TextGenerator generator) Create(int textLength, int keywordLength)
        {
            var table = new TranspositionTable(textLength, keywordLength);
            var filler = new TranspositionTableFiller(table);
            var generator = new TextGenerator(table);

            return (filler, generator);
        }
    }

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