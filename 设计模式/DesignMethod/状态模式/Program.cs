//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/07 13:44:11
//--------------------------------------------
using System;

namespace DesignMethod.状态模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Account account = new Account("Lear");
            account.Deposit(1000.00);
            account.Deposit(600.00);
            account.Deposit(200.00);

            //利息
            account.PayInterest();

            //取钱
            account.Withdraw(2000.00);
            account.Withdraw(500.00);

            //等待输入
            Console.Read();
        }
    }
}