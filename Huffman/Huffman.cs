using System;
using System.IO;
using Core.Helper;

namespace Huffman
{
    public class Huffman
    {
        public static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length > 4)
            {
                throw new ArgumentException("Wrong arguments. Should be: c inputFilePath outputFilePath sequenceLength or \n d inputFilePath outputFilePath");
            }

            var inputFilePath = args[1];
            var outputFilePath = args[2];
            var type = args[0].ToLower();

            if (type.Equals("c"))
            {
                var sequenceLength = int.Parse(args[3]);
                var text = FileHelper.GetTextFromFile(inputFilePath);
                var compressor = new Compressor(sequenceLength, text);
                compressor.Compress(outputFilePath);
                Console.WriteLine($"File {inputFilePath} has been compressed into file {outputFilePath}.");
                Console.WriteLine($"Compression level is {FileInfoHelper.GetSizeDiffBetweenTwoFiles(inputFilePath, outputFilePath)}");
            }
            else if (type.Equals("d"))
            {
                var decompressedText = Decompressor.Decompress(inputFilePath);
                FileHelper.WriteTextToFile(outputFilePath, decompressedText);
                Console.WriteLine($"File {inputFilePath} has been decompressed into file {outputFilePath}");
            }
        }
    }
}
