using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public class HuffmanTree
    {
        private readonly string _text;
        private readonly int _sequenceLength;

        public HuffmanTree(string text, int sequenceLength)
        {
            this._text = text;
            _sequenceLength = sequenceLength;
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
            var leavesFromText = _text.GetHuffmanLeaves(_sequenceLength);
            var queue = new PriorityQueue<BinaryTree<Leaf>, int>(PriorityQueueType.Minimum);
            foreach (var leaf in leavesFromText)
            {
                queue.Add(new BinaryTree<Leaf>(leaf), leaf.Frequency);
            }

            return queue;
        }
    }


}
