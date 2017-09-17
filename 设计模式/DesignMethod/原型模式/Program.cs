//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/03 13:29:17
//--------------------------------------------
using System;

namespace DesignMethod.原型模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //原型
            MonkeyKingPrototype prototypeKing = new ConcretePrototype("1");
            //变一个
            MonkeyKingPrototype cloneMokeyKing = prototypeKing.Clone() as ConcretePrototype;
            Console.Write(cloneMokeyKing.Id);

            //变两个
            MonkeyKingPrototype cloneMokeyKing2 = prototypeKing.Clone() as ConcretePrototype;
            Console.Write(cloneMokeyKing2.Id);
            Console.Read();
        }
    }
}