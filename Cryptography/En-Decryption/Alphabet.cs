using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption
{
    public class Alphabet : IEnumerable<char>
    {
        private readonly char _startUpperLetter;
        private readonly char _endUpperLetter;
        private readonly char? _delimiter;

        public Alphabet(Alphabet alphabet) : 
            this(alphabet._startUpperLetter, alphabet._endUpperLetter, alphabet._delimiter) {  }
        
        public Alphabet(Alphabet alphabet, char delimiter) 
            : this(alphabet._startUpperLetter, alphabet._endUpperLetter)
        {
            _delimiter = delimiter;
        }
        
        public Alphabet(char startLetter, char endLetter, char? delimiter = null)
        {
            _startUpperLetter = char.ToUpper(startLetter);
            _endUpperLetter = char.ToUpper(endLetter);
            _delimiter = delimiter;
        }
        
        public IEnumerator<char> GetEnumerator()
        {
            for (char c = _startUpperLetter; c <= _endUpperLetter; c++)
                yield return c;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string RemoveNonAlphabetic(string s)
        {
            return new string(s.Where(Contains).ToArray());
        }

        /// <exception cref="ArgumentException">Thrown when the letter is not in the alphabet.</exception>
        public char MultiplyLetter(char letter, int number) {
            return GetLetter(GetIndex(letter) * number % Size);
        }
        
        /// <exception cref="ArgumentException">Thrown when either c1 or c2 is not in the alphabet.</exception>
        public char SubtractLetters(char minuendLetter, char subtrahendLetter)
        {
            return ShiftLetter(minuendLetter, -GetIndex(subtrahendLetter));
        }
        
        /// <exception cref="ArgumentException">Thrown when either c1 or c2 is not in the alphabet.</exception>
        public char AddLetters(char baseLetter, char addedLetter)
        {
            return ShiftLetter(baseLetter, GetIndex(addedLetter));
        }

        /// <exception cref="ArgumentException">Thrown when the letter is not in the alphabet.</exception>
        public char ShiftLetter(char letter, int shift)
        {
            int shiftedIndex = (GetIndex(letter) + shift) % Size;
            int positiveIndex = shiftedIndex >= 0 ? shiftedIndex : shiftedIndex + Size;
            return GetLetter(positiveIndex);
        }

        /// <exception cref="ArgumentException">Thrown when the character is not in the alphabet.</exception>
        public int GetIndex(char c)
        {
            if (!Contains(c))
                throw new ArgumentException($"{nameof(Alphabet)} {this}: Letter '{c}' is not in the alphabet.");

            return char.ToUpper(c) - _startUpperLetter;
        }
        
        public bool Contains(char c)
        {
            c = char.ToUpper(c);
            return IsLetter(c) || IsDelimiter(c);
        }

        private bool IsLetter(char c) => c >= _startUpperLetter && c <= _endUpperLetter;
        
        private bool IsDelimiter(char c) => c == _delimiter;

        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
        public char GetLetter(int index)
        {
            if (IsIndexOutOfRange(index))
                throw new ArgumentOutOfRangeException($"{nameof(Alphabet)} {this}: Index '{index}' is out of range.");
            
            return (char)(_startUpperLetter + index);
        }
        
        private bool IsIndexOutOfRange(int index)
        {
            return index < 0 || index >= Size;
        }

        public override string ToString()
        {
            return $"{_startUpperLetter}..{_endUpperLetter}";
        }

        public int Size => _endUpperLetter - _startUpperLetter + 1;
    }
}
