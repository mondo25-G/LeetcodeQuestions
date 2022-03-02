using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace MissingNumber
{
    /// <summary>
    /// 268 - Missing Number<br></br>
    /// Given an array nums containing n distinct numbers in the range [0, n],<br></br> 
    /// return the only number in the range that is missing from the array.<br></br>
    /// Constraints <br></br>
    /// n == nums.length <br></br>
    /// 1 &lt;= n &lt;= 10^4 <br></br>
    /// 0 &lt;= nums[i] &lt;= n <br></br>
    /// All the numbers of nums are unique.<br></br>
    /// Follow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(MissingNumberA, debug);
            TestCases(MissingNumberB, debug);
            TestCases(MissingNumberXOR, debug);
            TestCases(MissingNumberArithmeticSeries, debug);
        }

        public delegate int MissingNumber(int[] nums, bool debug);

        public void TestCases(MissingNumber del, bool debug)
        {
            var testCase = new int[] { 0, 1 };

            Debug.PrintForDebug($"Missing number is {del(testCase, debug)}", debug);

        }

        //Simple way, Sorting. O(nlog(n) time, O(n) space.
        public int MissingNumberA(int[] nums, bool debug = false)
        {

            int[] ordArray = nums.OrderBy(x => x).ToArray(); //O(nlog(n)) time

            for (int i = 0; i < ordArray.Length; i++)
            {
                if (ordArray[i] != i)
                {
                    return i;
                }
            }

            return ordArray.Length;
        }

        //Significantly better way, Hashset. O(n) time, O(n) space.
        public int MissingNumberB(int[] nums, bool debug = false)
        {
            int missingNum = 0;
            HashSet<int> hashSet = new HashSet<int>(nums);

            for (int i = 0; i <= nums.Length; i++)
            {
                if (!hashSet.Contains(i))
                {
                    missingNum = i;
                }
            }
            return missingNum;
        }

        //Optimal way, Bit Manipulation. O(n) time, O(1) space.
        //The infamous XOR trick.
        public int MissingNumberXOR(int[] nums, bool debug = false)
        {
            string SOS = "XOR Properties\n1) x^x = 0\n2) 0^x = x\n3) XOR is commutative (x^y=y^x) and associative (x^y^z=x^z^y=z^y^x=z^x^y)\n\n" +
                 "the algorithm below for say input [15,12,15,6,6] will be 0^15^12^15^6^6 \n" +
                 "(1)=> 0^15^12^15^(6^6)=>0^15^12^15^0\n" +
                 "(2)=>(0 ^ 15) ^ 12 ^ (15 ^ 0)=>15 ^ 12 ^ 15=>(15 ^ 15) ^ 12=>0 ^ 12=>12\n";
            Debug.PrintForDebug(SOS, debug);

            int missingNum = 0;

            //Get XOR of all numbers in DESIRED RANGE
            for (int i = 0; i <= nums.Length; i++)
            {
                missingNum = missingNum ^ i;
            }

            //XOR the previous with all numbers in array 
            for (int i = 0; i < nums.Length; i++)
            {
                missingNum = missingNum ^ nums[i];
            }

            //What remains will be the missing number. Since first loop will catch all numbers , and second loop wil catch all but one
            //you have the XOR property a^a^b^b^c^d^d etc which is 0^c^0= c missing number.


            return missingNum;
        }

        //Optimal way, Arithmetic series. O(n) time, O(1) space.
        public int MissingNumberArithmeticSeries(int[] nums, bool debug = false)
        {
            /* sum of arithmetic series i.e. each term is previous one plus steady increment val
             * = (number of terms)/2 * (first term + last term)
             */
            int desiredSum = (nums.Length + 1) * (0 + nums.Length) / 2;
            int actualSum = nums.Sum();//O(n)

            return desiredSum - actualSum;
        }

    }
}
