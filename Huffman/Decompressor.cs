using System.Collections;
using System.Text;
using Core.Helper;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public class Decompressor
    {
        private readonly BinaryTree<Leaf> _tree;
        private readonly BitArray _codedBits;
        public Decompressor(string inputFilePath)
        {
            var huffmanFile = FileHelper.DeserializeFromBinaryFile<HuffmanFile>(inputFilePath);
            _tree = new HuffmanTree(huffmanFile.InitialLeaves).Create();
            _codedBits = huffmanFile.CodedBits;
        }

        public string Decompress()
        {
            return ConvertBitsIntoText();
        }

        public void Decompress(string outputFile)
        {
            var decompressedFileContent = Decompress();
            FileHelper.WriteTextToFile(outputFile, decompressedFileContent);
        }

        private string ConvertBitsIntoText()
        {
            var currentPosition = _tree;
            var decodedStringBuilder = new StringBuilder();

            foreach (bool bit in _codedBits)
            {
                if (bit)
                {
                    if (currentPosition.Right != null)
                    {
                        currentPosition = currentPosition.Right;
                    }
                }
                else
                {
                    if (currentPosition.Left != null)
                    {
                        currentPosition = currentPosition.Left;
                    }
                }

                if (currentPosition.Left == null && currentPosition.Right == null)
                {
                    decodedStringBuilder.Append(currentPosition.Data.Sequence);
                    currentPosition = _tree;
                }
            }

            return decodedStringBuilder.ToString();
        }
    }
}
