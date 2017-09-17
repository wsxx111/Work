using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.适配器
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region OpenClass

            IThreeHole threehole = new PowerAdpter();
            threehole.Requset();
            Console.ReadLine();

            #endregion OpenClass

            #region OpenObject

            ThreeHole2 three = new PowerAdapter();
            three.Request();
            Console.ReadLine();

            #endregion OpenObject
        }
    }



   // 类适配器模式

    /// <summary>
    /// 目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Requset();
    }


    /// <summary>
    /// 源角色需要适配的类
    /// </summary>
    public class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }


    /// <summary>
    /// 适配器类
    /// </summary>
    public class PowerAdpter : TwoHole, IThreeHole
    {
        public void Requset()
        {
            this.SpecificRequest();
        }
    }



   // 对象适配器模式

    /// <summary>
    /// 三个孔插头，目标角色
    /// </summary>
    public class ThreeHole2
    {
        //客户端需要的方法
        public virtual void Request()
        {
            //可以把一般实现放在这里
            Console.WriteLine("我是三个孔插头");
        }
    }

    /// <summary>
    /// 两个孔插头，源角色
    /// </summary>
    public class TwoHole2
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔插头");
        }
    }

    /// <summary>
    /// 适配器类
    /// </summary>
    public class PowerAdapter : ThreeHole2
    {
        //引用实例
        public TwoHole2 twh = new TwoHole2();

        public override void Request()
        {
            twh.SpecificRequest();
        }
    }

}
