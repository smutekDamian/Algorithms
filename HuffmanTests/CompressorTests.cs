using Core.Helper;
using Huffman;
using Xunit;

namespace HuffmanTests
{
    public class CompressorTests
    {
        private const string SenecaFilePath = @"App_Data\seneca.txt";
        private const string SenecaCompressedFilePath = @"App_Data\seneca_compressed.txt";

        [Fact]
        public void ShouldCompressSenecaWithOneLetter()
        {
            Assert.True(Compress(1, SenecaFilePath, SenecaCompressedFilePath).Equals(00.41078400592492414));
        }

        [Fact]
        public void ShouldCompressSenecaWithTwoLetters()
        {
            Assert.True(Compress(2, SenecaFilePath, SenecaCompressedFilePath).Equals(0.29024078054435243));
        }

        private static double Compress(int sentenceLength, string filePath, string compressedFilePath)
        {
            var text = FileHelper.GetTextFromFile(filePath);
            var compressor = new Compressor(sentenceLength, text);
            compressor.Compress(compressedFilePath);
            var compressionLevel =  FileInfoHelper.GetSizeDiffBetweenTwoFiles(filePath, compressedFilePath);
            return compressionLevel;
        }
    }
}
