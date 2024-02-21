using System.Text;

namespace Cryptography.En_Decryption
{
    public interface IVigenerKeyGenerator
    {
        /**
         * Generates a Vigener key for the given text and keyword.
         * The length of the generated key MUST BE equal to the length of the text.
         */
        string GenerateKey(Alphabet alphabet, string text, string keyword);
    }
    
    public class DirectVigenerKeyGenerator : IVigenerKeyGenerator
    {
        public string GenerateKey(Alphabet alphabet, string text, string keyword)
        {
            var keyBuilder = new StringBuilder(text.Length);
            
            int keywordIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = keyword[keywordIndex];
                keyBuilder.Append(currentChar);
                keywordIndex = (keywordIndex + 1) % keyword.Length;
            }

            return keyBuilder.ToString();
        }
    }
    
    public class ProgressiveVigenerKeyGenerator : IVigenerKeyGenerator
    {
        public string GenerateKey(Alphabet alphabet, string text, string keyword)
        {
            var keyBuilder = new StringBuilder(text.Length);

            int shiftFactor = 0;
            int keywordIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = GetNextKeywordChar(alphabet, keyword, ref shiftFactor, ref keywordIndex);
                keyBuilder.Append(currentChar);
            }

            return keyBuilder.ToString();
        }
        private static char GetNextKeywordChar(Alphabet alphabet, string keyword, ref int shiftFactor, ref int keywordIndex)
        {
            char currentChar = alphabet.ShiftLetter(keyword[keywordIndex], shiftFactor);
            if (++keywordIndex == keyword.Length)
            {
                shiftFactor++;
                keywordIndex = 0;
            }
            return currentChar;
        }
    }
    
    public class SelfGeneratingVigenerKeyGenerator : IVigenerKeyGenerator
    {
        public string GenerateKey(Alphabet alphabet, string text, string keyword)
        {
            var keyBuilder = new StringBuilder(text.Length);
            
            int textIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = i < keyword.Length ? keyword[i] : text[textIndex++];
                keyBuilder.Append(currentChar);
            }

            return keyBuilder.ToString();
        }
    }
}