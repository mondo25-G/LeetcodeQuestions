using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace WordPattern
{
    /// <summary>
    /// Problem - 209 Word Pattern. <br></br>
    /// Given a pattern and a string s, find if s follows the same pattern.  <br></br>
    /// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.  <br></br>
    /// Constraints.  <br></br>
    /// 1 &lt;= pattern.length &lt;= 300  <br></br>
    /// pattern contains only lower-case English letters.  <br></br>
    /// 1 &lt;= s.length &lt;= 3000  <br></br>
    /// s contains only lowercase English letters and spaces ' '.  <br></br>
    /// s does not contain any leading or trailing spaces.  <br></br>
    /// All the words in s are separated by a single space.
    /// 
    /// </summary>
    /// 


    /// Input: pattern = "abba", s = "dog cat cat dog" => "a-b-b-a" check 
    /// Output: true
    /// 
    /// Input: pattern = "abba", s = "dog cat cat fish" =>  "a-b-b-c" not check
    /// Output: false
    /// 
    /// Input: pattern = "aaaa", s = "dog cat cat dog" => "a-b-b-a" not check
    /// Output: false
    public class Solution
    {

        public Solution()
        {
            TestCases();
        }

        //TODO: Refactor WordPattern, maybe reduce number of variables.
        //Time: O(max(s.Length,pattern.Length))
        //Space: O(max(s.Length,pattern.Length))
        public bool WordPattern(string pattern, string s, bool debug)
        {
            Debug.PrintForDebug($"---\n", debug);
            Debug.PrintForDebug($"Pattern:{pattern} String:{s}\n", debug);

            string[] wordList = s.Split(' ');//O(s.length)

            //Hashsets for words in string, and chars in pattern
            var wordHashsetList = new HashSet<string>(wordList).ToList();
            var patternHashsetList = new HashSet<char>(pattern).ToList();

            //Is there a way to solve this without hardcoding these exceptions?
            if (wordHashsetList.Count != patternHashsetList.Count) //Obviously, saves a lot of trouble. 
            {
                return false;
            }
            if (wordHashsetList.Count == patternHashsetList.Count) //This is a very tricky one, to catch cases like pat="ccc" s="ss sss s ss"
            {
                if (wordHashsetList.Count == 1 && wordList.Length != pattern.Length)
                {
                    return false;
                }
            }


            var dict = new Dictionary<string, char>(pattern.Length);

            for (int i = 0; i < patternHashsetList.Count; i++)
            {
                dict.Add(wordHashsetList[i], patternHashsetList[i]);
            }

            Debug.PrintForDebugDictKvp(dict, debug);

            StringBuilder sbWords = new StringBuilder(wordList.Length);
            StringBuilder sbPattern = new StringBuilder(wordList.Length);
            int count = -1;
            for (int i = 0; i < wordList.Length; i++)
            {
                count++;                   //I append single characters so O(1).
                sbWords.Append(dict[wordList[i]]);//O(1) 
                sbPattern.Append(pattern[count]);//O(1)
                if (sbWords[i] != sbPattern[i])
                {
                    return false;
                }
                if (count == pattern.Length - 1)
                {
                    count = 0;
                }
            }

            //string stringWrtPattern = sbWords.ToString();
            //string wordPatternTo = sbWords.ToString();
            //Debug.PrintForDebug($"String in terms of Pattern {stringWrtPattern}",debug);



            return true;
        }


        public void TestCases()
        {
            var testCases = new List<string[]>
            {
                new string[]{"abbac","cat dog dog horse"},
                new string[]{"abbaa","cat dog dog horse"},
                new string[]{"abbac","cat dog dog horse"},
                new string[]{"abbacef","cat dog dog horse"},
                new string[]{"abbac","cat dog"},
                new string[]{"abbc", "cat dog dog horse cat dog dog horse" },
                new string[]{ "abbcabbc", "cat dog dog horse cat dog dog horse" },
                new string[]{"aaa","aa aa aa aa"},
                new string[]{"aaaa","aa aa aa aa"},
                new string[]{"a","b"},
                new string[]{"ccc","aa aa aa aa"},
                new string[]{"cccc","aa aa aa aa"},
            };

            foreach (var testCase in testCases)
            {
                Console.WriteLine(WordPattern(testCase[0], testCase[1], true));
            }

        }
    }
}
