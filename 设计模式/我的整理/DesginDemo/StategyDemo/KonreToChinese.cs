using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StategyDemo
{
    public class KonreToChinese:IExchangeMoney
    {
        public decimal ExchangeForChinese(decimal money)
        {
            decimal radio = 0.2M;
            return money / radio; 
        }
    }
}
