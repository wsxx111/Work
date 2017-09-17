//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/08 15:02:26
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.备忘录模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            List<ContactPerson> persons = new List<ContactPerson>()
            {
                new ContactPerson(){ Name="Learning Hard",MobileNum="123456" },
                new ContactPerson(){ Name="Tony",MobileNum="234567" },
                new ContactPerson(){ Name="Jock",MobileNum="345678" }
            };
            MobileOwner mobileOwner = new MobileOwner(persons);
            mobileOwner.Show();
            //创建备忘录并保存对象
            Caretaker caretaker = new Caretaker();
            caretaker.ContactM = mobileOwner.CreateMemento();
            //更改发起联系人列表
            Console.WriteLine("----移除最后一个联系人----");
            mobileOwner.ContactPersons.RemoveAt(2);
            mobileOwner.Show();
            //恢复到原始状态
            Console.WriteLine("----恢复联系人列表----");
            mobileOwner.RestoreMemento(caretaker.ContactM);
            mobileOwner.Show();
            Console.Read();
        }
    }
}