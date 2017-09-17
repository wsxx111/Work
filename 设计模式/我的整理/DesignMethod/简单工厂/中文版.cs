using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.简单工厂
{
    #region  解析
    /* 
     *  属于创建型模式，又叫做静态工厂方法（Static Factory Method）模式，但不属于23种GOF设计模式之一。
     *  简单工厂模式是由一个工厂对象决定创建出哪一种产品类的实例  
     *   
     * */

    #endregion


    public class 测试类
    {
        public static void 运行()
        {
            性能考察 ability1 = 简单工厂.创建("宝马");
            ability1.性能();
            性能考察 ability2 = 简单工厂.创建("奔驰");
            ability2.性能();

            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------


    //抽象产品
    public interface 性能考察
    {
        void 性能();
    }

    //具体产品
    public class 宝马性能 : 性能考察
    {
        public void 性能()
        {
            Console.WriteLine("宝马车性能不赖");
        }
    }

    //具体产品
    public class 奔驰性能 : 性能考察
    {
        public void 性能()
        {
            Console.WriteLine("奔驰车性能杠杠的");
        }
    }

    public class 简单工厂
    {
        public static 性能考察 创建(string 考察车型)
        {
            性能考察 ab = null;
            if (考察车型 == "宝马")
            {
                ab = new 宝马性能();
            }
            else if (考察车型 == "奔驰")
            {
                ab = new 奔驰性能();
            }
            return ab;
        }

    }

}
