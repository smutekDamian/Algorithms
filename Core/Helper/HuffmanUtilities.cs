using System.IO;

namespace Core.Helper
{
    public static class HuffmanUtilities
    {
        public static double CalculateCompressionRate(string originalFilePath, string compressedFilePath)
        {
            var encodedSize = (double) new FileInfo(compressedFilePath).Length;
            var originalSize = (double) new FileInfo(originalFilePath).Length;
            return (originalSize - encodedSize) / originalSize;
        }
    }
}
