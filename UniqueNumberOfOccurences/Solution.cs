using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;


namespace UniqueNumberOfOccurences
{
    /// <summary>
    /// 1207-Given an array of integers arr, return true if the number of occurrences of each value in the array is unique, or false otherwise.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= arr.length &lt;= 1000 <br></br>
    /// -1000 &lt;= arr[i] &lt;= 1000
    /// </summary>
    public class Solution
    {
        public Solution()
        {

            TestCases(true);
        }


        public void TestCases(bool debug = false)
        {
            var testcases = new List<int[]> { new int[] { 1, 2, 2, 1, 1, 3 }, new int[] { 1, 2 }, new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 }, new int[] { 0 } };
            foreach (var testcase in testcases)
            {
                Console.WriteLine(UniqueOccurrences(testcase, debug));
                Console.WriteLine(UniqueOccurencesLINQ(testcase, debug));
            }
        }
        //Time O(n), Space O(n) where n = arr.Length.
        private bool UniqueOccurrences(int[] arr, bool debug = false)
        {
            if (arr.Length == 1)
            {
                return true;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>(arr.Length);

            for (int i = 0; i < arr.Length; i++) //O(n) 
            {

                if (!dict.ContainsKey(arr[i]))//O(1)
                {
                    dict.Add(arr[i], 1);//O(1) 
                }
                else
                {
                    dict[arr[i]]++;
                }
            }
            Debug.PrintForDebugDictKvp(dict, debug);

            HashSet<int> hs = new HashSet<int>(dict.Count);

            foreach (var key in dict.Keys)
            {
                if (hs.Contains(dict[key]))
                {
                    return false;
                }
                hs.Add(dict[key]);
            }

            return true;
        }

        //Alternative Linq two-liner.
        private bool UniqueOccurencesLINQ(int[] arr, bool debug = false)
        {
            //This Linq query is practically the previous dictionary in the form of an IEnumerable of anonymous types.
            var enumerables = arr.GroupBy(x => x).Select(group => new { key = group.Key, count = group.Count() });
            //or even
            //var enumerables = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            //debug
            foreach (var item in enumerables)
            {
                Console.WriteLine($"{item.key}:{item.count}");
            }

            return enumerables.Count() == enumerables.GroupBy(x => x.count).Count() ? true : false;
        }
       

    }
}
