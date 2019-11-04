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
            var oBits = new BitArray(new [] {false, true});
            var spaceBits = new BitArray(new [] {true, true});
            var bBits = new BitArray(new [] {false, false, true});
            var eBits = new BitArray(new [] {true, false, false});
            var tBits = new BitArray(new [] {true, false, true});
            var nBits = new BitArray(new [] {false, false, false, false});
            var rBits = new BitArray(new [] {false, false, false, true});


            var huffmanTree = new HuffmanTree(testText, 1);
            var tree = huffmanTree.Create();
            var analyzer = new HuffmanTreeAnalyzer(tree);

            //Act
            Dictionary<string, BitArray> map = analyzer.GetByteCodes();

            //Asset
            Assert.True(map.Count.Equals(7));
//            Assert.True(map["O"].Equals(oBits));
//            Assert.True(map[" "].Equals(spaceBits));
//            Assert.True(map["B"].Equals(bBits));
//            Assert.True(map["E"].Equals(eBits));
//            Assert.True(map["T"].Equals(tBits));
//            Assert.True(map["N"].Equals(nBits));
//            Assert.True(map["R"].Equals(rBits));
        }
    }
}
