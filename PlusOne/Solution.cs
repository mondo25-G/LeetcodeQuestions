using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace PlusOne
{
    /// <summary>
    /// 66.PlusOne
    /// You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. <br></br>
    /// The digits are ordered from most significant to least significant in left-to-right order.<br></br>
    /// The large integer does not contain any leading 0's.Increment the large integer by one and return the resulting array of digits.
    /// Constraints:<br></br>
    /// 1 &lt;= digits.length &lt;= 100<br></br>
    /// 0 &lt;= digits[i] &lt;= 9<br></br>
    /// digits does not contain any leading 0's.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }


        public void TestCases(bool debug)
        {
            List<int[]> testCases = new List<int[]>
            {
                new int[] {9,9,9,8,9,9},
                new int[] {9,9,9,9,9,9},
                new int[] {1,5,9,9,9},
                new int[] {9,9,9,5,1},
                new int[] {9,8,2,9,0,9},
                new int[] {9,9,1,1,9,9},
                new int[] {8,9,9,9}
            };


            foreach (var testCase in testCases)
            {
                Debug.PrintIEnumerable(testCase, debug);
                var result = PlusOne(testCase, debug);
                Debug.PrintIEnumerable(result, debug);
                Debug.PrintForDebug("------", debug);

            }
        }

        //Time: O(n), Space: O(n) ( the length of the array is dependent on whether every n is 9 or not, so it is O(n).
        //I do not always return int[n], I may return int[n+1].
        public int[] PlusOne(int[] digits, bool debug)
        {
            //check last digit if not nine first.
            if (digits[digits.Length - 1] != 9)
            {
                digits[digits.Length - 1]++;
                return digits;
            }

            //Deal with all other cases where last digit is nine, and all digits but one may be 9. 
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9 && carry == 1)
                {
                    digits[i] = 0;
                }

                else if (digits[i] != 9 && carry == 1)
                {
                    digits[i]++;
                    carry = 0;
                    return digits;
                }

                else
                {
                    return digits;
                }

            }


            //If you haven't returned anything yet, you must have all your digits equal to 9.
            int[] result = new int[digits.Length + 1];
            result[0] = 1;
            return result;


        }





    }
}
