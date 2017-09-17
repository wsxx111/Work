using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Player_A p1 = new Player_A(20, "张三", true);
            Player_B p2 = new Player_B(20, "李四", false);
            Player_C p3 = new Player_C(20, "王五", false);

            Middle m=new Middle(p1,p2,p3);
            //开始游戏
            p1.WinMoney(1, m);
            p2.WinMoney(1, m);
            p2.WinMoney(1, m);
            p1.WinMoney(1, m);
            p3.WinMoney(1, m);
            p2.WinMoney(1, m);

            Console.WriteLine(p1.Money);
            Console.WriteLine(p2.Money);
            Console.WriteLine(p3.Money);
            Console.WriteLine(p1.Wincount);
            Console.WriteLine(p2.Wincount);
            Console.WriteLine(p3.Wincount);

            Console.ReadKey();
        }
    }
}
