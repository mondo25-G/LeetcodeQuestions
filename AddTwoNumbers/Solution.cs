using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;
using System.Numerics;

namespace AddTwoNumbers
{
    //TODO: Refactor and documentation od AddTwoNumbers, And for god's sake look at other clean solutions https://leetcode.com/problems/add-two-numbers/discuss/1010/Is-this-Algorithm-optimal-or-what
    //TestCases shows the problems encountered while constructing solution
    //Cons: Solution is too large, memory expensive (BigInt), recursion is slower than while loop. Needs optimization
    //Pros: time complexity is optimal, yields correct resulta.

    /// <summary>
    /// 2 - Add Two Numbers
    /// You are given two non-empty linked lists representing two non-negative integers. <br></br>
    /// The digits are stored in reverse order, and each of their nodes contains a single digit.<br></br>
    /// Add the two numbers and return the sum as a linked list.<br></br>
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.<br></br>
    /// Constraints:<br></br>
    /// The number of nodes in each linked list is in the range [1, 100].<br></br>
    /// 0 &lt;= Node.val &lt;= 9<br></br>
    /// It is guaranteed that the list represents a number that does not have leading zeros.
    /// </summary>
    public class Solution
    {
        public Solution()
        {

            TestCases(true);
        }


        // //Time Complexity: O(n+m) where n,m the number of elements in linked lists l1,l2.
        //Space Complexity: O(n+m)
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, bool debug = false)
        {
            BigInteger sum = ExtractNumberFromLinkedList(l1, debug) + ExtractNumberFromLinkedList(l2, debug);//O(n+m): m=elements in l1, n=elements in l2

            Debug.PrintForDebug($"Final Linked List stores their sum: {sum}", debug);


            //extract length of sum
            BigInteger tens = 1;
            BigInteger sumL = sum;
            while (sumL / 10 > 0)
            {
                sumL /= 10;
                tens *= 10;
            }
            BigInteger divisor = new BigInteger(1);
            var ret = InsertNumberToLinkedList(sum, tens, divisor);  //O(n+m):        
            return ret;
        }

        //Time Complexity: O(n) where n the number of elements in linked list.
        //Space Complexity: O(1)
        /// <summary>
        /// Extracts the number stored in a linked list representing a non-negative integer.<br></br>
        /// The digits are stored in reverse order. <br></br>
        /// Each node contains a single digit.
        /// </summary>
        /// <param name="l">the linked list</param>
        /// <param name="debug">debug print parameter</param>
        /// <returns>the non negative number stored in linked list</returns>
        public BigInteger ExtractNumberFromLinkedList(ListNode l, bool debug = false)
        {
            BigInteger tens = 1;
            BigInteger reverseNumber = 0;
            while (l.Next != null)
            {
                tens *= 10;
                reverseNumber = reverseNumber * 10 + l.Val;
                l = l.Next;
            }
            reverseNumber = reverseNumber * 10 + l.Val;

            BigInteger divisor = 1;
            BigInteger number = 0;
            while (tens > 0)
            {
                number += (reverseNumber / divisor) % 10 * tens;
                tens /= 10;
                divisor *= 10;
            }

            Debug.PrintForDebug($"Linked List stores number {number}", debug);
            return number;
        }


        //Time Complexity: O(n) where n the number of elements in linked list.
        //Space Complexity: O(n)
        /// <summary>
        /// Inserts a non-negative integer to a linked list.<br></br>
        /// The digits are inserted in reverse order. <br></br>
        /// Each node contains a single digit.
        /// </summary>
        /// <param name="num">The number to insert to linked list</param>
        /// <param name="tens">10^(number of digits in num)</param>
        /// <param name="divisor">The divisor of <paramref name="num"/> in each recursive call</param>
        /// <returns>the final linked list</returns>
        /// <remarks>Recursive method. <br></br>
        /// While <paramref name="num"/> length>0 (i.e. <paramref name="tens"/>>0), <paramref name="divisor"/>*=10 and the digit extracted is (<paramref name="num"/>/<paramref name="divisor"/>)%10<br></br></remarks>
        public ListNode InsertNumberToLinkedList(BigInteger num, BigInteger tens, BigInteger divisor)
        {
            ListNode ret = new ListNode();
            if (tens > 0)
            {
                BigInteger digit = (num / divisor) % 10;
                ret.Val = (int)digit;
                tens /= 10;
                divisor *= 10;
                if (tens > 0)
                {
                    ret.Next = InsertNumberToLinkedList(num, tens, divisor);
                }
            }

            return ret;
        }


        public void TestCases(bool debug = false)
        {

            //Obviously recursion is key here.
            //[3,4,2]
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            Debug.PrintForDebug($"First Linked List:  Val:{l1.Val} Next Val:{l1.Next.Val} Next Val:{l1.Next.Next.Val}", debug);
            ExtractNumberFromLinkedList(l1, debug);
            //[4,6,5]
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            Debug.PrintForDebug($"Second Linked List:  Val:{l2.Val} Next Val:{l2.Next.Val} Next Val:{l2.Next.Next.Val}", debug);
            ExtractNumberFromLinkedList(l2, debug);
            Console.WriteLine("----");
            ListNode result = AddTwoNumbers(l1, l2, debug);
            //For debug to see how it works.
            Debug.PrintForDebug($"New Linked List:  Val:{result.Val} Next Val:{result.Next.Val} Next Val:{result.Next.Next.Val}:", debug);
            ExtractNumberFromLinkedList(result, debug);
            Console.WriteLine("-----");


            //Test for Integer Overflow. Failed until I caught it and set relevant quantities from int to long.
            //[9]
            ListNode l3 = new ListNode(9);
            Debug.PrintForDebug($"First Linked List:  Val:{l3.Val}", debug);
            ExtractNumberFromLinkedList(l3, debug);
            //[1,9,9,9,9,9,9,9,9,9]           
            ListNode l4 = new ListNode(1, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))));
            Debug.PrintForDebug($"Second Linked List:  Val:{l4.Val} Next Val:{l4.Next.Val} Next Val:{l4.Next.Next.Val} Next Val:{l4.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Val} " +
                $"Next Val:{l4.Next.Next.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val}", debug);
            ExtractNumberFromLinkedList(l4, debug);
            Console.WriteLine("-----");
            ListNode result2 = AddTwoNumbers(l3, l4, debug);
            ExtractNumberFromLinkedList(result2, debug);
            Debug.PrintForDebug($"New Linked List:  Val:{result2.Val} Next Val:{result2.Next.Val} Next Val:{result2.Next.Next.Val} Next Val:{result2.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Val}  Next Val:{result2.Next.Next.Next.Next.Next.Next.Val} " +
                $" Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val} ", debug);
            Console.WriteLine("-----");


            //margin case
            ListNode l5 = new ListNode();
            Debug.PrintForDebug($"First Linked List:  Val:{l5.Val}", debug);
            ExtractNumberFromLinkedList(l5, debug);
            ListNode l6 = new ListNode();
            Debug.PrintForDebug($"Second Linked List:  Val:{l6.Val}", debug);
            ExtractNumberFromLinkedList(l6, debug);
            Console.WriteLine("-----");
            ListNode result3 = AddTwoNumbers(l5, l6, debug);
            ExtractNumberFromLinkedList(result3, debug);
            Debug.PrintForDebug($"New Linked List:  Val:{result3.Val}", debug);

            Console.WriteLine("-----");

            //Test for Long Overflow. Failed until I caught it and set relevant quantities from int to BigIntegers (System.Numerics).
            //[1,0,0,0,0,0,0,0,0,0,P0,0,0,0,0,0,0,0,0,0P,0,0,0,0,0,0,0,0,0,0,P1]
            ListNode l7 = new ListNode(1, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))))))))))))))))))))))))));
            ExtractNumberFromLinkedList(l7, debug);
            //[5,6,4]
            ListNode l8 = new ListNode(5, new ListNode(6, new ListNode(4)));
            ExtractNumberFromLinkedList(l8, debug);
            Console.WriteLine("-----");
            ListNode result4 = AddTwoNumbers(l7, l8, debug);
            ExtractNumberFromLinkedList(result4, debug);

        }
    }


    //* Definition for singly-linked list. Starting Class.
    public class ListNode
    {
        public int Val;
        public ListNode Next;
        //recursion
        public ListNode(int val = 0, ListNode next = null)
        {
            Val = val;
            Next = next;
        }

    }
}
