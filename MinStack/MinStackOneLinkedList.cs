using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace MinStack
{
    //A very useful to know implementation using just a linked list. Beautiful really.

    //Time complexity O(1) (amortized), space complexity O(n), [uses just one linked list]

    // "Every element that is being added is added to the head of the linked list,
    // and for every node that is added, min stores the min value that has been pushed to the stack until that point
    //To pop, we can just dereference the current head and point it to the next node of the head, making it a O(1) operation.
    //Get min is fairly simple.We just return back the min value that we are storing as part of every node. It is O(1) operation as well."
    //Reference: https://leetcode.com/problems/min-stack/discuss/1435807/Java-Linked-List-Implementation
    public class Node
    {

        public int Val;
        public Node Next;
        public int Min;

        public Node(int val, int min) //store
        {
            this.Val = val;
            this.Min = min;
            Next = null;
        }
    }
    public class MinStackOneLinkedList : MinStackBlueprint
    {
        private Node _head;
        public MinStackOneLinkedList(bool debug) : base(debug)
        {

        }

        public override void Push(int x)
        { //O(1)
            if (_head == null)
            {
                _head = new Node(x, x);//if head empty make head node, keep count of  value and set it to min
                Debug.PrintForDebug($"Pushed value {_head.Val}, minimum is {_head.Min}", _debug);
            }
            else
            {
                Node node = new Node(x, Math.Min(_head.Min, x)); //create new node, with val the value you pushed and keep track of minimum in the node
                node.Next = _head; //add to chain
                _head = node; //make new node the head.
                Debug.PrintForDebug($"Pushed value {_head.Val}, minimum is {_head.Min}", _debug);
            }
        }

        public override void Pop()
        {
            if (_head != null)
            {
                Debug.PrintForDebug($"Popped (top) value {_head.Val}", _debug);
                _head = _head.Next; //dereference the current head and point it to the next node of the head
            }
        }

        public override int Top()
        {
            if (_head != null)
            {
                Debug.PrintForDebug($"Top value is {_head.Val}", _debug);
                return _head.Val; //always return the "top value of the stack" i.e. the Val of the _head of linked list
            }
            return -1;
        }

        public override int GetMin()
        {
            if (_head != null)
            {
                Debug.PrintForDebug($"Min value is {_head.Min}", _debug);
                return _head.Min; //always return the "minimum of the stack" i.e. the Min of the _head of linked list
            }
            return -1;
        }
    }
}
