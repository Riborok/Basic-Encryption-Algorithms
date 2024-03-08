using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
	public class DirectKeyFactory : VigenerKeyFactory 
	{
		public DirectKeyFactory(Alphabet alphabet) : base(alphabet)
		{
		}
		
		protected override IKeywordCharProvider CreateKeywordCharProvider(string text, string keyword, StringBuilder sb)
		{
			return new DirectKeywordCharProvider(keyword);
		}
	}
	
	internal class DirectKeywordCharProvider : IKeywordCharProvider
	{
		private readonly string _keyword;
		private int _keywordIndex = 0;
		
		public DirectKeywordCharProvider(string keyword) => _keyword = keyword;

		char IKeywordCharProvider.GetNextForEncryption(int i) => GetNext();
		char IKeywordCharProvider.GetNextForDecryption(int i) => GetNext();
		
		private char GetNext()
		{
			char nextKeywordChar = _keyword[_keywordIndex];
			_keywordIndex = (_keywordIndex + 1) % _keyword.Length;
			return nextKeywordChar;
		}
	}
}