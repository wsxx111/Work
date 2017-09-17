//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/03 9:43:11
//--------------------------------------------
using System;

namespace DesignMethod.抽象工厂
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            AbstractFactory nanChangFac = new NanChangFactory();
            YaBo nanChangYaBo = nanChangFac.CreateYaBo();
            nanChangYaBo.Print();

            AbstractFactory shangHaiFac = new ShangHaiFactory();
            shangHaiFac.CreateYaJia().Print();
            shangHaiFac.CreateYaBo().Print();

            Console.Read();
        }
    }
}