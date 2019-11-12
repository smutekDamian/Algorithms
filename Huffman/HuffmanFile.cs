using System;
using System.Collections;
using System.Collections.Generic;

namespace Huffman
{
    [Serializable]
    public class HuffmanFile
    {
        public IEnumerable<Leaf> InitialLeaves { get; }
        public BitArray CodedBits { get; }

        public HuffmanFile(BitArray codedBits, IEnumerable<Leaf> leaves)
        {
            CodedBits = codedBits;
            InitialLeaves = leaves;
        }
    }
}
