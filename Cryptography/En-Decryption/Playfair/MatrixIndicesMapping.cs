namespace Cryptography.En_Decryption.Playfair
{
    internal readonly struct MatrixIndicesMapping
    {
        public int Coord1Index { get; }
        public int Coord2Index { get; }
        public int Letter1Index { get; }
        public int Letter2Index { get; }

        public MatrixIndicesMapping(int coord1Index, int coord2Index, int letter1Index, int letter2Index)
        {
            Coord1Index = coord1Index;
            Coord2Index = coord2Index;
            Letter1Index = letter1Index;
            Letter2Index = letter2Index;
        }
    }
}