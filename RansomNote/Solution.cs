using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RansomNote
{
    
    /// <summary>
    /// 383 - Ransom Note <br></br>
    /// Given two stings ransomNote and magazine, return true if ransomNote can be constructed from magazine and false otherwise.<br></br>
    /// Each letter in magazine can only be used once in ransomNote.<br></br>
    /// Constraints: <br></br>
    ///  1 &lt;= ransomNote.length, magazine.length &lt;= 10^5
    ///  ransomNote and magazine consist of lowercase English letters.
    /// </summary>
    public class Solution
    {

        public Solution()
        {
            TestCases();
        }

        private void TestCases()
        {
            var testCases = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("aa","bb"),
                new Tuple<string, string>("aa","aab")
            };
            foreach (var testCase in testCases)
            {
                Console.WriteLine(CanConstruct(testCase.Item1,testCase.Item2));
            }
        }

        /* Time Complexity O(n+m)
         * Space Complexity O(1)
         * Use a simple collection counter instead of dictionary since it is guaranteed that input is in asci [97-122] i.e [a-z]
         */
        private bool CanConstruct(string ransomNote, string magazine)
        {
            int[] collectionCounter = new int[26];
            foreach (var character in magazine)
            {
                collectionCounter[character - 97]++;
            }

            foreach (var character in ransomNote)
            {
                if (collectionCounter[character - 97] > 0)
                {
                    collectionCounter[character - 97]--;
                }
                else
                {
                    return false;
                }
            }


            return true;




        }
    }
}
