//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/07 11:11:44
//--------------------------------------------
using System;

namespace DesignMethod.迭代器模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Iterator iterator;
            IListCollection list = new ConcreteList();
            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }
            Console.Read();
        }
    }
}