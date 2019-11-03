using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    public static class StringExtensions
    {
        public static IEnumerable<Leaf> GetHuffmanLeaves(this string inputString, int sequenceLength)
        {
            var inputStringLength = inputString.Length;
            var leaves = new List<Leaf>();
            for (var i = 0; i < inputStringLength; i += sequenceLength)
            {
                var sequence = inputString.Substring(i, Math.Min(sequenceLength, inputStringLength - i));
                var existingLeave = leaves.FirstOrDefault(x => x.Sequence.Equals(sequence));
                if (existingLeave != null)
                {
                    existingLeave.Frequency++;
                }
                else
                {
                    leaves.Add(new Leaf(sequence, 1));
                }
            }

            return leaves;
        }
    }
}
