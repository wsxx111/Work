using DesignMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            StartDesign design = new StartDesign();
            design.Go();                 
            Console.ReadKey();
        }
    }
}
