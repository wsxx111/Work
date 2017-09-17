using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.工厂方法
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //初始化工厂类
            Creator shrFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomFactory = new TomatoScrambledEggsFactory();

            //开始西红柿
            Food tom = tomFactory.CreateFoodFactory();
            tom.Print();

            //开始土豆
            Food shr = shrFactory.CreateFoodFactory();
            shr.Print();

            Console.Read();
        }
    }


    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class Creator
    {
        //定义工厂类
        public abstract Food CreateFoodFactory();
    }

    /// <summary>
    /// 土豆工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 创建土豆
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }


    /// <summary>
    /// 西红柿工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 创建西红柿
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new TomatoScrambledEggs();
        }
    }


    /// <summary>
    /// 土豆
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("土豆");
        }
    }

    /// <summary>
    /// 食物抽象类
    /// </summary>
    public abstract class Food
    {
        /// <summary>
        /// 输出
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("西红柿");
        }
    }


}
