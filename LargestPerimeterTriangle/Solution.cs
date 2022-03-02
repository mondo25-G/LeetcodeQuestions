using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestPerimeterTriangle
{
    class Solution
    {
        /// <summary>
        /// 976 - Largest Perimeter Triangle
        /// Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, <br></br>
        /// formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0. <br></br>
        /// Constraints:<br></br>
        /// 3 &lt;= nums.length &lt;= 10^4 <br></br
        /// 1 &lt;= nums[i] &lt;= 10^6 <br></br
        /// </summary>
        public Solution()
        {
            TestCases();
        }



        private void TestCases()
        {
            var testCases = new List<int[]>
            {
                new int[] { 2, 1, 2 },
                new int[] { 1, 2, 1 }
            };

            foreach (var testCase in testCases)
            {
                var result = LargestPerimeter(testCase);
                Console.WriteLine(result);
            }
        }

        //Time Complexity O(nlog(n)), Auxiliary space O(1)
        private int LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);//O(NlogN)
            int size = nums.Length;
            List<int> triangle = new List<int>(3);

            for (int i = size - 1; i > 1; i--)//Reverse O(N)
            {
                //Triangle inequality theorem FOR NON DEGENERATE TRIANGLES
                if (nums[i] + nums[i - 1] > nums[i - 2]
                    && nums[i] + nums[i - 2] > nums[i - 1]
                    && nums[i - 2] + nums[i - 1] > nums[i])
                {
                    triangle.Add(nums[i - 2]);
                    triangle.Add(nums[i - 1]);
                    triangle.Add(nums[i]);
                    break;
                }
            }

            if (triangle.Count == 0)
            {
                return 0;
            }

            return triangle.Sum();
        }
    }
}
