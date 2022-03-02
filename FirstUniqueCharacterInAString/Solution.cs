using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace FirstUniqueCharacterInAString
{
    /// <summary>
    /// 387. First Unique Character in a String<br></br>
    /// Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= s.length &lt;= 10^5
    /// s consists of only lowercase English letters.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }
        public void TestCases(bool debug)
        {
            var testCases = new List<string> { "leetcode", "roaring", "s", "mmmoommmaaa", "anna", "annabelle", "aadadaad" };


            foreach (var testCase in testCases)
            {
                Debug.PrintForDebug($"String: {testCase}", debug);
                int result = FirstUniqChar(testCase, debug);
                Debug.PrintForDebug($"First Unique character at index {result}\n", debug);
            }


        }

        //With collection counter, Time O(n), Space O(1). (ascii 97-122 :a-z)
        public int FirstUniqChar(string s, bool debug = false)
        {

            int[] colCounter = new int[26];

            //initialize every value of the lowercase alphabet collection to last index of string PLUS ONE.
            for (int i = 0; i < 26; i++)//Time: O(26)
            {
                colCounter[i] = s.Length;
            }

            //For each string letter,
            for (int i = 0; i < s.Length; i++) //Time O(n)
            {
                //if its value in the lowercase alphabet collection is last index of string PLUS ONE, i.e. you meet it for
                //the first time, store its index.
                if (colCounter[s[i] - 97] == s.Length)
                {
                    colCounter[s[i] - 97] = i;
                }
                else //If it's not, then you must have met it before, so INCREMENT IT ABOVE STRING LENGTH.
                //If you simply reset it to string length you will encounter errors for cases like "aadadaad"
                {
                    colCounter[s[i] - 97] = s.Length + 1; ;
                }
            }

            Debug.PrintAlphabetCounters(colCounter, true, debug);

            //That way it is guaranteed that the minimum value stored, will be the index of the first non-repeating character--
            int index = colCounter.Min(); //Time: O(26)

            //--unless it doesn't exist, in which case every value stored will be greater than or equal to the 
            //last index of string PLUS ONE
            //so you have to return -1.
            return index >= s.Length ? -1 : index;
        }





    }
}
