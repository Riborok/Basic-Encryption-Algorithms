using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
	public class SelfGeneratingKeyFactory : VigenerKeyFactory
	{
		public SelfGeneratingKeyFactory(Alphabet alphabet) : base(alphabet)
		{
		}

		protected override IKeywordCharProvider CreateKeywordCharProvider(string text, string keyword, StringBuilder sb)
		{
			return new SelfGeneratingCharProvider(Alphabet, text, keyword, sb);
		}
	}
	
	internal class SelfGeneratingCharProvider : IKeywordCharProvider
	{
		private readonly Alphabet _alphabet;
		private readonly string _text;
		private readonly string _keyword;
		private readonly StringBuilder _keyBuilder;
		private int _textIndex = 0;
            
		public SelfGeneratingCharProvider(Alphabet alphabet, string text, string keyword, StringBuilder keyBuilder)
		{
			_alphabet = alphabet;
			_text = text;
			_keyword = keyword;
			_keyBuilder = keyBuilder;
		}
		
		char IKeywordCharProvider.GetNextForEncryption(int i)
		{
			return i < _keyword.Length ? _keyword[i] : _text[_textIndex++];
		}

		char IKeywordCharProvider.GetNextForDecryption(int i)
		{
			return i < _keyword.Length 
				? _keyword[i] 
				: _alphabet.SubtractLetters(_text[_textIndex], _keyBuilder[_textIndex++]);
		}
	}
}