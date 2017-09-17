using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StategyDemo
{
    public class DoExchange
    {
        private IExchangeMoney _ex_statery;

        public DoExchange(IExchangeMoney ex_statery)
        {
            this._ex_statery = ex_statery;
        }

        public decimal ToChinese(decimal money)
        {
            return this._ex_statery.ExchangeForChinese(money);
        }

    }
}
