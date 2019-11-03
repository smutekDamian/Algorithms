namespace Huffman
{
    public class Leaf
    {
        public Leaf()
        {
        }

        public Leaf(string c, int frequency)
        {
            Sequence = c;
            Frequency = frequency;
        }
        public string Sequence { get; set; }
        public int Frequency { get; set; }
        public byte[] PrefixCode { get; set; }
    }
}
