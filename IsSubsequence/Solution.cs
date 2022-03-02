using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSubsequence
{
    /// <summary>
    /// 392 - IsSubsequence
    /// Given two strings s and t, return true if s is a subsequence of t, or false otherwise. <br></br>
    /// A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) <br></br>
    /// of the characters without disturbing the relative positions of the remaining characters. <br></br>
    /// (i.e., "ace" is a subsequence of "abcde" while "aec" is not).<br></br>
    /// Constraints<br></br>
    /// 0 &lt;= s.length &lt;= 100 <br></br>
    /// 0 &lt;= t.length &lt;= 10^4 <br></br>
    /// s and t consist only of lowercase English letters. <br></br>
    /// Follow up: Suppose there are lots of incoming s, say s1, s2, ..., sk where k &gt;= 10^9,<br></br> 
    /// and you want to check one by one to see if t has its subsequence. In this scenario, how would you change your code?
    /// </summary>
    class Solution
    {


        public Solution()
        {
            var result = IsSubsequenceAdvanced("accae", "abaeedccehhasdaaaccvvvvvasde");
            Console.WriteLine(result);
        }




        //Approach 1: Queue for the candidate subsequence.
        //Time complexity: T(t.length) = O(n)
        //Auxiliary space: O(s.Length) = O(m)

        public bool IsSubsequenceQueue(string s, string t, bool debug = false)
        {

            //if s is empty it is always a subsequence
            if (s.Length == 0)
            {
                return true;
            }

            //if t is empty and s is not, s can never be a subsequence
            if (t.Length == 0 && s.Length != 0)
            {
                return false;
            }


            //if both not empty but t has less characters than s, s can never be a subsequence.
            if (t.Length < s.Length && t.Length > 0 && s.Length > 0)
            {
                return false;
            }

            Queue<char> queue = new Queue<char>(s);

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == queue.Peek())
                {
                    queue.Dequeue();
                }

                if (queue.Count == 0)
                {
                    return true;
                }
            }

            return false;



        }


        //Approach 2: Improvement for auxiliary space.
        //Time complexity: T(t.length) = O(n)
        //Auxiliary space: O(1)

        public bool IsSubsequenceAdvanced(string s, string t, bool debug = false)
        {

            int count = 0;

            for (int i = 0; i < t.Length && count < s.Length; i++)
            {
                if (s[count] == t[i])
                {
                    count++;
                }
            }

            return count == s.Length;
        }


        //The above approach could be problematic for the situation described in the follow up question
        //Suppose i had m: strings to check. The time complexity would be O(m*n)
        //We need something like O(log(n)) so that total time complexity goes to O(mlog(n)) which is preferable.
        //We need some kind of binary search.


        //TODO: look into the binary search solution.


        // Follow-up: 
        // Eg-1. s="abc", t="bahbgdca"
        // idx=[a={1,7}, b={0,3}, c={6}]
        //  i=0 ('a'): prev=1
        //  i=1 ('b'): prev=3
        //  i=2 ('c'): prev=6 (return true)
        // Eg-2. s="abc", t="bahgdcb"
        // idx=[a={1}, b={0,6}, c={5}]
        //  i=0 ('a'): prev=1
        //  i=1 ('b'): prev=6
        //  i=2 ('c'): prev=? (return false)



        public bool IsSubsequence(string s, string t, bool debug)
        {
            //PREPROCESSING

            //Create ascii counter to capture frequencies of all english lowercase letters
            //in t. Time: O(t.length), Space: O(1) 

            int[] lowerEngAscii = new int[26];

            foreach (var c in t)
            {
                lowerEngAscii[c - 97]++;
            }


            //Create dictionary to capture said frequencies in A LIST ordered by ascending index position.
            //Use the frequencies determined before to initialize the lists. Gain: List.Add() -> O(1)
            //Time: O(1), Space: O(26*t.Length)=O(n) I believe.

            Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>(26);

            for (int i = 0; i < 26; i++)
            {
                dict[Convert.ToChar(i + 97)] = new List<int>(lowerEngAscii[i]);
            }

            //Fill the dictionary values (index lists)
            for (int i = 0; i < t.Length; i++)
            {
                dict[t[i]].Add(i);
            }

            //Print to see
            if (debug)
            {
                foreach (var kvp in dict)
                {
                    Console.Write(kvp.Key + ": ");
                    foreach (var item in kvp.Value)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.WriteLine("");
                }
            }


            //END PREPROCESSING

            for (int i = 0; i < t.Length; i++)
            {
                if (dict[t[i]].Count == 0)
                {
                    return false;
                }
                else
                {
                    //TODO: ADD Binary search logic.
                }
            }


            return false;

        }
    }
}
