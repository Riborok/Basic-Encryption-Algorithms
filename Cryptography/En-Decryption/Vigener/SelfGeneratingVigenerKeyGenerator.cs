using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
    public class SelfGeneratingVigenerKeyGenerator : IVigenerKeyGenerator
    {
        string IVigenerKeyGenerator.GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption)
        {
            var keyBuilder = new StringBuilder(text.Length);
            
            var keywordCharProvider = new KeywordCharProvider(alphabet, text, keyword, keyBuilder, isEncryption);
            for (int i = 0; i < text.Length; i++)
                keyBuilder.Append(keywordCharProvider.GetNext(i));

            return keyBuilder.ToString();
        }

        private struct KeywordCharProvider
        {
            private readonly Alphabet _alphabet;
            private readonly string _text;
            private readonly string _keyword;
            private readonly StringBuilder _keyBuilder;
            private readonly bool _isEncryption;
            private int _textIndex;
            
            public KeywordCharProvider(Alphabet alphabet, string text, string keyword, StringBuilder keyBuilder, bool isEncryption)
            {
                _alphabet = alphabet;
                _text = text;
                _keyword = keyword;
                _keyBuilder = keyBuilder;
                _isEncryption = isEncryption;
                _textIndex = 0;
            }
            
            public char GetNext(int i)
            {
                char nextKeywordChar;
                if (i < _keyword.Length)
                    nextKeywordChar = _keyword[i];
                else
                {
                    nextKeywordChar = _isEncryption 
                        ? _text[_textIndex]
                        : _alphabet.SubtractLetters(_text[_textIndex], _keyBuilder[_textIndex]);
                    _textIndex++;
                }

                return nextKeywordChar;
            }
        }
    }
}