using System.Linq;

namespace Encryption.Alphabet
{
    public static class EnglishAlphabet
    {
        public static bool Contains(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
        
        public static string RemoveNonAlphabetic(string s)
        {
            return new string(s.Where(Contains).ToArray());
        }
    }
}