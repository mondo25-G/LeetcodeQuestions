using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace NthTribonacciNumber
{
    class Solution
    {

        private delegate int NthTribonacciNumberMethods(int n);
        public Solution(bool debug)
        {
            Debug.PrintForDebug($"Memoization with recursion:", debug);
            TestCases(NthTribonacciNumberRecMem, debug);
            Debug.PrintForDebug($"Memoization with iteration:", debug);
            TestCases(NthTribonacciNumberIterMem, debug);
            Debug.PrintForDebug($"Iteration only:", debug);
            TestCases(NthTribonacciNumberIter, debug);
            //Debug.PrintForDebug($"Recursion only:", debug);
            //TestCases(NthTribonacciNumberRec, debug);
        }

        private void TestCases(NthTribonacciNumberMethods del, bool debug)
        {
            for (int i = 0; i <= 37; i++)
            {
                Debug.PrintForDebug($"Tribo {i}: {del(i)}", debug);
            }
        }

        //Recursion only. Very bad.
        //Time exponential, space O(1).
        private int NthTribonacciNumberRec(int n)
        {
            Console.WriteLine();
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 1;
            }
            else
            {
                return NthTribonacciNumberRec(n - 1) + NthTribonacciNumberRec(n - 2) + NthTribonacciNumberRec(n - 3);
            }
        }

        //Recursion and memoization.
        //O(n) time, O(n) space.
        private int NthTribonacciNumberRecMem(int n)
        {
            int[] tribo = new int[n + 3];
            tribo[0] = 0;
            tribo[1] = 1;
            tribo[2] = 1;
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 1;
            }
            else
            {
                return NthTribonacci(n, tribo);
            }

        }

        private int NthTribonacci(int n, int[] tribo)
        {
            if (tribo[n] == 0 && n > 2)
            {
                tribo[n] = NthTribonacci(n - 1, tribo) + NthTribonacci(n - 2, tribo) + NthTribonacci(n - 3, tribo);
            }
            return tribo[n];
        }

        //How does this algorithm work? https://stackoverflow.com/questions/42617249/time-complexity-of-memoization-fibonacci
        /* case n=4
         *              1st check : tribo[4]==0 && 4>2 TRUE
         * (a)           NthTribo(3)                  +                           NthTribo(2)              +               NthTribo(1)
         *              2nd check: tribo[3]==0 && 3>2 TRUE                    tribo[2]==0 && 2>2 FALSE                  tribo[1]==0 && 2>2 FALSE
         *          /        |              \                                     return tribo[2]                           return tribo[1]
         * (b) NthTribo(2)+NthTribo(1) + NthTribo(0)                            and move up to (a)                          and move up to (a)
         *         |               |                |         
         *         |       3rd,4th,5th checks:       |
         *tribo[2]==0 && 2>2 tribo[1]==0 && 1>2 tribo[0]==0 && 0>2                                     
         * FALSE                   FALSE            FALSE               
         * return tribo[2]   return   tribo[1]  return tribo[0]
         *       and move up to (b) as tribo[2]+tribo[1]+tribo[0]
         *        move up to (a)
         *        
         *        First check is true: as a result it makes 3 calls.
         *        Second check is true: as a result it makes 3 more calls. total 6 calls. That is linear. O(n) 
         *        
         *        First call: n=4 => n=3,n=2,n=1
         *        Check n=3 of first call.
         *        Second call: n=3> n=2,n=1,n=0
         *        Third call: n=2: memoized
         *        Fourth call: n=1: memoized
         *        Fifth call:n=0: memoized
         *        Check n=2,n=1 of first call , all memoized/skipped by return values 
         *        O(n+1)=O(n)
         */



        //Iteration and memoization
        //O(n) time, O(n) space.
        private int NthTribonacciNumberIterMem(int n)
        {
            int[] tribos = new int[n + 3];
            tribos[0] = 0;
            tribos[1] = 1;
            tribos[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                tribos[i] = tribos[i - 1] + tribos[i - 2] + tribos[i - 3];
            }
            return tribos[n];

        }

        //Iteration only.
        //O(N) time, O(1) space.
        private int NthTribonacciNumberIter(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n > 0 && n < 3)
            {
                return 1;
            }

            int tribo0 = 0;
            int tribo1 = 1;
            int tribo2 = 1;
            int temp2;
            int temp1;

            for (int i = 3; i <= n; i++)
            {
                temp2 = tribo2;
                tribo2 = tribo0 + tribo1 + tribo2;
                temp1 = tribo1;
                tribo1 = temp2;
                tribo0 = temp1;
            }

            return tribo2;

        }



    }
}
