using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumber
{
    /// <summary>
    /// 509 - Fibonacci Number
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, <br></br>
    /// such that each number is the sum of the two preceding ones, starting from 0 and 1. That is, <br></br>
    /// F(0) = 0, F(1) = 1 <br></br>
    /// F(n) = F(n - 1) + F(n - 2), for n &gt; 1.<br></br>
    /// Given n, calculate F(n).<br></br>
    /// Constraints:<br></br>
    /// 0 &lt;= n &lt;= 30<br></br>
    /// </summary>
    class Solution
    {

        public Solution()
        {
            for (int i = 0; i < 31; i++)
            {
                var result = Fib(i);
                Console.WriteLine(result);
            }
        }

        //Time O(n), space O(1)
        private int Fib(int n)
        {

            int fibo0 = 0;
            if (n == 0)
            {
                return fibo0;
            }
            int fibo1 = 1;
            if (n == 1)
            {
                return fibo1;
            }
            int temp;
            for (int i = 2; i <= n; i++)
            {
                temp = fibo1;
                fibo1 = fibo0 + fibo1;
                fibo0 = temp;
            }
            return fibo1;
        }
    }
}
