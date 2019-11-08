using System;
using System.Collections.Generic;

namespace Huffman
{
    [Serializable]
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
    }

    public class LeafComparer : IComparer<Leaf>
    {
        public int Compare(Leaf x, Leaf y)
        {
            return x.Frequency = y.Frequency;
        }
    }
}
