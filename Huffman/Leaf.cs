using System;

namespace Huffman
{
    [Serializable]
    public class Leaf
    {
        private Leaf()
        {
        }

        public Leaf(string c, int frequency)
        {
            Sequence = c;
            Frequency = frequency;
        }
        public string Sequence { get; private set; }
        public int Frequency { get; set; }
    }
}
