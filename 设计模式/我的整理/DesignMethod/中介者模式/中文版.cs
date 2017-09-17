using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.中介者模式
{
    #region  解析
    /*    
     * 对象与对象之间存在大量的关联关系，这样势必会导致系统的结构变得很复杂，
     * 同时若一个对象发生改变，我们也需要跟踪与之相关联的对象，同时做出相应的处理。
     * 对象之间的连接增加会导致对象可复用性降低。
     *  系统的可扩展性低。增加一个新的对象，我们需要在其相关连的对象上面加上引用，
     *  这样就会导致系统的耦合性增高，使系统的灵活性和可扩展都降低。
     *  
     * 
     * 封装一个中介对象来封装系列对象之间的交互。中介者使各个对象不需要显示地相互引用，从而
     * 使其耦合性松散，而且可以独立地改变他们之间的交互
     * 
     * 由此我们可以看出中介者对象封装了对象之间的关联关系，导致中介者对象变得比较庞大，所承担的责任
     * 也比较多，它需要知道各个对象交互的细节，如果它出现问题，将导致整个系统的瘫痪。故当系统中出现
     * “多对多”的交互复杂的关系群时，千万别着急使用中介者模式，需要先分析下在设计上是否合理
     * 
     * 主要包括抽象中介者和具体中介者  抽象同事类 和具体同事类
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            抽象打牌1 a = new 张三();
            a.钱数 = 40;
            抽象打牌1 b = new 李四();
            b.钱数 = 50;
            a.结账(10, b);
            b.结账(5, a);
            Console.WriteLine("到现在为止,张三的钱数：" + a.钱数 + "和李四的钱：" + b.钱数);
            //======================================================================================




            Console.ReadKey();
        }
    }


    //----------------------------------------------------------------------------------------

    //显示生活中，两人打牌，一个人赢了会影响到对方状态的改变，如果不使用中介者模式的话，如下

    public abstract class 抽象打牌1
    {
        public int 钱数 { get; set; }

        public 抽象打牌1()
        {
            钱数 = 0;
        }
        public abstract void 结账(int count, 抽象打牌1 other);

    }

    public class 张三 : 抽象打牌1
    {
        public override void 结账(int count, 抽象打牌1 other)
        {
            this.钱数 += count;
            other.钱数 -= count;
        }
    }

    public class 李四 : 抽象打牌1
    {
        public override void 结账(int count, 抽象打牌1 other)
        {
            this.钱数 += count;
            other.钱数 -= count;
        }
    }

    //  这里如果a计算错误，会直接影响到b，关联的玩家更多的话，就会影响更多
    //能不能把算钱的任务交给程序或者算好的人去做呢，这时候就引入了中介者模式

    //==============================================================================================

    public abstract class 抽象打牌
    {
        public int 钱数 { get; set; }

        public 抽象打牌()
        {
            钱数 = 0;
        }
        public abstract void 结账(int count, 抽象中介者 m);

    }
    public class 牌手A : 抽象打牌
    {
        public override void 结账(int count, 抽象中介者 m)
        {
            m.AWin(count);
        }

    }

    public class 牌手B : 抽象打牌
    {
        public override void 结账(int count, 抽象中介者 m)
        {
            m.BWin(count);
        }

    }

    public class 牌手C : 抽象打牌
    {
        public override void 结账(int count, 抽象中介者 m)
        {
            m.CWin(count);
        }

    }


    public abstract class 抽象中介者
    {
        protected 抽象打牌 A;
        protected 抽象打牌 B;
        protected 抽象打牌 C;

        public 抽象中介者(抽象打牌 a, 抽象打牌 b, 抽象打牌 c)
        {
            A = a;
            B = b;
            C = c;
        }
        public abstract void AWin(int count);
        public abstract void BWin(int count);
        public abstract void CWin(int count);
    }

    public class 中介者 : 抽象中介者
    {
        public 中介者(抽象打牌 a, 抽象打牌 b, 抽象打牌 c)
            : base(a, b, c)
        {

        }
        public override void AWin(int count)
        {
            A.钱数 += count;
            B.钱数 += count/2;
            C.钱数 -= count;
        }
        public override void BWin(int count)
        {
            A.钱数 -= count;
            B.钱数 += count;
            C.钱数 -= count;
        }
        public override void CWin(int count)
        {
            A.钱数 += count/2;
            B.钱数 -= count;
            C.钱数 += count;
        }
    }

}
