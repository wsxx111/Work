//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/08 15:38:57
//--------------------------------------------
using System;

namespace DesignMethod.解释者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            string englist = "This is an apple.";
            string chinese = Translator.Translate(englist);
            Console.WriteLine(chinese);
            Console.Read();
        }
    }
}