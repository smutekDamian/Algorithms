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
            var queue = RetrieveInitialQueue();
            while (queue.Count > 1)
            {
                var firstSubTree = queue.Dequeue();
                var secondSubTree = queue.Dequeue();
                
                var newTreeRoot = new Leaf(null, firstSubTree.Data.Frequency + secondSubTree.Data.Frequency);
                var newTree = new BinaryTree<Leaf>(newTreeRoot) {Left = firstSubTree, Right = secondSubTree};
                queue.Add(newTree, newTreeRoot.Frequency);
            }

            return queue.Dequeue();
        }

        private PriorityQueue<BinaryTree<Leaf>,int> RetrieveInitialQueue()
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
