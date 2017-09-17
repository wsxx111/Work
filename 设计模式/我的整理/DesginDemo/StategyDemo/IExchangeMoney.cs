using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StategyDemo
{
    public interface IExchangeMoney
    {
        decimal ExchangeForChinese(decimal money);
    }
}
