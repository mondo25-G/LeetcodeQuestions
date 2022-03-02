using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ClimbingStairs
{
    /// <summary>
    /// 70.Climbing Stairs<br></br>
    /// You are climbing a staircase. It takes n steps to reach the top.<br></br> \
    /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= n &lt;= 45
    /// </summary>
    class Solution
    {
        public delegate int ClimbStairsMethods(int n, bool debug);
        public Solution(bool debug)
        {
            Debug.PrintForDebug($"Memoization with recursion:", debug);
            TestCases(ClimbStairsRecMem, debug);
            Debug.PrintForDebug($"Memoization with iteration:", debug);
            TestCases(ClimbStairsIterMem, debug);
            Debug.PrintForDebug($"Iteration only:", debug);
            TestCases(ClimbStairsIter, debug);
            //Debug.PrintForDebug($"Recursion only:", debug);
            //TestCases(ClimbStairsRec, debug);
        }


        public void TestCases(ClimbStairsMethods del, bool debug)
        {
            for (int i = 1; i < 45; i++)
            {
                Debug.PrintForDebug($"Fibo {i} : {del(i, debug)}", debug);
            }
        }

        //All methods that follow assume that n > 0.

        //General Remarks: Fibonacci (kinda)

        /*  If you write down the possible combinations for n up to 6 say, you' ll see that
        *   It's basically a fibonacci sequence, here every S_n is the sum of the two previous terms of the sequence S_n-1, S_n-2
        *   except for S_1=1 and S_2=2 (in true fibonacci S_2=1).
        */


        //Recursion only. Very bad.
        //Time exponential(2^n),  O(n) depth of recursion tree (look into these , not trivial.)
        //If you try this with simple recursion it blows up exponentially in time complexity.
        //Because for each n it Recalculates all fibos up to n-1, n-2 recursively.
        public int ClimbStairsRec(int n, bool debug = false)
        {
            if (n <= 2)
            {
                return n;
            }
            else
            {
                return ClimbStairsRec(n - 1, debug) + ClimbStairsRec(n - 2, debug);
            }
        }

        //Memoization: A flavor of Dynamic Programming. TOP DOWN technique.

        /*Memoization is a technique for improving the performance of recursive algorithms.
         *It involves rewriting the recursive algorithm so that as answers to problems are found, they are stored in an array.
         *Recursive calls can look up results in the array rather than having to recalculate them
         */

        // Prep Work: Initialize the array that holds the values of the sequence.
        /* i=0 => 0 irrelevant
         * i=1 => fibo[1]=1
         * i=2 => fibo[2]=2
         * i=3 => fibo[3]=0 (to be filled via recursion/iteration)
         * ..
         * ..
         * i=n => fibo[n] =0 (to be filled via recursion/iteration)
         * It is evident why we need to initialize int[n+2], so that we can hold always hold the two initial values of the sequence
         */

        //Recursion and Memoization.        
        //O(n) Time, O(n) Space.
        public int ClimbStairsRecMem(int n, bool debug = false)
        {
            int[] Fibos = new int[n + 2];
            Fibos[1] = 1;
            Fibos[2] = 2;
            return FiboRecMem(n, Fibos);
        }

        public int FiboRecMem(int n, int[] fibos)
        {
            if (fibos[n] == 0)
            {
                fibos[n] = FiboRecMem(n - 1, fibos) + FiboRecMem(n - 2, fibos);
            }
            return fibos[n];
        }

        //How does this recursive algorithm work? https://stackoverflow.com/questions/42617249/time-complexity-of-memoization-fibonacci
        /* Case: n=4 
         * Initialization: fibos[0]=0, fibos[1]=1, fibos[2]=2, fibos[3]=?(0), fibos[4]=?0
         * 
         * (1)first check true: Two calls.
         * fibos[4]==0 true => fibos[4]=Fibo[3,fibos]           +      Fibo(2,fibos)
         *                                   /                                  \   
         * (2) second check true: two more calls                                 \
         * fibos[3]==0 true fibos[3]=Fibo[2,fibos]+Fibo[1,fibos]                   \
         *                               /           \                              \
         *            check call to Fibo[2,fibos]     \                              \
         * fibos[2]==0 false :return fibos[2]=2       check call to Fibo[1,fibos]     \
         *             go back to (2)             fibos[1]==0 false :return fibos[1]=1 \
         *                     \                   go back to(2)                        \
         *                      \                   /                            check call to Fibo[2,fibos]
         *                       \                 /                            fibos[2]==0 false :return fibos[2]=2
         *                       go back to (1) since fibos[3]!=0                      go back to (1)
         *                                                                              
         *        Total calls: 4 = n. therefore O(n) time    
         *        First call :n=4 at start => n=3 n=2
         *        Second call:n=3 => n=2 n=1
         *        Third call :n=2 => memoized
         *        Fourth cal :n=1 => memoized
         *        
         */


        //Iteration and Memoization.        
        //O(n) Time, O(n) Space.

        public int ClimbStairsIterMem(int n, bool debug = false)
        {
            int[] Fibos = new int[n + 2];
            Fibos[1] = 1;
            Fibos[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                Fibos[i] = Fibos[i - 1] + Fibos[i - 2];
            }
            return Fibos[n];
        }

        //Iteration only. Optimal Approach. Ditch memoization table altogether
        //O(n) Time, O(1) Space.

        public int ClimbStairsIter(int n, bool debug = false)
        {
            int temp;
            int fibo1 = 1;
            int fibo2 = 2;
            for (int i = 3; i <= n; i++)
            {
                temp = fibo2;
                fibo2 = fibo1 + fibo2;
                fibo1 = temp;
            }
            return n == 1 ? fibo1 : fibo2;
        }


        //Bonus Solutions: Matrix Multiplication or a (slightly modified) fibonacci formula can solve this on O(log(n))
        //But these are very specific mathematical implementations that no one expects you to know.

        // 509. Fibonacci Number solved exactly the same way.
        //Similar: 91.Decode Ways, 62. Unique Paths, 1137 - Nth Tribonacci, MinCostClimbing Stairs.
    }
}
