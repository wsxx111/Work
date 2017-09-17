//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/06 10:44:32
//--------------------------------------------
using System;

namespace DesignMethod.模板模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
            Console.Read();
        }
    }
}