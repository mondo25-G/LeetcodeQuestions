using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCPrintClassLibrary;

namespace MinStack
{
    //Time complexity O(1) (amortized), space complexity O(n), [uses extra O(n) space i.e O(2n) due to two stacks.]
    //The most intuitive approach is to maintain two stacks, one for every value, and one for the minima.
    //Using composition , we can initialize the two stacks as private fields and have an amortized O(1) time complexity, with O(n) space complexity.

    //However,here, you can make use of the last constraint "At most 3 * 10^4 calls will be made to push, pop, top, and getMin." and set their capacity at 30000,
    //to guarantee O(1) time complexity at all times. 

    //In this implementation there are safeguards in case of pop,top, getMin operations on empty stacks.
    public class MinStackTwoStacks : MinStackBlueprint
    {
        private Stack<int> _stack = new Stack<int>();
        private Stack<int> _minimumStack = new Stack<int>();
        public MinStackTwoStacks(bool debug) : base(debug)
        {

        }
        public override void Push(int val)
        {
            if (_minimumStack.Count == 0)
            {
                _minimumStack.Push(val);
                Debug.PrintForDebug($"Pushed value {val} to EMPTY minima stack and", _debug);
            }
            else
            {
                if (val <= _minimumStack.Peek())
                {
                    _minimumStack.Push(val);
                    Debug.PrintForDebug($"Pushed value {val} to minima stack and", _debug);
                }
            }

            _stack.Push(val);
            Debug.PrintForDebug($"pushed value {val} to proper stack\n", _debug);
        }

        public override void Pop()
        {
            if (_stack.Count > 0 && _minimumStack.Count > 0)
            {
                if (_stack.Peek() == _minimumStack.Peek())
                {
                    int x = _minimumStack.Pop();
                    Debug.PrintForDebug($"Popped value {x} from minima stack since it is minimum and ", _debug);
                }
                int y = _stack.Pop();
                Debug.PrintForDebug($"popped value {y} from proper stack\n", _debug);
            }
        }

        public override int Top()
        {
            if (_stack.Count > 0)
            {
                int x = _stack.Peek();
                Debug.PrintForDebug($"Value {x} is on top in proper stack", _debug);
                return x;
            }
            else
            {
                return -1;
            }

        }

        public override int GetMin()
        {
            if (_minimumStack.Count > 0)
            {
                int x = _minimumStack.Peek();
                Debug.PrintForDebug($"Value {x} is on top in minima stack", _debug);
                return x;
            }
            else
            {
                return -1;
            }
        }
    }
}
