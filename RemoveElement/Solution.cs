using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace RemoveElement
{
    /// <summary>
    /// 27-Remove Element:  https://leetcode.com/problems/remove-element/ <br></br>
    /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. <br></br>
    /// The relative order of the elements may be changed.<br></br>
    /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.<br></br>
    /// Constraints<br></br>
    /// 0 &lt;= nums.length &lt;= 100<br></br>
    /// 0 &lt;= nums[i] &lt;= 50<br></br>
    /// 0 &lt;= val &lt;= 100<br></br>
    /// </summary>
    public class Solution
    {

        public Solution(bool debug)
        {
            TestCases(debug);
        }

        private void TestCases(bool debug)
        {

            int[] testcase = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };

            foreach (var num in testcase.Distinct())
            {
                PrintCollections.Print(testcase);
                var temp = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
                Console.WriteLine($"Remove all incidences of {num}");
                int count = RemoveElement(temp, num, debug);
                Console.Write($"Removed all incidences of {num}. Remaining elements: {count} 'New' Array: ");
                PrintCollections.Print(temp.Take(count).ToArray());
                Console.WriteLine("------");
            }

        }

        private int RemoveElement(int[] nums, int val, bool debug = false)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            //Key here is to seperate the act of array traversal from array substitution.
           
            //Basically foreach num in nums if you dont meet val assure me and re-place num in nums[index] then increment index
            //and move to the next index position.
            //If however, you meet val DO NOT move to the next index position, keep it frozen.
            int index = 0;
            foreach (int num in nums)
            {
                Debug.PrintForDebug($"Before Check - nums in Foreach: {num}  nums indexed: {nums[index]}", debug);
                if (num != val)
                {
                    nums[index] = num;
                    Debug.PrintForDebug($"After Check - nums in Foreach: {num}  nums indexed: {nums[index]}\n", debug);
                    index++;

                }
                else
                {
                    Debug.PrintForDebug($"After Check - nums in Foreach: {num}  nums indexed: {nums[index]}\n", debug);
                }

            }
            return index;

        }

       
    }
}
