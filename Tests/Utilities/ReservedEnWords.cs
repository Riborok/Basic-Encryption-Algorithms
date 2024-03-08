using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cryptography.En_Decryption;

namespace Tests.Utilities
{
    public static class ReservedEnWords
    {
        private static readonly string[] Words;
        
        static ReservedEnWords()
        {
            Words = File.ReadAllLines(@"..\..\Utilities\reserved_en_words.txt")
                .OrderBy(w => w.Length)
                .Select(s => Alphabets.EnAlphabet.RemoveNonAlphabetic(s))
                .ToArray();
            
            AllWordsAsString = string.Join("", Words);
        }

        public static IReadOnlyCollection<string> GetLongestKeys(int count)
        {
            return count >= Words.Length ? Words : Words.Skip(Words.Length - count).ToArray();
        }

        public static IReadOnlyCollection<string> GetShortestKeys(int count)
        {
            return count >= Words.Length ? Words : Words.Take(count).ToArray();
        }
        
        public static string LongestWord => Words[Words.Length - 1];

        public static string ShortestWord => Words[0];
        
        public static string AllWordsAsString { get; }
    }
}