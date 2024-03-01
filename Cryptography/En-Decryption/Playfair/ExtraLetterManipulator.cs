using System.Text;

namespace Cryptography.En_Decryption.Playfair
{
    internal static class ExtraLetterManipulator
    {
        private const char ExtraLetter = 'X';
        
        public static string RemoveExtraLetters(StringBuilder text)
        {
            if (text.Length < 3)
                return text.ToString();
            
            int lastIndex = text.Length - 1;
            
            var result = new StringBuilder(text.Length).Append(text[0]);
            for (int i = 1; i < lastIndex; i++)
                if (IsNotExtraLetter(text[i]) || IsNotSurroundedBySameLetter(text, i))
                    result.Append(text[i]);

            if (IsNotExtraLetter(text[lastIndex]))
                result.Append(text[lastIndex]);

            return result.ToString();
        }
        private static bool IsNotExtraLetter(char letter) => letter != ExtraLetter;
        private static bool IsNotSurroundedBySameLetter(StringBuilder text, int index) => text[index - 1] != text[index + 1];

        public static char GetNextLetter(string text, ref int index)
        {
            return index + 1 < text.Length && text[index + 1] != text[index] ? text[++index] : ExtraLetter;
        }
    }
}