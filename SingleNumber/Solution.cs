using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace SingleNumber
{
    //TODO: MEMORIZE XOR tricks.

    /// <summary>
    /// 136 -Single Number <br></br>
    /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one. <br></br>
    /// You must implement a solution with a linear runtime complexity and use only constant extra space. <br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= nums.length &lt;= 3 * 10^4 <br></br>
    /// -3 * 10^4 &lt;= nums[i] &lt;= 3 * 10^4 <br></br>
    /// Each element in the array appears twice except for one element which appears only once.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }
        /// <summary>
        /// Given an array of integers where each element but one appears twice, returns the unique element in O(n) time O(1) space.<br></br>
        /// USE XOR TRICK !!!!!!.<br></br>
        /// </summary>
        /// <param name="nums">the array of integers</param>
        /// <param name="debug">debug print option</param>
        /// <returns>the unique element</returns>

        public int SingleNumber(int[] nums, bool debug)
        {
            string SOS = "XOR Properties\n1) x^x = 0\n2) 0^x = x\n3) XOR is commutative (x^y=y^x) and associative (x^y^z=x^z^y=z^y^x=z^x^y)\n\n" +
                "the algorithm below for input [15,12,15,6,6] will be 0^15^12^15^6^6 \n" +
                "(1)=> 0^15^12^15^(6^6)=>0^15^12^15^0\n" +
                "(2)=>(0 ^ 15) ^ 12 ^ (15 ^ 0)=>15 ^ 12 ^ 15=>(15 ^ 15) ^ 12=>0 ^ 12=>12\n";
            Debug.PrintForDebug(SOS, debug);
            int result = 0;

            //https://florian.github.io/xor-trick/
            
            foreach (var num in nums)
            {
                result = result ^ num;
            }
            Debug.PrintIEnumerable(nums, debug);
            return result;
        }

        private void TestCases(bool debug)
        {
            var testCase = new int[] { 4, 4, 2, 1, 2 };

            Debug.PrintForDebug($"Unique element is {SingleNumber(testCase, debug)}", debug);
        }
    }
}
