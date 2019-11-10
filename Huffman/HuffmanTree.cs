using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public class HuffmanTree
    {
        private readonly IEnumerable<Leaf> _initialLeaves;

        public HuffmanTree(IEnumerable<Leaf> initialLeaves)
        {
            _initialLeaves = initialLeaves;
        }

        public BinaryTree<Leaf> Create()
        {
            var queue = RetrieveInitialLeaves();
            while (queue.Count > 1)
            {
                var firstLeaf = queue.Dequeue();
                var secondLeaf = queue.Dequeue();
                var newTreeRoot = new Leaf(null, firstLeaf.Data.Frequency + secondLeaf.Data.Frequency);
                var newTree = new BinaryTree<Leaf>(newTreeRoot) {Left = firstLeaf, Right = secondLeaf};
                queue.Add(newTree, newTreeRoot.Frequency);
            }

            return queue.Dequeue();
        }

        private PriorityQueue<BinaryTree<Leaf>,int> RetrieveInitialLeaves()
        {
            var queue = new PriorityQueue<BinaryTree<Leaf>, int>(PriorityQueueType.Minimum);
            foreach (var leaf in _initialLeaves)
            {
                queue.Add(new BinaryTree<Leaf>(leaf), leaf.Frequency);
            }

            return queue;
        }
    }


}
