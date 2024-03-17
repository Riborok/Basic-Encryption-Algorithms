using Cryptography.Extensions;

namespace Cryptography.En_Decryption.Playfair
{
    public static class ExtraLetterManipulator
    {
        private const char ExtraLetter = 'X';
        
        public static string RemoveLastExtraLetterIfPresent(string text)
        {
            if (text.Length == 0)
                return string.Empty;
            
            return IsLastLetterExtra(text) ? text.Substring(0, text.Length - 1) : text;
        }

        private static bool IsLastLetterExtra(string text)
        {
            int lastIndex = text.Length - 1;
            return text[lastIndex] == ExtraLetter;
        }

        public static string AddExtraLetterIfOddLength(string text)
        {
            return text.Length.IsOdd() ? text + ExtraLetter : text;
        }
    }
}