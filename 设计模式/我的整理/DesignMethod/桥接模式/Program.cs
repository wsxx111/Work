using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    /// <summary>
    /// 抽象概念中的遥控器，抽象化角色
    /// </summary>
    public class RemoteControl
    {
        private TV implementor;

        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        public virtual void Off()
        {
            implementor.Off();
        }

        public virtual void On()
        {
            implementor.On();
        }

        public virtual void SetChannel()
        {
            implementor.tuneChannel();
        }
    }

    public class ConcreteRemote : RemoteControl
    {
        public override void SetChannel()
        {
            Console.WriteLine("-----------------------");
            base.SetChannel();
            Console.WriteLine("-----------------------");
        }
    }


    public abstract class TV
    {
        public abstract void Off();

        public abstract void On();

        public abstract void tuneChannel();
    }

    public class SanXing : TV
    {
        public override void Off()
        {
            Console.WriteLine("三星关闭");
        }

        public override void On()
        {
            Console.WriteLine("三星打开");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("三星换频道");
        }
    }

    public class ChangHong : TV
    {
        public override void Off()
        {
            Console.WriteLine("长虹关闭");
        }

        public override void On()
        {
            Console.WriteLine("长虹打开");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("长虹换频道");
        }
    }


}
