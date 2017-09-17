using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDemo
{
    public class Western_Cookie:Cookie
    {
        protected override void MixPie()
        {
            Console.WriteLine("加西式pie");
        }
    }
}
