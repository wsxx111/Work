//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/08 11:12:34
//--------------------------------------------
using System;

namespace DesignMethod.策略者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //个人所得税
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付税为：{0}", operation.GetTax(5000.00));
            Console.WriteLine("-----------------------------");
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付税为：{0}", operation.GetTax(5000.00));
            Console.Read();
        }
    }
}