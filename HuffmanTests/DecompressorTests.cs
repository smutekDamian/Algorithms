using Core.Helper;
using Huffman;
using Xunit;

namespace HuffmanTests
{
    [Collection("Sequential")]
    public class DecompressorTests
    {
        [Fact]
        public void ShouldDecompressPreviouslyCompressedFile()
        {
            //Arrange
            var testFileContent = FileHelper.GetTextFromFile(TestFilePaths.SenecaFilePath);
            var compressor = new Compressor(1, testFileContent);
            var decompressor = new Decompressor(TestFilePaths.SenecaCompressedFilePath);
            string decompressedFileContent;

            //Act
            compressor.Compress(TestFilePaths.SenecaCompressedFilePath);
            decompressedFileContent = decompressor.Decompress();

            //Assert
            Assert.Equal(testFileContent, decompressedFileContent);
        }
    }
}
