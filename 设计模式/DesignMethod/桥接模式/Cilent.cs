//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Cilent
// created by 陈星宇
// at 2015/07/03 15:39:56
//--------------------------------------------
using System;

namespace DesignMethod.桥接模式
{
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

    public class ConcreteRemote : RemoteControl
    {
        public override void SetChannel()
        {
            Console.WriteLine("-----------------------");
            base.SetChannel();
            Console.WriteLine("-----------------------");
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

    public abstract class TV
    {
        public abstract void Off();

        public abstract void On();

        public abstract void tuneChannel();
    }
}