using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StategyDemo
{
    public class JapaneseToChinese : IExchangeMoney
    {
        public decimal ExchangeForChinese(decimal money)
        {
            decimal radio =0.5M;
            return money / radio;
        }
    }
}
