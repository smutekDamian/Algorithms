using System;
using System.Collections;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    [Serializable]
    public class HuffmanFile
    {
        public BinaryTree<Leaf> Tree { get; }
        public BitArray CodedBits { get; }

        public HuffmanFile(BitArray codedBits, BinaryTree<Leaf> huffmanTree)
        {
            CodedBits = codedBits;
            Tree = huffmanTree;
        }
    }
}
