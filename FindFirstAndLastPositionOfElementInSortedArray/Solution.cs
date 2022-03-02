using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace FindFirstAndLastPositionOfElementInSortedArray
{
    /// <summary>
    /// 34 -Find First And Last Position Of Element In Sorted Array
    /// Given an array of integers nums sorted in non-decreasing order, <br></br>
    /// find the starting and ending position of a given target value. <br></br>
    /// If target is not found in the array, return [-1, -1]. <br></br>
    /// You must write an algorithm with O(log n) runtime complexity. <br></br>
    /// Constraints<br></br>
    /// 0 &lt;= nums.length &lt;= 10^5
    /// -10^9 &lt;= nums[i] &lt;= 10^9
    /// nums is a non-decreasing array.
    /// -10^9 &lt;= target &lt;= 10^9
    /// </summary>
    class Solution
    {

        public Solution()
        {
            TestCases();
        }

        private void TestCases()
        {
            var testCases = new List<Tuple<int[],int>> {
                new Tuple<int[],int>(new int[] { 5, 7, 7, 8, 8, 10 },8),
                new Tuple<int[],int>(new int[] { 5, 7, 7, 8, 8, 10 },6),
                new Tuple<int[],int>(new int[] { },0)
            };

            foreach (var testCase in testCases)
            {
                Debug.PrintIEnumerable(testCase.Item1, true);
                Debug.PrintForDebug($"Target: {testCase.Item2}", true);
                var result = SearchRangeSortedAsc(testCase.Item1, testCase.Item2);
                Debug.PrintIEnumerable(result, true);
                Console.WriteLine("----");

            }
        }

        private static int[] SearchRangeSortedAsc(int[] nums, int target)
        {
            //TrivialCases O(1) inserted to avoid unecessary call to Array.BinarySearch (O(log(n))
            int[] trivial = TrivialCases(nums, target);
            if (trivial.Length == 2)
            {
                return trivial;
            }

            int randomOccurence = Array.BinarySearch(nums, target); //O(log(n)
            if (randomOccurence < 0) //If standard binary search can't find target.
            {
                Console.WriteLine("Target not Found");
                return new int[2] { -1, -1 };
            }
            else
            {
                Console.WriteLine($"Found target {target} at random index {randomOccurence}");
                //TrivialCasesBinarySearch O(1) is inserted to spped up method SearchRangeSortedAsc
                //BinarySearchFirstOccurence/BinarySearchLastOccurence O(log(n)) cover these cases.
                int[] trivialBinary = TrivialCasesBinarySearch(nums, randomOccurence, target);
                if (trivialBinary.Length == 2)
                {
                    return trivialBinary;
                }
                else
                {
                    //All trivial cases covered, and I now, need to find the first/last occurence, example:
                    //{ 1, 2, 2, 2, 2, 4 ,5, 5,5,5,5,5,5,8, 9,9,9 } => { 1, 2, 2, 2, 2, 4 ,5, 5,X,5,5,5,5,8, 9,9,9 }
                    Console.WriteLine("Searching for lowest index");
                    int firstOccurence = BinarySearchFirstOccurenceAsc(nums, 0, randomOccurence, target);

                    Console.WriteLine("Searching for highest index");
                    int startIndexForLastOccurence = firstOccurence >= randomOccurence ? firstOccurence : randomOccurence;
                    int lastOccurence = BinarySearchLastOccurenceAsc(nums, startIndexForLastOccurence, nums.Length - 1, target);
                   

                    return new int[2] { firstOccurence, lastOccurence };
                }
            }



        }//O(log(n))


        private static int[] TrivialCases(int[] nums, int target)
        {

            if (nums.Length == 0)  //If I am given an empty int[] 
            {
                Console.WriteLine("Array is empty, target wasn't found.");
                return new int[2] { -1, -1 };
            }
            if (nums[0] == nums[nums.Length - 1]) //if I am given an int[] of length 1 or contains just one distinct number
            {
                if (target != nums[0])
                {
                    Console.WriteLine("Target not Found");

                    return new int[2] { -1, -1 };
                }
                else
                {
                    Console.WriteLine($"Lowest index of target {nums[0]} is {0} ");
                    Console.WriteLine($"Highest index of target {nums[nums.Length - 1]} is {nums.Length - 1} ");
                    return new int[2] { 0, nums.Length - 1 };
                }
            }
            return new int[1];

        }//O(1)

        private static int[] TrivialCasesBinarySearch(int[] nums, int randomOccurence, int target)
        {
            //if int[] contains one number only, equal to target, 
            //or the neigbouring indices to randomOccurence are not equal to target
            if (nums.Length == 1)
            {
                return new int[2] { randomOccurence, randomOccurence };
            }
            if ((randomOccurence != 0 && randomOccurence != nums.Length - 1) && (nums[randomOccurence - 1] != target && nums[randomOccurence + 1] != target))
            {
                return new int[2] { randomOccurence, randomOccurence };
            }
            if ((randomOccurence == 0 && nums[randomOccurence + 1] != target) || (randomOccurence == nums.Length - 1 && nums[randomOccurence - 1] != target))
            {
                return new int[2] { randomOccurence, randomOccurence };
            }
            return new int[1];
        }//O(1)

        private static int BinarySearchFirstOccurenceAsc(int[] arr, int l, int r, int target)
        {
            Console.WriteLine($"Left {l} Right {r} ");
            int mid = l + (r - l) / 2;
            Console.WriteLine("middle index " + mid);
            while (r - l > 0)
            {
                if (arr[mid] > target)
                {
                    return BinarySearchFirstOccurenceAsc(arr, 0, mid - 1, target);
                }
                else if (arr[mid] < target)
                {
                    return BinarySearchFirstOccurenceAsc(arr, mid + 1, r, target);

                }
                else //if arr[mid]=target.
                {
                    try
                    {
                        if (arr[mid - 1] == target)
                        {
                            return BinarySearchFirstOccurenceAsc(arr, 0, mid - 1, target);
                        }
                        else
                        {
                            Console.WriteLine($"Lowest index of target {arr[mid]} is {mid} ");
                            return mid;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Lowest index of target {arr[mid]} is {mid} ");
                        return mid;
                    }

                }
            }
            Console.WriteLine($"Lowest index of target {arr[mid]} is {r} ");
            return r;
        }//O(log(n))


        private static int BinarySearchLastOccurenceAsc(int[] arr, int l, int r, int target)
        {
            Console.WriteLine($"Left {l} Right {r} ");
            int mid = l + (r - l) / 2;
            Console.WriteLine("middle index " + mid);
            while (r - l > 0)
            {
                if (arr[mid] > target)
                {
                    return BinarySearchLastOccurenceAsc(arr, l, mid - 1, target);
                }
                else if (arr[mid] < target)
                {
                    return BinarySearchLastOccurenceAsc(arr, mid + 1, r, target);

                }
                else //if arr[mid]=target.
                {
                    try
                    {
                        if (arr[mid + 1] == target)
                        {
                            return BinarySearchLastOccurenceAsc(arr, mid + 1, r, target);
                        }
                        else
                        {
                            Console.WriteLine($"Highest index of target {arr[mid]} is {mid} ");
                            return mid;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Highest index of target {arr[mid]} is {mid} ");
                        return mid;
                    }

                }
            }
            Console.WriteLine($"Highest index of target {arr[mid]} is {l} ");
            return l;
        }//O(log(n))
    }
}
