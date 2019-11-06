using System.Collections;
using System.Collections.Generic;
using Huffman;
using Xunit;

namespace HuffmanTests
{
    public class HuffmanTreeAnalyzerTests
    {
        [Fact]
        public void ShouldReturnSequenceToBytesCodeMap()
        {
            //Arrange
            const string testText = "TO BE OR NOT TO BE";
            var oBits = new BitArray(new [] {false, false});
            var spaceBits = new BitArray(new [] {true, false});
            var bBits = new BitArray(new [] {false, true, false});
            var eBits = new BitArray(new [] {false, true, true});
            var tBits = new BitArray(new [] {true, true, true});
            var nBits = new BitArray(new [] {true, true, false, true});
            var rBits = new BitArray(new [] {true, true, false, false});


            var huffmanTree = new HuffmanTree(testText, 1);
            var tree = huffmanTree.Create();
            var analyzer = new HuffmanTreeAnalyzer(tree);

            //Act
            Dictionary<string, BitArray> map = analyzer.GetByteCodes();

            //Asset
            Assert.True(map.Count.Equals(7));
            Assert.True(AreBitArraysEqual(map["O"], oBits));
            Assert.True(AreBitArraysEqual(map[" "], spaceBits));
            Assert.True(AreBitArraysEqual(map["B"], bBits));
            Assert.True(AreBitArraysEqual(map["E"], eBits));
            Assert.True(AreBitArraysEqual(map["T"], tBits));
            Assert.True(AreBitArraysEqual(map["N"], nBits));
            Assert.True(AreBitArraysEqual(map["R"], rBits));
        }

        private static bool AreBitArraysEqual(BitArray first, BitArray second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }

            for (var i = 0; i < first.Count; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
