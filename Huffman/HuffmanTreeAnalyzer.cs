using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public class HuffmanTreeAnalyzer
    {
        private readonly BinaryTree<Leaf> _tree;
        private readonly Dictionary<string, BitArray> _codes;

        public HuffmanTreeAnalyzer(BinaryTree<Leaf> tree)
        {
            _tree = tree;
            _codes = new Dictionary<string, BitArray>();
        }

        public Dictionary<string, BitArray> GetByteCodes()
        {
            GoThroughTreeAndGetCodes(_tree, new List<bool>());
            return _codes;
        }

        private void GoThroughTreeAndGetCodes(BinaryTree<Leaf> tree, IList<bool> bits)
        {
            if (tree.Left == null && tree.Right == null && tree.Data.Sequence != null)
            {
                _codes.Add(tree.Data.Sequence, new BitArray(bits.ToArray()));
                return;
            }

            var leftBits = new List<bool>(bits);
            var rightBits = new List<bool>(bits);
            leftBits.Add(false);
            rightBits.Add(true);
            GoThroughTreeAndGetCodes(tree.Left, leftBits);
            GoThroughTreeAndGetCodes(tree.Right, rightBits);
        }
    }
}
