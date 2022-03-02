using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ValidAnagram
{
    
    /// <summary>
    /// 242 - Valid Anagram <br></br>
    /// Given two strings s and t, return true if t is an anagram of s, and false otherwise.<br></br>
    /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,<br></br> 
    /// typically using all the original letters exactly once.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= s.length, t.length &lt;= 5 * 10^4<br></br>
    /// s and t consist of lowercase English letters.<br></br>
    /// Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
    /// </summary>
    class Solution
    {

        public Solution(bool debug)
        {
            TestCases(debug);
        }

        public void TestCases(bool debug)
        {
            //Trivial for Ascii.
            string s = "baggos", t = "ggabos";
            var result = IsAnagram(s, t, debug);
            Debug.PrintForDebug($"{result}\n", debug);
            string s1 = "baγγosü", t1 = "γγabosÜ";
            var result1 = IsAnagramUnicode(s1, t1, debug);
            Debug.PrintForDebug($"{result1}", debug);

        }


        //Assuming that the inputs don't contain unicode characters we can solve this
        //with two collection counters of lowercase english alphabet one for each string.
        //ascii values [a-z]:[97-122]
        //Time: O(n), Space: O(1)
        public bool IsAnagram(string s, string t, bool debug)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            int[] collectionCounterS = new int[26];
            int[] collectionCounterT = new int[26]; //if input string contains any other character in ascii range [0-255]
                                                    //initialize it to new int[256]
            for (int i = 0; i < s.Length; i++)
            {
                collectionCounterS[s[i] - 97]++;
                collectionCounterT[t[i] - 97]++;
            }
            Debug.PrintAlphabetCounters(collectionCounterS, true, debug);
            Debug.PrintForDebug("---", debug);
            Debug.PrintAlphabetCounters(collectionCounterT, true, debug);
            for (int i = 0; i < 26; i++)
            {
                if (collectionCounterS[i] != collectionCounterT[i])
                {
                    return false;
                }
            }

            return true;
        }

        //Assuming that the inputs contain unicode characters we should be able to solve this
        //with two dictionaries
        //Time: O(n) amortized, Space: O(n)
        public bool IsAnagramUnicode(string s, string t, bool debug)
        {

            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> tDict = new Dictionary<char, int>();
            Dictionary<char, int> sDict = new Dictionary<char, int>();

            foreach (var ch in t)
            {
                if (!tDict.ContainsKey(ch))
                {
                    tDict.Add(ch, 1);
                }
                else
                {
                    tDict[ch]++;
                }
            }

            Debug.PrintIEnumerable(tDict, debug);

            foreach (var ch in s)
            {
                if (!sDict.ContainsKey(ch))
                {
                    sDict.Add(ch, 1);
                }
                else
                {
                    sDict[ch]++;
                }
            }

            Debug.PrintIEnumerable(sDict, debug);

            foreach (var ch in s)
            {
                if (!tDict.ContainsKey(ch))
                {
                    return false;
                }

                if (!tDict.ContainsKey(ch) && tDict[ch] != sDict[ch])
                {
                    return false;
                }

            }

            return true;





        }

    }
}
