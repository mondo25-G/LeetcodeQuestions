using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCRandomClassLibrary.RandomIntCollections
{
    public abstract class RandomCollection
    {

        private protected readonly int _size;
        private protected readonly int _from;
        private protected readonly int _to;
        private protected readonly Random _random;


        private protected RandomCollection(uint size, int from, int to)
        {
            _size = (int)size;
            _random = new Random((int)DateTime.Now.Ticks);
            _from = from;
            _to = to;

        }


    }
}
