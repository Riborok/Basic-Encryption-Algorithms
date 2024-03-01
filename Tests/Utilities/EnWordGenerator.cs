using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Cryptography.En_Decryption;

namespace Tests.Utilities
{
    public static class EnWordGenerator
    {
        private const string Url = "https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt";
        
        private static readonly Random Random = new Random();
        private static readonly string[] Words = LoadWords();

        private static string[] LoadWords()
        {
            string wordsData;
            using (WebClient webClient = new WebClient())
                wordsData = webClient.DownloadString(Url);
            return wordsData
                .Split('\n')
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