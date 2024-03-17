using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption
{
    public class Alphabet : IEnumerable<char>
    {
        private readonly string _sequence;
        private readonly Dictionary<char, int> _dictionary = new Dictionary<char, int>();
        private readonly char? _delimiter;

        public Alphabet(Alphabet alphabet, char delimiter)
        {
            _sequence = alphabet._sequence;
            _dictionary = alphabet._dictionary;
            _delimiter = delimiter;
        }
        
        public Alphabet(string sequence, char? delimiter = null)
        {
            _delimiter = delimiter;
            _sequence = sequence.ToUpper();
            FillDictionary();
        }

        private void FillDictionary()
        {
            for (int i = 0; i < _sequence.Length; i++)
                _dictionary[_sequence[i]] = i;
        }
        
        public IEnumerator<char> GetEnumerator() => _sequence.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string RemoveNonAlphabetic(string s)
        {
            return new string(s.Where(Contains).ToArray());
        }

        /// <exception cref="ArgumentException">Thrown when the letter is not in the alphabet.</exception>
        public char MultiplyLetter(char letter, int number) {
            int newIndex = GetIndex(letter) * number % Size;
            return GetLetter(newIndex < 0 ? newIndex + Size : newIndex);
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
            c = char.ToUpper(c);
            if (!Contains(c))
                throw new ArgumentException($"{nameof(Alphabet)} {this}: Letter '{c}' is not in the alphabet.");

            return _dictionary[c];
        }
        
        public bool Contains(char c)
        {
            c = char.ToUpper(c);
            return IsLetter(c) || IsDelimiter(c);
        }

        private bool IsLetter(char c) => _dictionary.ContainsKey(c);
        
        private bool IsDelimiter(char c) => c == _delimiter;

        /// <exception cref="ArgumentException">Thrown when the index is out of range.</exception>
        public char GetLetter(int index)
        {
            if (IsIndexOutOfRange(index))
                throw new ArgumentException($"{nameof(Alphabet)} {this}: Index '{index}' is out of range.");
            
            return _sequence[index];
        }
        
        private bool IsIndexOutOfRange(int index) => index < 0 || index >= Size;

        public override string ToString() => _sequence;

        public int Size => _sequence.Length;
    }
}
