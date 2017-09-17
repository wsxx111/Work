using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    //手机抽象类
    public abstract class Phone
    {
        public abstract void Print();
    }


    //苹果手机
    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象---苹果手机");
        }
    }

    //装饰抽象类
    public abstract class Decorator : Phone
    {
        private Phone phone;

        public Decorator(Phone p)
        {
            this.phone = p;
        }

        public override void Print()
        {
            if (phone != null)
            {
                phone.Print();
            }
        }
    }

    //贴膜
    public class Sticker : Decorator
    {
        public Sticker(Phone p)
            : base(p)
        { }

        public void AddSticker()
        {
            Console.WriteLine("有贴膜");
        }

        public override void Print()
        {
            base.Print();
            AddSticker();
        }
    }


    //挂件
    public class Accessories : Decorator
    {
        public Accessories(Phone p)
            : base(p)
        { }

        public void AddAccessories()
        {
            Console.WriteLine("有挂件");
        }

        public override void Print()
        {
            base.Print();
            AddAccessories();
        }
    }


}
