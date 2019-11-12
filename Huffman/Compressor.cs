using System;
using System.Collections;
using System.Collections.Generic;
using Core.Helper;

namespace Huffman
{
    public class Compressor
    {
        private readonly string _text;
        private readonly int _sequenceLength;
        private readonly Dictionary<string, IEnumerable<bool>> _mappings;
        private readonly IEnumerable<Leaf> _initialLeaves;

        public Compressor(int sequenceLength, string text)
        {
            _sequenceLength = sequenceLength;
            _text = text;
            _initialLeaves = _text.DivideIntoGetHuffmanLeaves(sequenceLength);
            var huffmanTree = new HuffmanTree(_initialLeaves).Create();
            var bitCodeMappingService = new BitCodeMappingService(huffmanTree);
            _mappings = bitCodeMappingService.GetSentenceToBitCodesMappings();
        }

        public void Compress(string outputFilePath)
        {
            var bitArray = ConvertTextToBitArray();
            var huffmanFile = new HuffmanFile(bitArray, _initialLeaves);
            FileHelper.SerializeToBinaryFile(outputFilePath, huffmanFile);
        }

        private BitArray ConvertTextToBitArray()
        {
            var encodedTextBitArray = new List<bool>();
            for (var i = 0; i < _text.Length; i += _sequenceLength)
            {
                var sequence = _text.Substring(i, Math.Min(_sequenceLength, _text.Length - i));
                encodedTextBitArray.AddRange(_mappings[sequence]);
            }

            var bitArray = new BitArray(encodedTextBitArray.ToArray());
            return bitArray;
        }
    }
}
