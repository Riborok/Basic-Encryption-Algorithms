using System.Text;

namespace Cryptography.En_Decryption
{
    public interface IVigenerKeyGenerator
    {
        /**
         * Generates a Vigener key for the given text and keyword.
         * The length of the generated key MUST BE equal to the length of the text.
         */
        string GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption);
    }
    
    public class DirectVigenerKeyGenerator : IVigenerKeyGenerator
    {
        public string GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption)
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
    
    public class ProgressiveVigenerKeyGenerator : IVigenerKeyGenerator
    {
        public string GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption)
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
    
    public class SelfGeneratingVigenerKeyGenerator : IVigenerKeyGenerator
    {
        public string GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption)
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