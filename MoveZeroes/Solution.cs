using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace MoveZeroes
{
    /// <summary>
    /// 283.Move Zeroes
    /// Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.<br></br>
    /// Note that you must do this in-place without making a copy of the array.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= nums.length &lt= 10^4
    /// -2^31 &lt= nums[i] &lt= 2^31 - 1
    /// Follow up: Could you minimize the total number of operations done?
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
                new int[] {0, 1, 0, 3, 12 },
                new int[] { 0},
                 new int[] { 1},
                  new int[] { 1,2,4,0,0,0},
                   new int[] { 0,0,0,1,2,4,0,0,0},
                    new int[] { 0,0,0,1,2,4},
                     new int[] {0,0,0,2},
                     new int[] {1,0,4,5,0,0,6,0,7,9,3,0,2}

            };

            foreach (var testCase in testCases)
            {
                Debug.PrintIEnumerable(testCase, debug);
                MoveZeroes(testCase);
                Debug.PrintIEnumerable(testCase, debug);
                Debug.PrintForDebug($"--------", debug);
            }
        }

        //O(n) time, O(1) space
        public void MoveZeroes(int[] nums)
        {
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[++index] = nums[i];
                }
            }
            for (int i = index + 1; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
