namespace Cryptography.En_Decryption.Playfair
{
    public interface IPlayfairQuadraticKeyFactory
    {
        Alphabet UsedAlphabet { get; }
        char KeyDelimiter { get; }
        internal IPlayfairQuadraticKey Create(string keyword);
    }

    public class PlayfairEnQuadraticKeyFactory : IPlayfairQuadraticKeyFactory
    {
        public char KeyDelimiter { get; }

        public PlayfairEnQuadraticKeyFactory(char keyDelimiter)
        {
            KeyDelimiter = keyDelimiter;
        }
        
        public Alphabet UsedAlphabet  => PlayfairEnQuadraticKey.UsedAlphabet;
        
        IPlayfairQuadraticKey IPlayfairQuadraticKeyFactory.Create(string keyword)
        {
            var keywords = keyword.Split(KeyDelimiter);
            return new PlayfairEnQuadraticKey(keywords);
        }
    }
}