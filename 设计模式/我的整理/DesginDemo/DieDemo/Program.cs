using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            people p = new people();        
            Die d=p.getDie();
            while(!d.isEnd())
            {
                Card c = (Card)d.getCurrent();
                Console.WriteLine(string.Format("卡：{0}，时间：{1}",c.card_Name,c.card_openDate));
                d.moveNext();
            }

            Console.ReadKey();
        }
    }
}
