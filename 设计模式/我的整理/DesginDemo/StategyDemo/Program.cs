using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StategyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DoExchange money_exc = new DoExchange(new JapaneseToChinese());
            DoExchange money_exc2 = new DoExchange(new USAToChinese());
            DoExchange money_exc3 = new DoExchange(new KonreToChinese());
            Console.WriteLine(money_exc.ToChinese(234M));
            Console.WriteLine(money_exc2.ToChinese(234M));
            Console.WriteLine(money_exc3.ToChinese(234M));

            Console.ReadKey();
        }
    }
}
