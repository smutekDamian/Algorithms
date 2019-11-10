using Core.Helper;
using Huffman;
using Xunit;

namespace HuffmanTests
{
    [Collection("Sequential")]
    public class DecompressionTests
    {
        [Fact]
        public void ShouldDecompressPreviouslyCompressedFile()
        {
            //Arrange
            var testFileContent = FileHelper.GetTextFromFile(TestFilePaths.SenecaFilePath);
            var compressor = new Compressor(1, testFileContent);
            string decompressedFileContent;

            //Act
            compressor.Compress(TestFilePaths.SenecaCompressedFilePath);
            decompressedFileContent = Decompressor.Decompress(TestFilePaths.SenecaCompressedFilePath);

            //Assert
            Assert.Equal(testFileContent, decompressedFileContent);
        }
    }
}
