using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    /// <summary>
    /// 155. Min Stack<br></br>
    /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time<br></br>
    /// Implement the MinStack class:<br></br>
    /// MinStack() initializes the stack object.<br></br>
    /// void push(int val) pushes the element val onto the stack.<br></br>
    /// void pop() removes the element on the top of the stack.<br></br>
    /// int top() gets the top element of the stack.<br></br>
    /// int getMin() retrieves the minimum element in the stack.<br></br>
    /// Constraints:<br></br>
    /// -2^31 &lt;= val &lt;= 2^31 - 1<br></br>
    /// Methods pop, top and getMin operations will always be called on non-empty stacks<br></br>
    /// At most 3 * 10^4 calls will be made to push, pop, top, and getMin.
    /// </summary>
    class Solution
    {
        public Solution(bool debug)
        {
            TestCases(debug);

        }


        public void TestCases(bool debug)
        {
            MinStackTwoStacks minStack = new MinStackTwoStacks(debug);
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin(); // return -3
            minStack.Pop();
            minStack.Top();    // return 0
            minStack.GetMin(); // return -2

            Console.WriteLine("-------------------");
            MinStackOneLinkedList minStack2 = new MinStackOneLinkedList(debug);
            minStack2.Push(-2);
            minStack2.Push(0);
            minStack2.Push(-3);
            minStack2.GetMin(); // return -3
            minStack2.Pop();
            minStack2.Top();    // return 0
            minStack2.GetMin(); // return -2


        }
    }
    }
