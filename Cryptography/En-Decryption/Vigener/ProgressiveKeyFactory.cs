using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
	public class ProgressiveKeyFactory : VigenerKeyFactory
	{
		public ProgressiveKeyFactory(Alphabet alphabet) : base(alphabet)
		{
		}
		
		protected override IKeywordCharProvider CreateKeywordCharProvider(string text, string keyword, StringBuilder sb)
		{
			return new ProgressiveKeywordCharProvider(Alphabet, keyword);
		}
	}

	internal class ProgressiveKeywordCharProvider : IKeywordCharProvider
	{
		private readonly Alphabet _alphabet;
		private readonly string _keyword;
		private int _shiftFactor = 0;
		private int _keywordIndex = 0;

		public ProgressiveKeywordCharProvider(Alphabet alphabet, string keyword)
		{
			_alphabet = alphabet;
			_keyword = keyword;
		}
		
		char IKeywordCharProvider.GetNextForEncryption(int i) => GetNext();
		char IKeywordCharProvider.GetNextForDecryption(int i) => GetNext();

		private char GetNext()
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