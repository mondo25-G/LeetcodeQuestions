using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ReverseString
{
    /// <summary>
    /// 344-Reverse String <br></br>
    /// Write a function that reverses a string. The input string is given as an array of characters s. <br></br>
    /// You must do this by modifying the input array in-place with O(1) extra memory.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= s.length &lt;= 10^5<br></br>
    /// s[i] is a printable ascii character.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }
        private void TestCases(bool debug)
        {
            ReverseString("Leetcoder".ToCharArray(), debug);
            ReverseString("Leetcode".ToCharArray(), debug);
        }

        //Time O(n), auxiliary space O(1).
        private void ReverseString(char[] s, bool debug)
        {
            Debug.PrintIEnumerable(s, debug);
            for (int i = 0; i < s.Length / 2; i++) //O(n) Time : where n =s.Length/2
            {
                var temp = s[s.Length - 1 - i]; //O(1) space
                s[s.Length - 1 - i] = s[i];
                s[i] = temp;
            }
            Debug.PrintIEnumerable(s, debug);
        }
    }
}
