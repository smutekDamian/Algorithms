using System.IO;

namespace Core.Helper
{
    public static class FileInfoHelper
    {

        public static double GetSizeDiffBetweenTwoFiles(string originalFilePath, string encodedFilePath)
        {
            var encodedSize = (double) new FileInfo(encodedFilePath).Length;
            var originalSize = (double) new FileInfo(originalFilePath).Length;
            return (originalSize - encodedSize) / originalSize;
        }
    }
}
