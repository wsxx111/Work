using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDemo
{
    public abstract class Cookie
    {
        public void Docook()
        {
            CleanCai();
            BoilWater();
            MixPie();
            TakeFuilt();
        }

        protected void CleanCai()
        {
            Console.WriteLine("洗菜");
        }
        protected void BoilWater()
        {
            Console.WriteLine("煮水");
        }

        protected abstract void MixPie();

        protected void TakeFuilt()
        {
            Console.WriteLine("加水果");
        }
    }
}
