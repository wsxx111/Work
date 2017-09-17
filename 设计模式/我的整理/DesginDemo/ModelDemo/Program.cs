using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Western_Cookie w = new Western_Cookie();
            w.Docook();
            Eastern_Cookie e = new Eastern_Cookie();
            e.Docook();
            Console.ReadKey();
        }
    }
}
