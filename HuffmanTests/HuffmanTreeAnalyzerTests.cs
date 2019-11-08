using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var oBits = new [] {false, false};
            var spaceBits = new [] {true, false};
            var bBits = new [] {false, true, false};
            var eBits = new [] {false, true, true};
            var tBits = new [] {true, true, true};
            var nBits = new [] {true, true, false, true};
            var rBits = new [] {true, true, false, false};


            var huffmanTree = new HuffmanTree(testText, 1);
            var tree = huffmanTree.Create();
            var analyzer = new HuffmanTreeAnalyzer(tree);

            //Act
            Dictionary<string, IEnumerable<bool>> map = analyzer.GetByteCodes();

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

        private static bool AreBitArraysEqual(IEnumerable<bool> first, IEnumerable<bool> second)
        {
            var secondEnumerable = second as bool[] ?? second.ToArray();
            var firstEnumerable = first as bool[] ?? first.ToArray();
            if (firstEnumerable.Length != secondEnumerable.Length)
            {
                return false;
            }

            for (var i = 0; i < firstEnumerable.Length; i++)
            {
                if (firstEnumerable[i] != secondEnumerable[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
