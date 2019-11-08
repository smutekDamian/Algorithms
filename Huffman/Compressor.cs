using System;
using System.Collections;
using System.Collections.Generic;
using Core.Helper;
using NGenerics.DataStructures.Trees;

namespace Huffman
{
    public class Compressor
    {
        private readonly string _text;
        private readonly int _sequenceLength;
        private readonly Dictionary<string, IEnumerable<bool>> _codes;
        private readonly BinaryTree<Leaf> _huffmanTree;

        public Compressor(int sequenceLength, string text)
        {
            _sequenceLength = sequenceLength;
            _text = text;
            _huffmanTree = new HuffmanTree(_text, _sequenceLength).Create();
            var huffmanTreeAnalyzer = new HuffmanTreeAnalyzer(_huffmanTree);
            _codes = huffmanTreeAnalyzer.GetByteCodes();
        }

        public void Compress(string filePath)
        {
            var encodedTextBitArray = new List<bool>();
            for (var i = 0; i < _text.Length; i += _sequenceLength)
            {
                var sequence = _text.Substring(i, Math.Min(_sequenceLength, _text.Length - i));
                encodedTextBitArray.AddRange(_codes[sequence]);
            }

            var bitArray = new BitArray(encodedTextBitArray.ToArray());
            var huffmanFile = new HuffmanFile(bitArray, _huffmanTree);
            FileHelper.SerializeToBinaryFile(filePath, huffmanFile);
        }
    }
}
