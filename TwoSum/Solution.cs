using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.<br></br>
    /// you may assume that each input would have exactly one solution, and you may not use the same element twice.<br></br>
    /// You can return the answer in any order.<br></br>
    /// Constraints<br></br>
    /// 2 &lt;= nums.length &lt;= 10^4<br></br>
    /// -10^9 &lt;= nums[i] &lt;= 10^9<br></br>
    /// -10*9 &lt;= target &lt;= 10^9<br></br>
    /// Only one valid answer exists <br></br>
    /// Follow up: Can you come up with a solution of less than O(n^2) complexity?
    /// </summary>
    class Solution
    {
        public Solution(bool debug = false)
        {
            TestCases(debug);
        }


        private void TestCases(bool debug)
        {
            var testCases = new List<Tuple<int[], int>>
            {
                new Tuple<int[], int>(new int[]{2,7,11,15 }, 9),
                new Tuple<int[], int>(new int[]{3,2,4}, 6),
                new Tuple<int[], int>(new int[]{3,3}, 6)
            };

            foreach (var testCase in testCases)
            {
                //Debug.PrintIEnumerable(testCase.Item1, debug);
                //Debug.PrintForDebug($"Target Sum {testCase.Item2}\nResult:", debug);
                var result = TwoSum(testCase.Item1, testCase.Item2);
                //Debug.PrintIEnumerable(result, debug);
                Console.WriteLine("---");
            }


        }

        private int[] TwoSum(int[] nums, int target)
        {
            //It will never happen due to constraints , however for completeness sake it is added.
            if (nums == null || nums.Length < 2)
            {
                return new int[2];
            }


            Dictionary<int, int> dictionary = new Dictionary<int, int>(nums.Length);

            for (int i = 0; i < nums.Length; i++) //O(n)
            {
                //Fantastic workaround thought. Check First if complement exists. At first iteration
                //dict is empty , then immediately we add and we have something in the dictionary 
                //to search for in the next iteration. Fantastic really. This covers the tricky case
                //where you have num = [3,3] and target 6. (3,0) is already in dictionary
                //but no exception will be raised when you try to
                //add for a second time (3,1) because you will have already returned the complemetary (3,1)
                if (dictionary.ContainsKey(target - nums[i]))
                {
                    return new int[2] { i, dictionary[target - nums[i]] };
                }
                else if (!dictionary.ContainsKey(nums[i]))//O(1)
                {
                    dictionary.Add(nums[i], i);//O(1)
                }
                //In Java this scheme is implemented via hashmap.

            }

            //it will never come to this since it is guaranteed that each input would have exactly one solution.
            return new int[2];
        }

    }
}
