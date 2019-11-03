using System;
using System.Linq;
using Huffman;
using Xunit;

namespace HuffmanTests
{
    public class StringExtensionsTests
    {
        private const string TestString = "Ala ma kota, a kot ma Alę.";
        [Fact]
        public void ShouldDivideStringIntoOneCharacterLength()
        {
            //Assert

            //Act
            var huffmanLeaves = TestString.GetHuffmanLeaves(1).ToList();

            //Assert
            Assert.True(huffmanLeaves.Count.Equals(11));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals("k"))?.Frequency.Equals(2));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals(" "))?.Frequency.Equals(6));
        }
        
        [Fact]
        public void ShouldDivideStringIntoTwoCharacterLength()
        {
            //Assert

            //Act
            var huffmanLeaves = TestString.GetHuffmanLeaves(2).ToList();

            //Assert
            Assert.True(huffmanLeaves.Count.Equals(9));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals("a "))?.Frequency.Equals(2));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals(" a"))?.Frequency.Equals(1));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals("Al"))?.Frequency.Equals(2));
        }
        [Fact]
        public void ShouldDivideStringIntoFiveCharacterLength()
        {
            //Assert

            //Act
            var huffmanLeaves = TestString.GetHuffmanLeaves(5).ToList();

            //Assert
            Assert.True(huffmanLeaves.Count.Equals(6));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals("Ala m"))?.Frequency.Equals(1));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals("kot m"))?.Frequency.Equals(1));
            Assert.True(huffmanLeaves.FirstOrDefault(x => x.Sequence.Equals("."))?.Frequency.Equals(1));
        }
    }
}
