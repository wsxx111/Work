using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.策略者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付税为：{0}", operation.GetTax(5000.00));
            Console.WriteLine("-----------------------------");

            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付税为：{0}", operation.GetTax(5000.00));
            Console.Read();
        }
    }


    public class InterestOperation
    {
        private ITaxStragety m_strategy;

        public InterestOperation(ITaxStragety strategy)
        {
            this.m_strategy = strategy;
        }

        public double GetTax(double income)
        {
            return m_strategy.CalculateTax(income);
        }
    }

    //所得税计算策略
    public interface ITaxStragety
    {
        double CalculateTax(double income);
    }


    //个人所得税
    public class PersonalTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }

    //企业所得税
    public class EnterpriseTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
        }
    }
}
