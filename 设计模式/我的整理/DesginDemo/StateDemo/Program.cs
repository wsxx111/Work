using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Room r = new Room();
            r.Ding();
            r.Zhu();
            r.Zhu();
            r.Tui_Ding();
            r.Zhu();
            r.Tui_fang();
            r.Zhu();

            Console.ReadKey();
        }
    }
}
