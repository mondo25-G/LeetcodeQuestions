using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace LongestSubstringWithoutRepeatingCharacters
{
    //https://stackoverflow.com/questions/8269916/what-is-sliding-window-algorithm-examples
    /// <summary>
    /// 3. Longest Substring Without Repeating Characters<br></br>
    /// Given a string s, find the length of the longest substring without repeating characters.<br></br>
    /// Constraints:<br></br>
    /// 0 &lt;= s.length &lt;= 5 * 10^4<br></br>
    /// s consists of English letters, digits, symbols and spaces.
    /// </summary>
    public class Solution
    {
        public delegate int LengthOfLongestSubstringMethods(string s, bool debug);
        public Solution(bool debug)
        {
            Debug.PrintForDebug($"Ascii Table:\n", debug);
            TestCases(LengthOfLongestSubstringAscii, debug);
            Debug.PrintForDebug($"Dictionary:\n", debug);
            TestCases(LengthOfLongestSubstringDictionary, debug);
        }

        public void TestCases(LengthOfLongestSubstringMethods del, bool debug = false)
        {

            var result = del("pwwkewlkasldw2?k123p", debug);
            Debug.PrintForDebug($"Max length of substring with unique chars: {result}\n", debug);

        }

        public delegate int LengthOfLongestSubstringMethod(string s);


        //This is an excellent opportunity to learn/practice sliding window technique.



        //Sliding window technique assuming we talk about ascii characters 
        //Time Complexity O(n) where n= s.Length, space complexity O(m) where m = length of collection counter (ascii=128, extended ascii=256,etc)
        //Reference: https://levelup.gitconnected.com/an-introduction-to-sliding-window-algorithms-5533c4fe1cc7,
        //           https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
        public int LengthOfLongestSubstringAscii(string s, bool debug = false)
        {
            int leftWindow = 0; //the starting index.
            int rightWindow = 0;// rightWindow points to the index the right side. It initially points to 0
                                // because the window only grows in size inside of the loop when it matches
                                //certain conditions.
            int maxLength = 0; //keep track of the longest length of all iterated substrings.

            int[] asciiCounter = new int[128]; //store counts of all 128 ascii characters in string
                                               //if extended ascii => int[256]
                                               //if just lowercase english =>  int[26] etc.
                                               //This collection counter defines the space complexity : in general O(m)

            //Note: an increment condition is not set (no need to use for loop). Because the loop's block
            //will contain the instructions for when to increment leftWindow or rightWindow
            Debug.PrintForDebug($"Semantics: When I \"slide\", I always slide to the right =>", debug);
            while (rightWindow < s.Length)
            {
                Debug.PrintForDebug($"{s}", debug);
                //Now we must set up the conditions  by which the count of a character is incremented.
                //Here the count of the character is incremented when the character is
                //included in the sliding window. so I check my counter for the position of the character
                //which will be s[rightWindow] and increment.
                char right = s[rightWindow];
                asciiCounter[right]++;
                Debug.PrintForDebug($"right: {right} count {asciiCounter[right]}", debug);


                //At this point I set the condition for expansion/contraction of window and slide it.
                //if I find a duplicate from the right I keep sliding the window from the left 
                //until i reduce the number count of "right" to just 1.
                //all the while reducing the count of any "left" character I meet along the way.
                //Important!: The value of the index of "left" ("leftWindow") stays "put" at the end of this loop until I have further need of it.
                while (asciiCounter[right] > 1)  //that is, until I encounter another "right" whose count is gt 1.
                {

                    char left = s[leftWindow];
                    leftWindow++;
                    asciiCounter[left]--;

                    Debug.PrintForDebug($"I Slide the left side of the Window: {leftWindow}\n", debug);
                    Debug.PrintForDebug($"I decrease counts from the left", debug);
                    Debug.PrintForDebug($"left: {left} count {asciiCounter[left]} - right: {right} count {asciiCounter[right]}", debug);

                }

                //Finally, check if the current substring's length is greater that the integer pointed at
                //by maxlength, which represents the longest substring length seen thus far.
                //After that, the window must expand t0 include another character and see if the current
                //substring can grow any larger. Increment rightWindow by 1.
                Debug.PrintForDebug($"I Check the maxLength: {maxLength}", debug);
                maxLength = Math.Max(maxLength, rightWindow - leftWindow + 1);
                Debug.PrintForDebug($"I Reset(?) the maxLength: {maxLength}", debug);
                rightWindow++;
                Debug.PrintForDebug($"I Slide the right side of the Window: {rightWindow}\n", debug);

            }

            return maxLength;

        }


        //Sliding window technique assuming we talk about any unicode characters (a dictionary/hash table is more effective here)
        //Time Complexity O(n) (amortized) where n= s.Length, space complexity O(m) where m = count of dictionary to store the characters
        //Exactly the same procedure.

        public int LengthOfLongestSubstringDictionary(string s, bool debug = false)
        {
            int leftWindow = 0;
            int rightWindow = 0;
            int maxLength = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();


            while (rightWindow < s.Length)
            {
                if (!dict.ContainsKey(s[rightWindow]))
                {
                    dict.Add(s[rightWindow], 1);
                }
                else
                {
                    dict[s[rightWindow]]++;
                }


                while (dict[s[rightWindow]] > 1)
                {
                    dict[s[leftWindow]]--;
                    leftWindow++;
                }

                maxLength = Math.Max(maxLength, rightWindow - leftWindow + 1);
                rightWindow++;
            }
            return maxLength;


        }


    }
}
