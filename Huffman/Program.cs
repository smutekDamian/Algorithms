using System;
using Core.Helper;

namespace Huffman
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length > 4)
            {
                throw new ArgumentException("Wrong arguments. Should be: c inputFilePath outputFilePath sequenceLength or \n d inputFilePath outputFilePath");
            }

            var inputFilePath = args[1];
            var outputFilePath = args[2];
            var operationType = args[0].ToLower();

            if (operationType.Equals("c")) //compression
            {
                var sequenceLength = int.Parse(args[3]);
                var textToCompress = FileHelper.GetTextFromFile(inputFilePath);
                var compressor = new Compressor(sequenceLength, textToCompress);
                compressor.Compress(outputFilePath);
                Console.WriteLine($"File {inputFilePath} has been compressed into file {outputFilePath}.");
                var compressionRate = HuffmanUtilities.CalculateCompressionRate(inputFilePath, outputFilePath);
                Console.WriteLine($"Compression level is { compressionRate}");
            }
            else if (operationType.Equals("d")) //decompression
            {
                var decompressor = new Decompressor(inputFilePath);
                decompressor.Decompress(outputFilePath);
                Console.WriteLine($"File {inputFilePath} has been decompressed into file {outputFilePath}");
            }
        }
    }
}
