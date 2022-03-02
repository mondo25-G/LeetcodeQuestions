using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ValidPalindrome
{
    //Take care : to consider if it is a palindrome you must take into account letters (in lowercase) AND numbers
    /// <summary>
    /// 125. Valid Palindrome<br></br>
    /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-<br></br>
    /// alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and<br></br>
    /// Given a string s, return true if it is a palindrome, or false otherwise.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= s.length &lt;= 2 * 10^5<br></br>
    /// s consists only of printable ASCII characters.
    /// </summary>
    class Solution
    {
        public delegate bool IsPalindromeMethods(string s, bool debug);
        public Solution(bool debug)
        {
            TestCases(IsPalindromeStringBuilder, debug);
            Debug.PrintForDebug("------", debug);
            TestCases(IsPalindromeTwoPointers, debug);
        }


        public void TestCases(IsPalindromeMethods del, bool debug)
        {
            List<string> testCases = new List<string>
            {
                "A man, a plan, a canal: Panama",
                 "race a car",
                 "0A",
                 "ll8h ,8-l- l  ",
                 "88lh ,l-8- 8  ",
                 "12 32 1a ",
                 "12a-- 32 1a ",
                 "a12-- 32 1a ",

            };

            foreach (var testCase in testCases)
            {
                Debug.PrintForDebug($"String: \'{testCase}\' is a Palindrome", debug);
                bool result = del(testCase, debug);
                Debug.PrintForDebug($"{result}", debug);
            }


        }


        //Assuming that it is comprised of ascii characters only.
        //Time: O(n) always, Space: O(n).
        public bool IsPalindromeStringBuilder(string s, bool debug)
        {
            if (s == null || s.Length == 0)
            {
                return true;
            }

            int capacity = 0;

            foreach (var character in s)
            {
                if ((character >= 97 && character <= 122) || (character >= 65 && character <= 90) || (character >= 48 && character <= 57))
                {
                    capacity++;
                }
            }
            StringBuilder sb = new StringBuilder(capacity);

            foreach (var character in s)
            {
                if (character >= 97 && character <= 122 || (character >= 48 && character <= 57))
                {
                    sb.Append(character);
                }

                if (character >= 65 && character <= 90)
                {
                    sb.Append((char)(character + 32));
                }
            }
            Debug.PrintForDebug(sb.ToString(), debug);
            for (int i = 0; i < sb.Length / 2; i++)
            {
                if (sb[i] != sb[sb.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;


        }


        //If it is comprised of any unicode characters.
        //Time: O(n) always, Space: O(n).
        public bool IsPalindromeStringBuilder2(string s, bool debug)
        {

            if (s == null || s.Length == 0)
            {
                return true;
            }

            int capacity = 0;

            foreach (var character in s)
            {
                if (char.IsLetterOrDigit(character))
                {
                    capacity++;
                }
            }
            StringBuilder sb = new StringBuilder(capacity);
            foreach (var character in s)
            {
                if (char.IsLetterOrDigit(character))
                {
                    sb.Append(char.ToLower(character));
                }
            }


            Debug.PrintForDebug(sb.ToString(), debug);
            for (int i = 0; i < sb.Length / 2; i++)
            {
                if (sb[i] != sb[sb.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;


        }







        //The above method can be optimized with two pointers technique to check for palidrome for any unicode character.
        //Time: O(n) always, Space O(1).
        public bool IsPalindromeTwoPointers(string s, bool debug)
        {
            if (s == null || s.Length == 0)
            {
                return true;
            }

            int i = 0;
            int j = s.Length - 1;

            while (i < j) //While the left character index is less than the right character index
            {           //This guarantees that we check for palidromes, and it captures the case where s.length = odd.
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }
                if (char.IsLetterOrDigit(s[i]) && char.IsLetterOrDigit(s[j]) && char.ToLower(s[i]) != char.ToLower(s[j]))
                {
                    return false;
                }
                if (char.IsLetterOrDigit(s[i]) && char.IsLetterOrDigit(s[j]) && char.ToLower(s[i]) == char.ToLower(s[j]))
                {
                    i++;
                    j--;
                }
            }

            return true;


        }
    }
}
