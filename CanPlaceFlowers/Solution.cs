using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace CanPlaceFlowers
{
    /// <summary>
    /// 605 - You have a long flowerbed in which some of the plots are planted, and some are not. <br></br>
    /// However, flowers cannot be planted in adjacent plots.<br></br>
    /// Given an integer array flowerbed containing 0's and 1's, where 0 means empty and <br></br>
    /// 1 means not empty, and an integer n, return if n new flowers can be planted in the <br></br>
    /// flowerbed without violating the no-adjacent-flowers rule.<br></br>
    /// Constraints:<br></br>
    /// 1 &lt;= flowerbed.length &lt;= 2 * 10^4 <br></br>
    /// flowerbed[i] is 0 or 1.<br></br>
    /// There are no two adjacent flowers in flowerbed.<br></br>
    /// 0 &lt;= n &lt;= flowerbed.length<br></br>
    /// </summary>
    public class Solution
    {
        public Solution()
        {
            TestCases(true);
        }

        //TODO: Try to find more elegant solution.
        //Time: O(m) where m=flowerbed.Length, Auxiliary Space O(1).
        public bool CanPlaceFlowers(int[] flowerbed, int n, bool debug = false)
        {

            Debug.PrintForDebug(flowerbed, debug);
            Debug.PrintForDebug($"Plant {n} flowers", debug);
            if (n == 0)
            {
                return true;
            }

            if (flowerbed.Length == 1 || flowerbed.Length == 2)
            {
                if (flowerbed.Sum() == 0 && n == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 1; i <= flowerbed.Length - 1; i++)
            {
                if (i == 1 && flowerbed[i - 1] == 0 && flowerbed[i] == 0)
                {
                    n--;
                    if (n == 0)
                    {
                        flowerbed[i - 1] = 1;
                        Debug.PrintForDebug(flowerbed, debug);
                        return true;
                    }
                    flowerbed[i - 1] = 1;
                }


                if (flowerbed[i - 1] == 0 && flowerbed[i] == 0 && flowerbed[i + 1] == 0)
                {
                    n--;
                    if (n == 0)
                    {
                        flowerbed[i] = 1;
                        Debug.PrintForDebug(flowerbed, debug);
                        return true;
                    }
                    flowerbed[i] = 1;
                }


                if (i == flowerbed.Length - 2 && flowerbed[i] == 0 && flowerbed[i + 1] == 0)
                {
                    n--;
                    if (n == 0)
                    {
                        flowerbed[i + 1] = 1;
                        Debug.PrintForDebug(flowerbed, debug);
                        return true;
                    }
                    flowerbed[i + 1] = 1;
                }

            }
            Debug.PrintForDebug(flowerbed, debug);
            return false;
        }


        public void TestCases(bool debug = false)
        {
            var testCases = new List<int[]> {
            new int[] { 1, 0, 0, 1, 0, 0 },new int[] { 1, 0, 0, 1, 0, 0 },new int[] { 1, 0, 0, 1, 0, 0 },new int[] { 1, 0, 0, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0 },new int[] { 0, 0, 0, 0, 0, 0 },new int[] { 0, 0, 0, 0, 0, 0 },new int[] { 0, 0, 0, 0, 0, 0 },
            new int[] { 1, 0, 0,0, 0, 1 },new int[] { 1, 0, 0,0, 0, 1 },new int[] { 1, 0,0, 0, 0, 1 },new int[] { 1, 0, 0,0, 0, 1 },
            new int[] { 1, 0, 0, 0, 1 },new int[] { 1, 0, 0, 0, 1 },new int[] { 1, 0, 0, 0, 1 },new int[] { 1, 0, 0, 0, 1 },
            new int[] {1}, new int[] {1}, new int[] {1},
            new int[] {0}, new int[] {0}, new int[] {0},
            new int[] { 0, 0, 1, 0, 0 },new int[] { 0, 0, 1, 0, 0 },new int[] { 0, 0, 1, 0, 0 },new int[] { 0, 0, 1, 0, 0 },
            new int[] { 1, 0, 1, 0, 1 },new int[] { 1, 0, 1, 0, 1 },new int[] { 1, 0, 1, 0, 1 },new int[] { 1, 0, 1, 0, 1 },
            new int[] { 1, 0, 1, 0, 1,0 },new int[] { 1, 0, 1, 0, 1,0 },new int[] { 1, 0, 1, 0, 1,0 },new int[] { 1, 0, 1, 0, 1,0 },
            new int[] { 1, 0, 1, 0, 1,0 },new int[] { 1, 0, 1, 0, 1,0 },new int[] { 1, 0, 1, 0, 1,0 },new int[] { 1, 0, 1, 0, 1,0 },
            };
            //{ 1, 0, 0, 1, 0, 0 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[0], 0, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[1], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[2], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[3], 3, debug));
            Console.WriteLine("Next TestCase");
            //{0, 0, 0, 0, 0, 0} OK
            Console.WriteLine(CanPlaceFlowers(testCases[4], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[5], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[6], 3, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[7], 4, debug));
            Console.WriteLine("Next TestCase");
            //{ 1, 0, 0, 0, 0,1 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[8], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[9], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[10], 3, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[11], 4, debug));
            Console.WriteLine("Next TestCase");
            //{ 1, 0, 0, 0,1 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[12], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[13], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[14], 3, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[15], 4, debug));
            Console.WriteLine("Next TestCase");
            //{ 1 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[16], 0, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[17], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[18], 2, debug));
            Console.WriteLine("Next TestCase");
            //{ 0 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[19], 0, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[20], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[21], 2, debug));
            Console.WriteLine("Next TestCase");
            //{  0, 0, 1, 0, 0 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[22], 0, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[23], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[24], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[25], 3, debug));
            Console.WriteLine("Next TestCase");
            //{  1, 0, 1, 0, 1 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[26], 0, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[27], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[28], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[29], 3, debug));
            Console.WriteLine("Next TestCase");
            //{  1, 0, 1, 0, 1,0 } OK
            Console.WriteLine(CanPlaceFlowers(testCases[30], 0, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[31], 1, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[32], 2, debug));
            Console.WriteLine("Next TestCase");
            Console.WriteLine(CanPlaceFlowers(testCases[33], 3, debug));
            Console.WriteLine("Next TestCase");





        }

    }
}
