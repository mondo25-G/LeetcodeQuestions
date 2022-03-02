using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;
using LCRandomClassLibrary.RandomIntCollections;

namespace ThirdMaximumNumber
{
    /// <summary>
    /// 414 - Third Maximum Number<br></br>
    /// Given an integer array nums, return the third distinct maximum number in this array. <br></br>
    /// If the third maximum does not exist, return the maximum number.<br></br>
    /// 1 &lt;= nums.length &lt;= 10^4 <br></br>
    /// -2^31 &lt;= nums[i] &lt;= 2^31 - 1 <br></br>
    /// Follow up: Can you find an O(n) solution?
    /// </summary>
    class Solution
    {
        private delegate int ThirdMaxMethods(int[] nums);

        public Solution(bool debug)
        {
            TestCases(ThirdMaxLinq, debug);
            Console.WriteLine("------");
            TestCases(ThirdMax, debug);
            Console.WriteLine("------");
            

        }

        private void TestCases(ThirdMaxMethods del, bool debug)
        {
            var testCases = new List<int[]> { 
                new int[] { 1, 3, 2 },
                new int[] { 1, 2 },
                new int[] { 2, 2,3,1,4 },
                new int[] { 1, 1, 1, 1 },
                new int[] { 1, 1, 2, 2 },
                new int[] { 1, 1, 2, 2, 3, 3 },
                new int[] { 1, 3, 3 }
            };

            var random = new RandomIntCollection(10, 3, 9);

            for (int i = 0; i < 5; i++)
            {
                testCases.Add(random.RandomArray());
            }
            
            foreach (var testCase in testCases)
            {
                Debug.PrintIEnumerable(testCase, debug);
                var result = del(testCase);
                Debug.PrintForDebug($"Third Max Element: {result}",debug);
            }

        }

        //Time Complexity O(nlog(n)), auxiliary space O(n).
        public int ThirdMaxLinq(int[] nums)
        {
            var ordDesc = nums.Distinct() //Time O(n)- Space O(n)
                             .OrderByDescending(c => c)//Time O(nlog(n)) - Space O(n)
                             .ToArray();//Time O(n) - Space O(n)
            if (ordDesc.Length <= 2)
            {
                return ordDesc[0];
            }

            return ordDesc[2];
        }


        //Time O(nlog(n)) amortized, auxiliary space O(n)
        public int ThirdMax(int[] nums) //O(nlog(n))
        {
            SortedSet<int> sortedSet = new SortedSet<int>();//Time :O(1)


            for (int i = 0; i < nums.Length; i++) //O(n)
            {
                sortedSet.Add(nums[i]);//O(1) since no resizing (?)
                if (sortedSet.Count > 3)
                {
                    sortedSet.Remove(sortedSet.Min);//O(log(n)
                }
            }
            return sortedSet.Count < 3 ? sortedSet.Max : sortedSet.Min;
        }



       //TODO: Find an O(n) time complexity solution


    }
}
