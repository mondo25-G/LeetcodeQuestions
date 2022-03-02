using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace ReversedLinkedList
{
    /// <summary>
    /// 206- Reverse Linked List <br></br>
    /// Given the head of a singly linked list, reverse the list, and return the reversed list.<br></br>
    /// Constraints: <br></br>
    /// The number of nodes in the list is the range [0, 5000].<br></br>
    /// -5000 &lt;= Node.val &lt;= 5000 <br></br>
    /// Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
    /// </summary>
    class Solution
    {

        public Solution(bool debug)
        {
            Debug.PrintForDebug("ITERATIVELY:", debug);
            TestCases(ReverseLinkedListIteratively, debug);
            Debug.PrintForDebug("\nITERATIVELY OPTIMIZED:", debug);
            TestCases(ReverseLinkedListIteratively, debug);
            Debug.PrintForDebug("\nRECURSIVELY:", debug);
            TestCases(ReverseLinkedListRecursively, debug);
        }

        public delegate ListNode ReverseLinkedList(ListNode ln, bool debug);
        public void TestCases(ReverseLinkedList del, bool debug)
        {
            ListNode testCase = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            Debug.PrintForDebug($"Initial: {testCase.val} {testCase.next.val} {testCase.next.next.val} {testCase.next.next.next.val}" +
                $" {testCase.next.next.next.next.val}", debug);
            ListNode reverse = del(testCase, debug);
            Debug.PrintForDebug($"Reversed: {reverse.val} {reverse.next.val} {reverse.next.next.val} {reverse.next.next.next.val} {reverse.next.next.next.next.val}", debug);

        }

        /// <summary>
        /// Reverses a singly linked list iteratively. Time O(n), Space O(n) where n: sum of nodes.
        /// </summary>
        /// <param name="head">the initial linked list</param>
        /// <param name="debug">print parameter for debug</param>
        /// <returns>null if the initial linked list is null else the reversed linked list</returns>
        public ListNode ReverseLinkedListIteratively(ListNode head, bool debug = false)
        {
            //Catch null listnode.
            if (head == null)
            {
                return null;
            }
            /* We need to return our listNode reversed, so we need to construct a listnode from the bottom up.
             * We need a data structure such that the first element to enter (i.e. the first listnode) will be the first to exit,
             * i.e. to process it so that I can construct the first element of the reversed listnode, the one that is inside
             * the innermost parenthesis of the construction process of a singly listed list
             * ListNode a = new ListNode(b, new ListNode (c, new ListNode(...))), and that element will just so happen to be last element
             * of the reversed linked list. Therefore I need a FIFO data structure, i.e a Queue.
             * 
             */
            //Initialize and fill a queue with the listNode.
            Queue<ListNode> queue = new Queue<ListNode>();
            while (head != null)
            {
                queue.Enqueue(new ListNode(head.val));
                head = head.next;
            }


            ListNode current = null;
            ListNode next = null;
            for (int i = 1; i <= queue.Count + i && queue.Count > 0; i++) //queue.Count decreases by 1 after each dequeue!!! 
            {                                                         //If you want to loop through the whole queue ensure 
                                                                      //that i is lt or eq to
                                                                      //The original .Count of the queue before dequeueing starts.
                                                                      //via "i<queue.Count+i"
                                                                      //and ensure that you won't raise an exception when queue is empty
                                                                      //via "&& queue.Count>0"
                current = new ListNode(queue.Dequeue().val, next);
                Debug.PrintForDebug($"{i} : {current.val} {(next == null ? 0 : next.val)}", debug);
                next = current;
            }
            return current;
        }

        //NOT SOLUTION
        //TODO: Try to understand iterative solution ReverseLinkedListRecursively
        /// <summary>
        /// Reverses a singly linked list iteratively IN PLACE. Time O(n), Space O(1) where n: sum of nodes.
        /// </summary>
        /// <param name="head">the initial linked list</param>
        /// <param name="debug">print parameter for debug</param>
        /// <returns>null if the initial linked list is null else the reversed linked list</returns>
        public ListNode ReverseLinkedListIterativelyOptimized(ListNode head, bool debug = false)
        {
            ListNode current = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = current;
                current = head;
                head = next;
            }
            return current;

        }

        //NOT MY SOLUTION
        //TODO: Try to understand recursive solution ReverseLinkedListRecursively
        /// <summary>
        /// Reverses a singly linked list iteratively. Time O(n), Space O(1) where n: sum of nodes.
        /// </summary>
        /// <param name="head">the initial linked list</param>
        /// <param name="debug">print parameter for debug</param>
        /// <returns>null if the initial linked list is null else the reversed linked list</returns>
        public ListNode ReverseLinkedListRecursively(ListNode head, bool debug = false)
        {

            if (head == null) return head;
            if (head.next == null) return head;

            var last = ReverseLinkedListRecursively(head.next);
            head.next.next = head;
            head.next = null;

            return last;


        }


    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
