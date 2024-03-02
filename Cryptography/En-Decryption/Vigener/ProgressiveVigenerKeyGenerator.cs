using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
    public class ProgressiveVigenerKeyGenerator : IVigenerKeyGenerator
    {
        string IVigenerKeyGenerator.GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption)
        {
            var keyBuilder = new StringBuilder(text.Length);

            var keywordCharProvider = new KeywordCharProvider(alphabet, keyword);
            for (int i = 0; i < text.Length; i++)
                keyBuilder.Append(keywordCharProvider.GetNext());

            return keyBuilder.ToString();
        }
        
        private struct KeywordCharProvider
        {
            private readonly Alphabet _alphabet;
            private readonly string _keyword;
            private int _shiftFactor;
            private int _keywordIndex;

            public KeywordCharProvider(Alphabet alphabet, string keyword)
            {
                _alphabet = alphabet;
                _keyword = keyword;
                _shiftFactor = 0;
                _keywordIndex = 0;
            }
            
            public char GetNext()
            {
                char currentChar = _alphabet.ShiftLetter(_keyword[_keywordIndex], _shiftFactor);
                if (++_keywordIndex == _keyword.Length)
                {
                    _shiftFactor++;
                    _keywordIndex = 0;
                }
                return currentChar;
            }
        }
    }
}