using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cryptography.En_Decryption;

namespace Tests.Utilities
{
    public static class EnWordGenerator
    {
        private static readonly Random Random = new Random();
        private static readonly string[] Words;

        static EnWordGenerator()
        {
            Words = File.ReadAllLines(@"..\..\Utilities\words_alpha.txt")
                .Select(s => Alphabets.EnAlphabet.RemoveNonAlphabetic(s))
                .ToArray();
        }

        public static string GenerateWord()
        {
            return Words[Random.Next(Words.Length)];
        }

        public static IReadOnlyCollection<string> GenerateWords(int count)
        {
            var words = new string[count];
            for (int i = 0; i < count; i++)
                words[i] = GenerateWord();
            return words;
        }
    }
}