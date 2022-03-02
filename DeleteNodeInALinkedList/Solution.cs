using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteNodeInALinkedList
{
    /// <summary>
    /// 237 - Delete Node in Linked List
    /// Write a function to delete a node in a singly-linked list.<br></br>
    /// You will not be given access to the head of the list, instead you will be given access to the node to be deleted directly.<br></br>
    /// It is guaranteed that the node to be deleted is not a tail node in the list.<br></br>
    /// Constraints:
    /// The number of the nodes in the given list is in the range [2, 1000]<br></br>
    /// -1000 &lt;= Node.val &lt;= 1000 <br></br>
    /// The value of each node in the list is unique.<br></br>
    /// The node to be deleted is in the list and is not a tail node
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);
        }

        private void TestCases(bool debug)
        {
            ListNode listNode = new ListNode(4);
            listNode.Next = new ListNode(5);
            listNode.Next.Next = new ListNode(1);
            listNode.Next.Next.Next = new ListNode(9);

            DeleteNode(listNode, debug);
            //There really is no sense for a testcase here, only in leetcode.


        }


        //Input: head = [4,5,1,9], node = 1
        //Output: [4,5,9]
        //Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.

        //This is quite the tricky problem.
        //Note that in this method, when leetcode passes you the listNode it is implemented in a way such that you have 
        //DIRECTLY access to the node that is to be deleted *
        public void DeleteNode(ListNode listNode, bool debug)//Time O(1), Space O(1)
        {
            //Check for 2+ elements in list even though constraints assures us of it.
            if (listNode == null || listNode.Next == null)
            {
                return;
            }
            //* so as long as the node is not the TAIL, which is true for this problem, the trick below works fine.
            listNode.Val = listNode.Next.Val;
            listNode.Next = listNode.Next.Next;
        }


    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public int Val;
        public ListNode Next;
        public ListNode(int x) { Val = x; }
    }
}
