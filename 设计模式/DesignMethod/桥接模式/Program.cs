//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/03 15:39:48
//--------------------------------------------
using System;

namespace DesignMethod.桥接模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            RemoteControl remote = new ConcreteRemote();
            remote.Implementor = new ChangHong();
            remote.On();
            remote.Off();
            remote.SetChannel();
            Console.WriteLine();

            remote.Implementor = new SanXing();
            remote.On();
            remote.Off();
            remote.SetChannel();
            Console.WriteLine();

            Console.Read();
        }
    }
}