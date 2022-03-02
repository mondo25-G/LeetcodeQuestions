using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace MaximumSubarray
{
    /// <summary>
    /// Given an integer array nums, find the contiguous subarray (containing at least one number)<br></br>
    /// which has the largest sum and return its sum.<br></br>
    /// A subarray is a contiguous part of an array.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= nums.length &lt;= 10^5<br></br>
    /// -10^4 &lt;= nums[i] &lt;= 10^4<br></br>
    /// Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }


        public void TestCases(bool debug)
        {
            var testCases = new List<int[]>
            {
                new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, //[4,-1,2,1] has the largest sum = 6.
                new int[] { 5, 4, -1, 7, 8 },
                new int[] { 1},
                new int[] { -2,-2,-10,-3,-8}
            };

            foreach (var testCase in testCases)
            {
                Debug.PrintIEnumerable(testCase, debug);
                var result = MaxSubArray(testCase);
                Debug.PrintForDebug($"Maximum Subarray sum is: {result}\n", debug);
                PrintMaxSubArray(testCase, debug);



            }
        }

        //This is NOT an easy one.

        //Kadane's algorithm. O(n) time O(1) space.
        public int MaxSubArray(int[] nums)
        {
            int max = int.MinValue;
            int sum = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i]; //keep incrementing sum                
                max = Math.Max(sum, max); //find maximum after each sum

                //If at any point the sum becomes negative set it to zero since zero will be larger than any negative
                //This line captures the maximum negative number in an array of negative numbers
                //because it essentially compares two distinct negative numbers each time.
                if (sum < 0)
                {
                    sum = 0;
                }

                //The cost of restarting the sum from 0 is lower than restarting from any negative sum
            }
            return max;
        }


        //What if you also want to print the subarray with the max sum? 
        //To get the elements, its length, its starting ending index?

        public void PrintMaxSubArray(int[] nums, bool debug)
        {

            int max = nums[0];
            int start = 0, end = 0; // the final start and end position of the maximum sum subarray

            int sum = 0;
            int s = 0; // the temporary start position

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum > max)
                {
                    max = sum;
                    start = s;
                    end = i;
                }


                if (sum < 0)
                {
                    sum = 0;
                    s = i + 1;
                }

            }

            s = -1;
            int[] maxSub = new int[end - start + 1];
            for (int i = start; i <= end; i++)
            {
                maxSub[++s] = nums[i];
            }

            Debug.PrintForDebug($"The maximum sub array starting index is: {start} and ending index is {end}", debug);
            Debug.PrintForDebug($"The maximum sub array is:", debug);
            Debug.PrintIEnumerable(maxSub, debug);
            Debug.PrintForDebug($"The maximum sub array sum is: {max}\n", debug);

        }




        //TODO: Divide and Conquer.
    }
}
