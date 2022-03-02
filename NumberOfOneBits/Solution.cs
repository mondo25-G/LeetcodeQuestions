using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace NumberOfOneBits
{
    /// <summary>
    /// 191. Number of 1 Bits<br></br>
    /// Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).<br></br>
    /// Constraints:<br></br>
    /// The input must be a binary string of length 32.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }

        public void TestCases(bool debug)
        {
            uint testCase1 = 0b11111111111111111111111111111101;
            uint testCase2 = 0b000000001001000000011100000011;
            Debug.PrintForDebug($"{testCase1}\n", debug);
            Debug.PrintForDebug($"Count of 1s in binary: {HammingWeight(testCase1, debug)}\n", debug);

            Debug.PrintForDebug($"{testCase2}\n", debug);
            Debug.PrintForDebug($"Count of 1s in binary: {HammingWeight(testCase2, debug)}\n", debug);
        }


        //O(1) time assuming always 32 bit integers, O(1) space.
        public int HammingWeight(uint n, bool debug)
        {
            int count = 0;
            for (int i = 31; i >= 0; i--)
            {
                uint check = (uint)Math.Pow(2.0, i);
                if (n >= check)
                {
                    count++;
                    n -= check;
                }
                Debug.PrintForDebug($"{n}: {check}", debug);
            }
            return count;
        }


        //Equivalent. (Not trivial at all)
        //O(1) time, O(1) space. 
        //This uses a method attributed to Brian Kernighan of C fame.Basically it relies on the fact 
        //that if you subtract 1 from a binary number you flip the least significant set bit from 0 to 1 
        //and set all the bits lower to 1. 
        //When we and the result of this operation with the original number we have removed the lowest set bit from the number.
        //This takes time dependent on the number of set bits in a number.
        //While number is not zero
        //1-Increment count
        //2-remove lowest set bit by subtracting 1 from number and anding it with the original number.
        //3-Return count

        public int HammingWeightBitManipulation(uint n, bool debug)
        {
            // Kernighan Algorithm
            // O(# Set Bits)
            int count = 0;
            while (n != 0)
            {
                count++;
                n = n & (n - 1);
            }
            return count;

        }
    }
}
