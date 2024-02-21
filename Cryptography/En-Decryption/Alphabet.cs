using System;

namespace Cryptography.En_Decryption
{
    public class Alphabet
    {
        private readonly char _startUpperLetter;
        private readonly char _endUpperLetter;

        public Alphabet(char startLetter, char endLetter)
        {
            _startUpperLetter = char.ToUpper(startLetter);
            _endUpperLetter = char.ToUpper(endLetter);
        }

        public bool Contains(char c)
        {
            c = char.ToUpper(c);
            return IsLetter(c);
        }

        private bool IsLetter(char c)
        {
            return c >= _startUpperLetter && c <= _endUpperLetter;
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
        private int GetIndex(char c)
        {
            if (!Contains(c))
                throw new ArgumentException($"Alphabet {_startUpperLetter}..{_endUpperLetter}:: Letter '{c}' is not in the alphabet.");

            return char.ToUpper(c) - _startUpperLetter;
        }
        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
        private char GetLetter(int index)
        {
            if (IsIndexOutOfRange(index))
                throw new ArgumentOutOfRangeException(nameof(index), $@"Alphabet {_startUpperLetter}..{_endUpperLetter}:: Index '{index}' is out of range.");
            
            return (char)(_startUpperLetter + index);
        }
        
        private bool IsIndexOutOfRange(int index)
        {
            return index < 0 || index >= Size;
        }
        
        // There is also delimiter in the alphabet
        public int Size => _endUpperLetter - _startUpperLetter + 1;
    }
}
