using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
    public class DirectVigenerKeyGenerator : IVigenerKeyGenerator
    {
        string IVigenerKeyGenerator.GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption)
        {
            var keyBuilder = new StringBuilder(text.Length);
            
            var keywordCharProvider = new KeywordCharProvider(keyword);
            for (int i = 0; i < text.Length; i++)
                keyBuilder.Append(keywordCharProvider.GetNext());

            return keyBuilder.ToString();
        }
        
        private struct KeywordCharProvider
        {
            private readonly string _keyword;
            private int _keywordIndex;

            public KeywordCharProvider(string keyword)
            {
                _keyword = keyword;
                _keywordIndex = 0;
            }
            
            public char GetNext()
            {
                char nextKeywordChar = _keyword[_keywordIndex];
                _keywordIndex = (_keywordIndex + 1) % _keyword.Length;
                return nextKeywordChar;
            }
        }
    }
}