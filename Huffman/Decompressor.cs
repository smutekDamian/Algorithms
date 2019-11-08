using System.Text;
using Core.Helper;

namespace Huffman
{
    public static class Decompressor
    {
        public static string Decompress(string filePath)
        {
            var huffmanFile = FileHelper.DeserializeFromBinaryFile<HuffmanFile>(filePath);
            var currentPosition = huffmanFile.Tree;
            var decodedStringBuilder = new StringBuilder();

            foreach (bool bit in huffmanFile.CodedBits)
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
                    currentPosition = huffmanFile.Tree;
                }
            }

            return decodedStringBuilder.ToString();
        }
    }
}
