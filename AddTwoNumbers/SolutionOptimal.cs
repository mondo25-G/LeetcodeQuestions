using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace AddTwoNumbers
{
    //TODO:Understand optimal solution
    class SolutionOptimal
    {

        public SolutionOptimal()
        {

            TestCases(true);
        }


        //This solution is better than mine for many many reasons. It disregards the sum, moving directly to linkedlist construction, 
        //thus circumventing problems arising from integer overflows, and memory requirements by explicitly making all variables
        //related to the sum as Big Integers. 
        //It is very short and sweet.
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, bool debug = false)
        {
            int carry = 0;
            ListNode dummy = new ListNode(0); // 1 Node before the actual head of list
            ListNode tail = dummy;
            while (l1 != null || l2 != null || carry != 0)
            {
                int value = carry;
                if (l1 != null)
                {
                    value += l1.Val;
                    l1 = l1.Next;
                }
                if (l2 != null)
                {
                    value += l2.Val;
                    l2 = l2.Next;
                }
                int digit = value % 10;
                carry = value / 10;
                tail.Next = new ListNode(digit);
                tail = tail.Next;
            }
            return dummy.Next;
        }

        public void TestCases(bool debug = false)
        {

            //Obviously recursion is key here.
            //[3,4,2]
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            Debug.PrintForDebug($"First Linked List:  Val:{l1.Val} Next Val:{l1.Next.Val} Next Val:{l1.Next.Next.Val}", debug);

            //[4,6,5]
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            Debug.PrintForDebug($"Second Linked List:  Val:{l2.Val} Next Val:{l2.Next.Val} Next Val:{l2.Next.Next.Val}", debug);

            Console.WriteLine("----");
            ListNode result = AddTwoNumbers(l1, l2, debug);
            //For debug to see how it works.
            Debug.PrintForDebug($"New Linked List:  Val:{result.Val} Next Val:{result.Next.Val} Next Val:{result.Next.Next.Val}:", debug);

            Console.WriteLine("-----");


            //Test for Integer Overflow. Failed until I caught it and set relevant quantities from int to long.
            //[9]
            ListNode l3 = new ListNode(9);
            Debug.PrintForDebug($"First Linked List:  Val:{l3.Val}", debug);

            //[1,9,9,9,9,9,9,9,9,9]           
            ListNode l4 = new ListNode(1, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))));
            Debug.PrintForDebug($"Second Linked List:  Val:{l4.Val} Next Val:{l4.Next.Val} Next Val:{l4.Next.Next.Val} Next Val:{l4.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Val} " +
                $"Next Val:{l4.Next.Next.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{l4.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val}", debug);

            Console.WriteLine("-----");
            ListNode result2 = AddTwoNumbers(l3, l4, debug);

            Debug.PrintForDebug($"New Linked List:  Val:{result2.Val} Next Val:{result2.Next.Val} Next Val:{result2.Next.Next.Val} Next Val:{result2.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Val}  Next Val:{result2.Next.Next.Next.Next.Next.Next.Val} " +
                $" Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val} Next Val:{result2.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val} ", debug);
            Console.WriteLine("-----");


            //margin case
            ListNode l5 = new ListNode();
            Debug.PrintForDebug($"First Linked List:  Val:{l5.Val}", debug);

            ListNode l6 = new ListNode();
            Debug.PrintForDebug($"Second Linked List:  Val:{l6.Val}", debug);

            Console.WriteLine("-----");
            ListNode result3 = AddTwoNumbers(l5, l6, debug);

            Debug.PrintForDebug($"New Linked List:  Val:{result3.Val}", debug);

            Console.WriteLine("-----");

            //Test for Long Overflow. Failed until I caught it and set relevant quantities from int to BigIntegers (System.Numerics).
            //[1,0,0,0,0,0,0,0,0,0,P0,0,0,0,0,0,0,0,0,0P,0,0,0,0,0,0,0,0,0,0,P1]
            ListNode l7 = new ListNode(1, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))))))))))))))))))))))))));

            //[5,6,4]
            ListNode l8 = new ListNode(5, new ListNode(6, new ListNode(4)));

            Console.WriteLine("-----");
            ListNode result4 = AddTwoNumbers(l7, l8, debug);


        }


    }


}
