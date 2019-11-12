using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public static class BinaryTreeExtensions
    {
        public static int Size<T>(this BinaryTree<T> tree)
        {
            if (tree == null || tree.Data == null)
            {
                return 0;
            }

            return Size(tree.Left) + 1 + Size(tree.Right);
        }
    }
}
