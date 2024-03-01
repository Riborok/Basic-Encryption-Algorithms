namespace Cryptography.En_Decryption.Playfair
{
    internal readonly struct MatrixNums
    {
        public int IndexGivingCoord1 { get; }
        public int IndexGivingCoord2 { get; }
        public int IndexGivingLetter1 { get; }
        public int IndexGivingLetter2 { get; }

        public MatrixNums(int indexGivingCoord1, int indexGivingCoord2, int indexGivingLetter1, int indexGivingLetter2)
        {
            IndexGivingCoord1 = indexGivingCoord1;
            IndexGivingCoord2 = indexGivingCoord2;
            IndexGivingLetter1 = indexGivingLetter1;
            IndexGivingLetter2 = indexGivingLetter2;
        }
    }
}