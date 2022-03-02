using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ReverseInteger
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked
    /// <summary>
    /// 7 - Reverse Integer
    /// Given a signed 32-bit integer x, return x with its digits reversed. 
    /// If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0. 
    /// </summary>
    /// <remarks>Assume the environment does not allow you to store 64-bit integers(signed or unsigned)<br></br>.
    /// This means that I cannot cast to long to avoid integer overflow. So I need to run the while loop in CHECKED mode
    /// otherwise the overflow won't be caught during runtime.
    /// </remarks>
    public class Solution
    {
        public Solution(bool debug)
        {
            Console.WriteLine(ReverseInteger(-800098,true));
        }
        /// <summary>
        /// Reverses a signed 32-bit integer <paramref name="x"/>. <br></br>
        /// Time: O(log(x)) There are roughly log10(x) digits in |x|. Space: O(1).
        /// </summary>
        /// <param name="x"> a signed 32-bit integer </param>
        /// <returns><paramref name="x"/> with its digits reversed or zero <br></br>
        /// if reversing <paramref name="x"/> causes the value to go outside the signed 32-bit integer range.</returns>
        public int ReverseInteger(int x, bool debug = false)
        {
            Debug.PrintForDebug($"Proper {x}", debug);//For Debug only
            int absNumL = 0;
            try
            {
                absNumL = Math.Abs(x);
            }
            catch (OverflowException e)
            {
                Debug.PrintForDebug("CAUGHT: " + e.ToString() + "\nTREATED.", debug);//For Debug only
                return 0;
            }

            int length = 0;
            while (absNumL > 0) //O(log(x))
            {
                absNumL /= 10;
                length++;
            }

            int reverse = 0;
            int divisor = 1;
            int absNumR = Math.Abs(x);

            while (length > 0) //O(log(x))  
            {

                var digit = (absNumR / divisor) % 10;
                checked
                {
                    try
                    {
                        reverse = reverse * 10 + digit;

                    }
                    catch (OverflowException e)
                    {

                        Debug.PrintForDebug("CAUGHT: " + e.ToString() + "\nTREATED.", debug);//For Debug only
                        return 0;
                    }
                }
                divisor *= 10;
                length--;
            }
            reverse = x < 0 ? -reverse : reverse;
            return reverse;



        }
    }
}
