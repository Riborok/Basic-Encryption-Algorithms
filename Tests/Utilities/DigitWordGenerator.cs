using System;
using System.Collections.Generic;

namespace Tests.Utilities
{
    public static class DigitWordGenerator
    {
        private static readonly Random Random = new Random();
        
        public static IReadOnlyCollection<string> GenerateWords(int count, int maxValue)
        {
            var keys = new string[count];
            for (int i = 0; i < count; i++)
                keys[i] = GenerateWord(maxValue);
            
            return keys;
        }
        
        public static string GenerateWord(int maxValue)
        {
            return Random.Next(maxValue + 1).ToString();
        }
    }
}