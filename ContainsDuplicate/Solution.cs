using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ContainsDuplicate
{  /// <summary>
   /// 217. Contains Duplicate<br></br>
   /// Given an integer array nums, return true if any value appears at least twice in the array, <br></br>
   /// and return false if every element is distinct.<br></br>
   /// Constraints:<br></br>
   /// 1 &lt;= nums.length &lt;= 10^5<br></br>
   /// -10^9 &lt;= nums[i] &lt;= 10^9
   /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(ContainsDuplicateDictionary, debug);
            Console.WriteLine("------");
            TestCases(ContainsDuplicateHashSet, debug);
            Console.WriteLine("------");
            TestCases(ContainsDuplicateLinq, debug);

        }

        public delegate bool ContainsDuplicate(int[] nums);
        public void TestCases(ContainsDuplicate del, bool debug)
        {
            List<int[]> testCases = new List<int[]> { new int[] {3 }, new int[] { 1, 2, 3, 1 },
                new int[] { 1, 2, 3, 4 }, new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 } };

            foreach (var testCase in testCases)
            {
                Debug.PrintIEnumerable(testCase, debug);
                bool result = del(testCase);
                Debug.PrintForDebug($"At least one value appears twice: {result}", debug);
            }

        }

        //Time: O(n) amortized, space: O(n)
        public bool ContainsDuplicateDictionary(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 1);
                }
                else
                {
                    return true;
                }

            }
            //Console.WriteLine(typeof(int[]).GetInterfaces());

            return false;
        }

        //Time:O(n),  Space:O(n)
        public bool ContainsDuplicateHashSet(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>(nums);//This constructor is O(n) time, O(n) space.
            return hashSet.Count == nums.Length ? false : true;
        }

        //Time:O(n),  Space:O(n)
        public bool ContainsDuplicateLinq(int[] nums)
        {
            return nums.GroupBy(x => x).Any(x => x.Count() > 1);

            //int[] implements ICollection so .Count() is time: O(1), space O(1) 
            //foreach (var type in typeof(int[]).GetInterfaces())
            //{
            //    Console.WriteLine(type);
            //}

            //GroupBy is time O(n), space O(n), Any is time O(n), space O(1).

            //In total, the above statement is O(n) time O(n) space.
        }
    }
}
