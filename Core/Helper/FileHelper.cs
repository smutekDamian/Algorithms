using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        public static string GetTextFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }

            throw new FileNotFoundException($"File {filePath} does not exist");
        }

        public static void SerializeToBinaryFile<T>(string filePath,  T obj)
        {
            using (var stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
            }
        }

        public static T DeserializeFromBinaryFile<T>(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T) binaryFormatter.Deserialize(stream);
            }
        }

        public static void WriteTextToFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }
}
