using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace FizzBuzz
{
    /// <summary>
    /// 412 - FizzBuzz
    /// Given an integer n, return a string array answer (1-indexed) where: <br></br>
    /// answer[i] == "FizzBuzz" if i is divisible by 3 and 5. <br></br>
    /// answer[i] == "Fizz" if i is divisible by 3. <br></br>
    /// answer[i] == "Buzz" if i is divisible by 5. <br></br>
    /// answer[i] == i(as a string) if none of the above conditions are true.<br></br>
    /// Constraints: <br></br>
    ///1 &lt;= n &lt;= 10^4
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }

        public void TestCases(bool debug)
        {
            FizzBuzz(100, debug);
        }
       
        public IList<string> FizzBuzz(int n, bool debug)
        {

            string[] result = new string[n];
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                {
                    result[i - 1] = "FizzBuzz";
                }
                else if (i % 5 == 0)
                {
                    result[i - 1] = "Buzz";
                }
                else if (i % 3 == 0)
                {
                    result[i - 1] = "Fizz";
                }
                else
                {
                    result[i - 1] = i + "";
                }

            }

            Debug.PrintIEnumerable(result, debug);
            return result;
        }

    }
}
