using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCRandomClassLibrary.RandomIntCollections
{
    public class RandomIntCollection : RandomCollection, IRandomIntCollection
    {

        public RandomIntCollection(uint size, int from, int to) : base(size, from, to)
        {

        }
        public int[] RandomArray()
        {

            int[] randomArray = new int[_size];

            for (int i = 0; i < _size; i++)
            {
                randomArray[i] = _random.Next(_from, _to + 1);
            }

            return randomArray;

        }
        public List<int> RandomList()
        {
            return RandomArray().ToList();
        }




    }
}
