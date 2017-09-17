using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.抽象工厂
{
    #region  解析
    /* 为创建一组相关或相互依赖的对象提供一个接口，而且无需指定他们的具体类。
     * 抽象工厂模式是所有形态的工厂模式中最为抽象和最具一般性的一种形态。
     * 抽象工厂模式是指当有多个抽象角色时，使用的一种工厂模式。
     * 抽象工厂模式可以向客户端提供一个接口，使客户端在不必指定产品的具体的情况下，创建多个产品族中的产品对象。
     * 根据里氏替换原则，任何接受父类型的地方，都应当能够接受子类型。
     * 因此，实际上系统所需要的，仅仅是类型与这些抽象产品角色相同的一些实例，而不是这些抽象产品的实例。
     * 也就是这些抽象产品的具体子类的实例。
     * 工厂类负责创建抽象产品的具体子类的实例。
     * 抽象工厂模式针对的是多个产品等级结构。
     * 优点：
        1.它分离了具体的类
        2.它使得易于交换产品系列
        3.它有利于产品的一致性
       缺点：
        难以支持新种类的产品
     * */

    #endregion


    public class 测试类
    {
        public static void 运行()
        {
            抽象工厂类 gongChang = new 长兴工厂();
            抽象车框 cheKuang = gongChang.生产车框零件();
            抽象发动机 fadongji = gongChang.生产发动机零件();
            cheKuang.车框的大小();
            fadongji.发动机的重量();

            抽象工厂类 dazong = new 大众工厂();
            抽象车框 cheKuang2 = dazong.生产车框零件();
            抽象发动机 fadongji2 = gongChang.生产发动机零件();
            cheKuang2.车框的大小();
            fadongji2.发动机的重量();
        }
    }



    //----------------------------------------------------------------------------------------

    public abstract class 抽象工厂类
    {
        public abstract 抽象轮胎 生产轮胎零件();
        public abstract 抽象车框 生产车框零件();
        public abstract 抽象发动机 生产发动机零件();
    }

    public class 长兴工厂 : 抽象工厂类
    {
        public override 抽象轮胎 生产轮胎零件()
        {
            return new 长兴轮胎();
        }

        public override 抽象车框 生产车框零件()
        {
            return new 长兴车框();
        }

        public override 抽象发动机 生产发动机零件()
        {
            return new 长兴发动机();
        }
       
    }

    public class 大众工厂 : 抽象工厂类
    {
        public override 抽象轮胎 生产轮胎零件()
        {
            return new 大众轮胎();
        }

        public override 抽象车框 生产车框零件()
        {
            return new 大众车框();
        }

        public override 抽象发动机 生产发动机零件()
        {
            return new 大众发动机();
        }

    }


    public abstract class 抽象轮胎
    {
        public abstract void 轮胎的样子();
    }

    public abstract class 抽象车框
    {
        public abstract void 车框的大小();
    }

    public abstract class 抽象发动机
    {
        public abstract void 发动机的重量();
    }


    public class 长兴轮胎 : 抽象轮胎
    {
        public override void 轮胎的样子()
        {
            Console.WriteLine("长兴轮胎样子好看");
        }
    }

    public class 长兴车框 : 抽象车框
    {
        public override void 车框的大小()
        {
            Console.WriteLine("长兴车框的不大");
        }
    }

    public class 长兴发动机 : 抽象发动机
    {
        public override void 发动机的重量()
        {
            Console.WriteLine("长兴发动机不赖");
        }
    }

    public class 大众轮胎 : 抽象轮胎
    {
        public override void 轮胎的样子()
        {
            Console.WriteLine("大众轮胎样子好看");
        }
    }

    public class 大众车框 : 抽象车框
    {
        public override void 车框的大小()
        {
            Console.WriteLine("大众车框的不大");
        }
    }

    public class 大众发动机 : 抽象发动机
    {
        public override void 发动机的重量()
        {
            Console.WriteLine("大众发动机不赖");
        }
    }


    
}
