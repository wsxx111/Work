//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/08 14:22:59
//--------------------------------------------
using System;

namespace DesignMethod.访问者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            ObjectStructure objectstructure = new ObjectStructure();
            foreach (Element e in objectstructure.Element)
            {
                e.Accept(new ConcreteVistor());
            }

            Console.Read();
        }
    }
}