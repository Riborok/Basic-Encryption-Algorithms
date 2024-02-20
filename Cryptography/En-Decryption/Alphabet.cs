using System;
using System.Linq;

namespace Cryptography.En_Decryption
{
    public class Alphabet
    {
        private readonly char _startLetter;
        private readonly char _endLetter;
        private readonly char _delimiter;

        public Alphabet(char startLetter, char endLetter, char delimiter)
        {
            _startLetter = char.ToUpper(startLetter);
            _endLetter = char.ToUpper(endLetter);
            _delimiter = delimiter;
        }

        public bool Contains(char c)
        {
            return IsInUpperBound(c) || IsInLowerBound(c) || IsDelimiter(c);
        }

        private bool IsInLowerBound(char c)
        {
            return c >= char.ToLower(_startLetter) && c <= char.ToUpper(_endLetter);
        }

        private bool IsInUpperBound(char c)
        {
            return c >= _startLetter && c <= _endLetter;
        }

        private bool IsDelimiter(char c)
        {
            return c == _delimiter;
        }
        
        public string RemoveNonAlphabetic(string s)
        {
            return new string(s.Where(Contains).ToArray());
        }
        
        public int CountAlphabeticLetters(string s)
        {
            return s.Count(Contains);
        }
        
        public int GetIndex(char c)
        {
            if (!Contains(c))
                throw new ArgumentException("Alphabet: Letter is not in the alphabet.");

            return char.ToUpper(c) - _startLetter;
        }
        
        public char GetLetter(int index)
        {
            if (IsIndexOutOfRange(index))
                throw new ArgumentOutOfRangeException(nameof(index), @"Alphabet: Index is out of range.");

            return (char)(_startLetter + index);
        }
        
        private bool IsIndexOutOfRange(int index)
        {
            return index < 0 || index > _endLetter - _startLetter;
        }
        
        public int GetSize()
        {
            return _endLetter - _startLetter + 1;
        }
    }
}