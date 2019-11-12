using System.Collections.Generic;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public class BitCodeMappingService
    {
        private readonly BinaryTree<Leaf> _tree;
        private readonly Dictionary<string, IEnumerable<bool>> _mappings;

        public BitCodeMappingService(BinaryTree<Leaf> tree)
        {
            _tree = tree;
            _mappings = new Dictionary<string, IEnumerable<bool>>();
        }

        public Dictionary<string, IEnumerable<bool>> GetSentenceToBitCodesMappings()
        {
            GoThroughTreeAndCollectMappings(_tree, new List<bool>());
            return _mappings;
        }

        private void GoThroughTreeAndCollectMappings(BinaryTree<Leaf> tree, IList<bool> bits)
        {
            if (tree.Left == null && tree.Right == null && tree.Data.Sequence != null)
            {
                _mappings.Add(tree.Data.Sequence, bits);
                return;
            }

            var leftBits = new List<bool>(bits);
            var rightBits = new List<bool>(bits);
            leftBits.Add(false);
            rightBits.Add(true);
            
            GoThroughTreeAndCollectMappings(tree.Left, leftBits);
            GoThroughTreeAndCollectMappings(tree.Right, rightBits);
        }
    }
}
