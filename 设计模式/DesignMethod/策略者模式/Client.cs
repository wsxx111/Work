﻿//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Client
// created by 陈星宇
// at 2015/07/08 11:14:52
//--------------------------------------------

namespace DesignMethod.策略者模式
{
    //所得税计算策略
    public interface ITaxStragety
    {
        double CalculateTax(double income);
    }

    //企业所得税
    public class EnterpriseTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
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

    //个人所得税
    public class PersonalTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }
}