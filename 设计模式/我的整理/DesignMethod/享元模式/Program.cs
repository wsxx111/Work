using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.享元模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //定义外部状态
            int externalstate = 10;
            //初始化享元工厂
            FlyweightFactory factory = new FlyweightFactory();
            //判断是否有A字符
            Flyweight fa = factory.GetFlyweight("A");
            if (fa != null)
            {
                fa.Operation(externalstate);
            }
            //判断B字符
            Flyweight fb = factory.GetFlyweight("B");
            if (fb != null)
            {
                fb.Operation(externalstate);
            }
            //判断C字符
            Flyweight fc = factory.GetFlyweight("C");
            if (fc != null)
            {
                fc.Operation(externalstate);
            }
            //判断D字符
            Flyweight fd = factory.GetFlyweight("D");
            if (fd != null)
            {
                fd.Operation(externalstate);
            }
            else
            {
                Console.WriteLine("不存在字符串D");
                ConcreteFlyweight d = new ConcreteFlyweight("D");
                factory.flyweights.Add("D", d);
            }
            Console.WriteLine("");
            Console.Read();
        }
    }

    //享元工厂
    public class FlyweightFactory
    {
        public Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("A", new ConcreteFlyweight("A"));
            flyweights.Add("B", new ConcreteFlyweight("B"));
            flyweights.Add("C", new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            Flyweight flyweight = null;
            if (flyweights.ContainsKey(key))
            {
                return flyweights[key] as Flyweight;
            }

            if (flyweights == null)
            {
                Console.WriteLine("驻留池中不存在字符串" + key);
                flyweight = new ConcreteFlyweight(key);
            }
            return flyweight as Flyweight;
        }
    }

    //享元抽象类
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    //享元对象
    public class ConcreteFlyweight : Flyweight
    {
        private string intrinsicstate;

        public ConcreteFlyweight(string name)
        {
            this.intrinsicstate = name;
        }

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体实现类：intrinsicstate{0},extrinsicstate{1}", intrinsicstate, extrinsicstate);
        }
    }

}
