using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    public abstract class MinStackBlueprint
    {
        private protected bool _debug = false;
        public MinStackBlueprint(bool debug)
        {
            _debug = debug;
        }
        public abstract void Push(int val);
        public abstract void Pop();
        public abstract int Top();

        public abstract int GetMin();

    }
}
