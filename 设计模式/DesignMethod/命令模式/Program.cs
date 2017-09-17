//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/06 15:08:58
//--------------------------------------------
using System;

namespace DesignMethod.命令模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);
            i.ExecuteCommand();
            Console.Read();
        }
    }
}