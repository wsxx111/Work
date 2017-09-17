﻿//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/03 16:26:36
//--------------------------------------------
using System;

namespace DesignMethod.装饰者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Phone phone = new ApplePhone();
            //贴膜
            Decorator appleSticker = new Sticker(phone);
            //拓展
            appleSticker.Print();
            Console.WriteLine("-----------\n");
            //挂件
            Decorator appleAccess = new Accessories(phone);
            //拓展
            appleAccess.Print();
            Console.WriteLine("-----------\n");
            //同时有俩
            Sticker sti = new Sticker(phone);
            Accessories appleAccess2 = new Accessories(sti);
            appleAccess2.Print();
            Console.Read();
        }
    }
   
}