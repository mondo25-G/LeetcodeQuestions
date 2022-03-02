using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace HappyNumber
{
    //FANTASTIC PROBLEM (DIFFICULT)
    
    /// <summary>
    /// 202.Happy Number: <br></br>
    /// A happy number is a number defined by the following process:  <br></br> 
    /// Starting with any positive integer, replace the number by the sum of the squares of its digits.<br></br>
    /// Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.<br></br>
    /// Those numbers for which this process ends in 1 are happy.<br></br>
    /// Return true if n is a happy number, and false if not.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= n &lt;= 2^31 - 1
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }

        public void TestCases(bool debug)
        {
            for (int i = 0; i <= 100; i++)
            {
                Debug.PrintForDebug("TESTCASE START:", debug);
                bool result = IsHappy(i, debug);
                Debug.PrintForDebug($"Number: {i} is happy: {result}", debug);
                Debug.PrintForDebug("TESTCASE END\n\n", debug);
            }



            Debug.PrintForDebug("TESTCASE START:", debug);
            bool result1 = IsHappy(1563712132, debug);
            Debug.PrintForDebug($"Number: {1563712132} is happy: {result1}", debug);
            Debug.PrintForDebug("TESTCASE END\n\n", debug);
        }
        //TODO: replace algorithm for extracting digits from a number Everywhere in the correct way as in HappyNumber.

        //Initial Attempt. Using Hashset.
        public bool IsHappyInitial(int n, bool debug)
        {
            HashSet<int> hashSet = new HashSet<int>();

            return RecursiveHappy(n, hashSet, debug);
        }

        public bool RecursiveHappy(int n, HashSet<int> hashSet, bool debug)
        {
            int sum = 0;
            while (n > 0)
            {
                var digit = n % 10;
                sum += digit * digit;
                Debug.PrintForDebug($"digit: {digit}", debug);
                n /= 10;
            }
            Debug.PrintForDebug($"sum of squared digits is {sum}\n", debug);
            if (sum == 1)
            {
                Debug.PrintForDebug("Check the hashset", debug);
                Debug.PrintIEnumerable(hashSet, debug);
                return true;
            }
            else
            {
                if (!hashSet.Contains(sum))
                {
                    hashSet.Add(sum);
                    Debug.PrintForDebug("Check the hashset", debug);
                    Debug.PrintIEnumerable(hashSet, debug);
                    n = sum;
                    return RecursiveHappy(n, hashSet, debug);
                }
                else
                {
                    Debug.PrintForDebug($"Duplicate in hashset:{sum}", debug);
                    return false;
                }



            }
        }


        //Refactored Everything. Using Hashset.      

        //Time O(log(n)), space O(log(n)). See https://leetcode.com/problems/happy-number/solution/ for detailed explanation, on :
        //a) why this process can either end in 1 or get stuck in a loop, and cannot keep going higher and higher infinitely.
        //b) why the complexities are such.
        public bool IsHappy(int n, bool debug)
        {

            HashSet<int> hashSet = new HashSet<int>();
            while (n != 1 && !hashSet.Contains(n))
            {
                hashSet.Add(n);
                Debug.PrintForDebug("Check the hashset", debug);
                Debug.PrintIEnumerable(hashSet, debug);
                n = SumSquareDigits(n, debug);
            }
            return n == 1;
        }

        //Time O(log(n)), space: O(1)
        public int SumSquareDigits(int n, bool debug)
        {
            int sum = 0;
            while (n > 0)
            {
                var digit = n % 10;
                sum += digit * digit;
                Debug.PrintForDebug($"digit: {digit}", debug);
                n /= 10;
            }
            Debug.PrintForDebug($"sum of squared digits is {sum}\n", debug);
            return sum;
        }

        //TODO see floyd's cycle finding algorithm approach in O(log(n)) time, O(1) space for the same problem (Happy Number)

        public bool IsHappyFloyd(int n, bool debug)
        {
            int slowRunner = n;
            int fastRunner = SumSquareDigits(n, debug);
            while (fastRunner != 1 && slowRunner != fastRunner)
            {
                slowRunner = SumSquareDigits(slowRunner, debug);
                fastRunner = SumSquareDigits(SumSquareDigits(fastRunner, debug), debug);
            }
            return fastRunner == 1;
        }
    }
}
