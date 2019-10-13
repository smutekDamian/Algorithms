using System.IO;

namespace Core.Helper
{
    public class FileHelper
    {
        public static string[] GetFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }

            throw new FileNotFoundException($"File {filePath} does not exist");
        }
    }
}
