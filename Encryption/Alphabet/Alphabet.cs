using System;
using System.Linq;

namespace Encryption.Alphabet
{
    public class Alphabet
    {
        private readonly char _startLetter;
        private readonly char _endLetter;

        public Alphabet(char startLetter, char endLetter)
        {
            _startLetter = char.ToUpper(startLetter);
            _endLetter = char.ToUpper(endLetter);
        }

        public bool Contains(char c)
        {
            char toLowerBound = char.ToLower(_startLetter);
            char toUpperBound = char.ToUpper(_endLetter);

            return (c >= toLowerBound && c <= toUpperBound) || (c >= _startLetter && c <= _endLetter);
        }
        
        public string RemoveNonAlphabetic(string s)
        {
            return new string(s.Where(Contains).ToArray());
        }
        
        public int GetLetterIndex(char c)
        {
            if (!Contains(c))
                throw new ArgumentException("Character is not in the alphabet.");

            return char.ToUpper(c) - _startLetter;
        }
    }
}