﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StategyDemo
{
    public class USAToChinese : IExchangeMoney
    {
        public decimal ExchangeForChinese(decimal money)
        {
            decimal radio = 1.6M;
            return money / radio;
        }
    }
}
