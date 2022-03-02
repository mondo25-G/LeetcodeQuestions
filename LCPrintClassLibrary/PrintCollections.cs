using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPrintClassLibrary
{
    public static class PrintCollections
    {

        public static void Print<T>(IList<T> collection)
        {

            StringBuilder sb = new StringBuilder();
            foreach (var item in collection)
            {
                sb.Append(item);
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());


        }





    }
}
