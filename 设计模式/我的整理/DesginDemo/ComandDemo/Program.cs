using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComandDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver r = new Receiver();          
            Invotor inv = new Invotor();
            inv.Execute(new TelOpenCommand(r));
            Thread.Sleep(980);
            inv.Execute(new TelSwitchCommand(r,9));
            Thread.Sleep(980);
            inv.Execute(new TelCloseCommand(r));
            Console.ReadKey();
        }
    }
}
