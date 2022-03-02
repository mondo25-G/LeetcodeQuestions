using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace LongestCommonPrefix
{
    /// <summary>
    /// PROBLEM 14 - Write a function to find the longest common prefix (LCP) string amongst an array of strings.<br></br>
    /// If there is no common prefix, return an empty string "".<br></br>
    /// CONSTRAINTS:<br></br>
    /// 1 &lt;= strs.length &lt;= 200 <br></br>
    /// 0 &lt;= strs[i].length &lt;= 200<br></br>
    /// strs[i] consists of only lower-case English letters.
    /// </summary>
    class Solution
    {
        public Solution()
        {
            TestCases(true);
        }

        public void TestCases(bool debug)
        {
            //Do experimentations with strings
            List<string[]> testCases = new List<string[]> { new string[] { "a" }, new string[] { "" }, new string[] { "flow", "floew", "flow", "flower" }, new string[] { "dog", "racecar", "car" } };


            foreach (var testCase in testCases)
            {
                Console.WriteLine($"LCP: {LongestCommonPrefix(testCase, debug)}");
                Console.WriteLine("---");
            }
        }
        //https://stackoverflow.com/questions/59484131/what-is-the-runtime-and-space-complexity-of-this-program  STRINGBUILDER
        //Time O(n*m) Space O(m). n=strs.Length, m=min(strs[i].Length)
        //In the worst case all str[i] have the same number of characters m, making the total time complexity
        //O(number of strings X m characters per string) = O(S) where S is the sum of all characters in all strings.
        public string LongestCommonPrefix(string[] strs, bool debug = false)
        {

            //catch case where strs contains just one str.
            if (strs.Length == 1)
            {
                return strs[0];
            }


            //find minimum length of all str contained in strs, because that will be the maximum LCP between them
            int min = Int32.MaxValue;
            for (int j = 0; j < strs.Length; j++) //Time: O(n), n.Strs.Length
            {
                if (strs[j].Length < min)
                {
                    min = strs[j].Length;
                }
            }

            //cath null str.
            if (min == 0)
            {
                return "";
            }


            //loop efficiently between all str contained in strs, for every character position up to max LCP length (min)
            //and construct LCP via the stringbuilder. Do not return the stringbuilder inside the loops to avoid computational cost.
            StringBuilder sb = new StringBuilder(min); //Space : O(min), 
                                                       //alternatively, you can choose not to set the capacity and save memory,
                                                       //but pay a time cost in loops for .Append whenever sb needs to allocate more space
                                                       //Making the total time complexity O(m*n) but we talk AMORTIZED time complexity in this case.
                                                       //If I didn't have a specific constraint for each string length as i do here (200 chars)
                                                       //I would have chosen the second approach. As it stands I have minimal space cost.
                                                       //Since worst case space complexity is O(200)
                                                       //keep count for each char str[i]. 
            int count = 1; //you check for each j its previous one j-1 as well, so set it to 1.
            for (int i = 0; i < min; i++)//O(min) - Outer loop for LCP length
            {
                for (int j = 1; j < strs.Length; j++)//O(n), n=>Strs.Length - Inner loop for strs in str
                {
                    Debug.PrintForDebug($"{strs[j - 1][i]} {strs[j][i]} {count}", debug);
                    if (strs[j - 1][i] != strs[j][i]) //if each str[i] is different between adjacent strs[j-1], strs[j]
                    {
                        if (sb.Length == 0) //if sb is empty exit with null string.
                        {
                            return "";
                        }
                        else //id sb is not empty, you must stop here and return the string builder
                        {
                            count = -1; //trick for GOTO
                            break; // break:1 go to break:2
                        }
                    }
                    else
                    {
                        count = count + 1; //else increase counter.
                    }
                    Debug.PrintForDebug($"{strs[j - 1][i]} {strs[j][i]} {count} \n-----", debug);
                    if (count == strs.Length) //if character in i-th string position str[i] present in all strings strs[j]
                    {
                        sb.Append(strs[j][i]); //append to sb
                        count = 1; //reset counter
                    }
                }
                if (count == -1) //this is GOTO(2)
                {
                    break; //exit with the stringbuilder constructed up to break:1
                }


            }

            return sb.ToString();//O(min) -- return LCP.



        }
    }
}
