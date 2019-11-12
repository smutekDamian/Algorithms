using Huffman;
using Xunit;

namespace HuffmanTests
{
    public class HuffmanTreeTests
    {
        [Fact]
        public void ShouldCreateHuffmanTree()
        {
            //Arrange
            const string testText = "TO BE OR NOT TO BE";
            var huffmanTree = new HuffmanTree(testText.DivideIntoGetHuffmanLeaves(1));
            
            //Act
            var tree = huffmanTree.Create();

            //Assert
            Assert.True(tree.Size().Equals(13));
            Assert.True(tree.Height.Equals(4));
        }
    }
}
