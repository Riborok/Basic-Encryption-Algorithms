using System;
using System.Linq;

namespace Cryptography.En_Decryption
{
    public class Alphabet
    {
        private readonly char _startUpperLetter;
        private readonly char _endUpperLetter;
        private readonly char _delimiter;

        public Alphabet(char startLetter, char endLetter, char delimiter)
        {
            _startUpperLetter = char.ToUpper(startLetter);
            _endUpperLetter = char.ToUpper(endLetter);
            _delimiter = delimiter;
        }
        
        /// <exception cref="ArgumentException">Thrown when either c1 or c2 is not in the alphabet.</exception>
        public char SubtractLetters(char c1, char c2)
        {
            int differenceIndex = (GetIndex(c1) - GetIndex(c2) + GetSize()) % GetSize();
            return GetLetter(differenceIndex);
        }
        
        /// <exception cref="ArgumentException">Thrown when either c1 or c2 is not in the alphabet.</exception>
        public char AddLetters(char c1, char c2)
        {
            int sumIndex = (GetIndex(c1) + GetIndex(c2)) % GetSize();
            return GetLetter(sumIndex);
        }

        public bool Contains(char c)
        {
            c = char.ToUpper(c);
            return IsLetter(c) || IsDelimiter(c);
        }

        private bool IsLetter(char c)
        {
            return c >= _startUpperLetter && c <= _endUpperLetter;
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
        
        /// <exception cref="ArgumentException">Thrown when the character is not in the alphabet.</exception>
        public int GetIndex(char c)
        {
            if (!Contains(c))
                throw new ArgumentException($"Alphabet: Letter '{c}' is not in the alphabet.");

            return char.ToUpper(c) - _startUpperLetter;
        }
        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
        public char GetLetter(int index)
        {
            if (IsIndexOutOfRange(index))
                throw new ArgumentOutOfRangeException(nameof(index), $@"Alphabet: Index '{index}' is out of range.");
            
            return (char)(_startUpperLetter + index);
        }
        
        private bool IsIndexOutOfRange(int index)
        {
            return index < 0 || index > _endUpperLetter - _startUpperLetter;
        }
        
        public int GetSize()
        {
            return _endUpperLetter - _startUpperLetter + 1;
        }
    }
}