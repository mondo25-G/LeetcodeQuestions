using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace MajorityElement
{
    /// <summary>
    /// 169 - Majority Element <br></br>
    /// Given an array nums of size n, return the majority element.<br></br>
    /// The majority element is the element that appears more than ⌊n / 2⌋ times.<br></br>
    /// You may assume that the majority element always exists in the array.<br></br>
    /// n == nums.length <br></br>
    /// 1 &lt;= n &lt;= 5 * 10^4 <br></br>
    /// -2^31 &lt;= nums[i] &lt;= 2^31 - 1 <br></br>
    /// Follow-up: Could you solve the problem in linear time and in O(1) space?
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }

        public delegate int MajorityElement(int[] nums);
        public void TestCases(bool debug)
        {
            var input = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            Debug.PrintIEnumerable(input, debug);

            Debug.PrintForDebug($"Majority element: {MajorityElementDictionary(input)}", debug);
            Debug.PrintForDebug($"Majority element: {MajorityElementLinq(input)}", debug);
            Debug.PrintForDebug($"Majority element: {MajorityElementTrick(input)}", debug);
        }


        //Dictionary O(n) (amortized) time, O(n) space.
        public int MajorityElementDictionary(int[] nums)
        {
            int majorityElement = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 1);
                }
                else
                {
                    dict[num]++;
                    //With the assumption that the majority element always exists.
                    if (dict[num] > nums.Length / 2)
                    {
                        majorityElement = num;
                    }
                }
            }

            return majorityElement;
        }


        //Functional. I believe Time Complexity O(n), Space Complexity O(n)
        public int MajorityElementLinq(int[] nums)
        {
            return nums.GroupBy(x => x).First(group => group.Count() > nums.Length / 2).Key;
        }

        //TODO: Understand Boyer-Moore Voting Algorithm in MajorityElement.
        /*  Boyer-Moore Voting Algorithm. //O(n) time, O(1) space.
         * 
         * Intuition
         * If we had some way of counting instances of the majority element as +1 and instances of any other element as −1, 
         * summing them would make it obvious that the majority element is indeed the majority element.
         * Algorithm
         * Essentially, what Boyer-Moore does is look for a suffix suf of nums where suf[0]
         * is the majority element in that suffix. To do this, we maintain a count, which is incremented 
         * whenever we see an instance of our current candidate for majority element and decremented 
         * whenever we see anything else. Whenever count equals 0, we effectively forget about everything 
         * in nums up to the current index and consider the current number as the candidate for majority element. 
         * It is not immediately obvious why we can get away with forgetting prefixes of nums 
         * - consider the following examples (pipes are inserted to separate runs of nonzero count).
         * 
         * [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
         * Here, the 7 at index 0 is selected to be the first candidate for majority element. 
         * count will eventually reach 0 after index 5 is processed, so the 5 at index 6 will be the next candidate. 
         * In this case, 7 is the true majority element, so by disregarding this prefix, 
         * we are ignoring an equal number of majority and minority elements - 
         * therefore, 7 will still be the majority element in the suffix formed by throwing away the first prefix.
         * [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 5, 5, 5, 5]
         * Now, the majority element is 5 (we changed the last run of the array from 7s to 5s),
         * but our first candidate is still 7. In this case, our candidate is not the true majority element, 
         * but we still cannot discard more majority elements than minority elements 
         * (this would imply that count could reach -1 before we reassign candidate, which is obviously false).
         * Therefore, given that it is impossible (in both cases) to discard more majority elements than minority elements, 
         * we are safe in discarding the prefix and attempting to recursively solve the majority element problem for the suffix. 
         * Eventually, a suffix will be found for which count does not hit 0, 
         * and the majority element of that suffix will necessarily be the same as the majority element of the overall array.
         * 
         * Assumptions
         * Provided array is not null
         * Provided array is not empty
         * Majority element always exists in provided array
         * Algorithm
         * Loop through the array. At each index i, we treat the array as 2 pieces
         * prefix as [0, i)
         * suffix as [i, end]
         * Main idea: If we don't have the majority element in the prefix, 
         * then the suffix must have a majority element, and this majority element will also be the majority element for the entire array.

         * 
         * 
         */
        public int MajorityElementTrick(int[] nums)
        {

            //It is basically a divide and conquer algorithm that is based on the fact that since there EXISTS a majority element
            //i.e. occure>nums.length/2 times, I can track the occurences of a candidate by +1
            // and changes in values for each candidate by -1, so that when I choose a next candidate, if I have
            //discarded m occurences of the majority element I will have discarded m occurences of minority elements (THIS IS KEY)
            //When I am unable to go to zero count, and choose a I will have found a local majority element which HAS to be the global
            //majority element.
            int count = 0;
            int candidate = new int();

            foreach (int num in nums)
            {
                if (count == 0)
                { // no majority element in prefix
                    candidate = num; // selects new candidate majority element
                }
                count += (num == candidate) ? 1 : -1;
            }

            return candidate;
        }



    }
    }
