using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace PalindromeNumber
{
    /// <summary>
    /// Problem 9 - Given an integer x, return true if x is palindrome integer.
    /// An integer is a palindrome when it reads the same backward as forward.
    /// For example, 121 is a palindrome while 123 is not.
    /// Constraints:
    /// -2^31 <= x <= 2^31 - 1
    /// </summary>     
    public class Solution
    {

        public Solution(bool debug)
        {
            TestCases(debug);
        }

        private void TestCases(bool debug)
        {
            var testCases = new List<int> { 121, -121, 10 };
            foreach (var testCase in testCases)
            {
                var result = IsPalindrome(testCase, debug);
                Console.WriteLine($"Is palindrome: {result}");
            }
        }

        /// <summary>
        /// Determines whether an integer is a palindrome or not.<br></br>
        /// Time: O(log(x)) Space: O(1).
        /// </summary>
        /// <param name="x">the integer to check</param>
        /// <param name="debug">boolean to print debug info</param>
        /// <returns>true if palindrome, false if not</returns>
        public bool IsPalindrome(int x, bool debug = false)
        {
            Debug.PrintForDebug($"Input {x}", debug);

            //Input: x = -121
            // Output: false
            //Explanation: From left to right, it reads - 121.From right to left, it becomes 121 -.Therefore it is not a palindrome.

            if (x < 0) //Didn't catch that -121 => 121-, exclude negatives
            {
                return false;
            }


            int numL = x;
            int length = 0;
            do //do-while to get correct length for zero.
            {
                numL /= 10;
                length++;
            } while (numL > 0);//O(log(x)) (base 10)

            Debug.PrintForDebug($"Number Length {length}", debug);

            int divisorReverse = 1;
            int divisorProper = (int)Math.Pow(10.0, length - 1);//Is it O(1) or O(log(x) (base 10)? Havent found definitive answer.
                                                                //But in Java is O(1) so it should be safe to assume it is O(1) here as well.
                                                                //.NET actually makes an external call to .Pow() fro C++, and that method runs
                                                                //in O(1) in x86 which is the most common architecture, so there it is I guess. 
            while (length > 0) //O(log(x))  (base 10)
            {

                var digitReverse = (x / divisorReverse) % 10;
                var digitProper = (x / divisorProper) % 10;
                Debug.PrintForDebug($"Digit {digitProper} Reverse Digit {digitReverse}", debug);
                if (digitProper != digitReverse)
                {
                    return false;
                }
                divisorReverse *= 10;
                divisorProper /= 10;
                length--;
            }

            return true;
        }

    }
}
