using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.桥接模式
{
    #region  解析
    /*    
     * 
     *  桥接模式主要是为了解决，一个对象的多个维度的变化因素的变化太快，难以控制的问题，我们通过将每个维度的变化因素进行抽象，
     *  然后我们的对象只要依赖于抽象即可，具体的实现调用我们不关心，通过对象组合的方式，我们就能组合出我们想要的对象。
     *  无疑这是一种非常灵活的也是满足设计模式的原则
     *  的，抽象和实现分离，使他们各自发生变化都不受对方的影响
     * 
     * 
     * 在软件系统中，某些类型由于自身的逻辑，它具有两个或多个维度的变化，那么如何应对这种“多维度的变化”？
     * 如何利用面向对象的技术来使得该类型能够轻松的沿着多个方向进行变化，而又不引入额外的复杂度？这就要使用Bridge模式。
     *  桥接模式（Bridge）来做(多维度变化);
     *  Bridge模式使用“对象间的组合关系”解耦了抽象和实现之间固有的绑定关系，使得抽象和实现可以沿着各自的维度来变化。
     *  所谓抽象和实现沿着各自维度的变化，即“子类化”它们，得到各个子类之后，便可以任意它们，从而获得不同路上的不同汽车。
     * Bridge模式有时候类似于多继承方案，但是多继承方案往往违背了类的单一职责原则（即一个类只有一个变化的原因），复用性比较差。
     * Bridge模式是比多继承方案更好的解决方法。
     * Bridge模式的应用一般在“两个非常强的变化维度”，有时候即使有两个变化的维度，
     * 但是某个方向的变化维度并不剧烈——换言之两个变化不会导致纵横交错的结果，并不一定要使用Bridge模式。
     * 
     * 桥接模式的主要目的是将一个对象的变化因素抽象出来，不是通过类继承的方式来满足这个因素的变化，而是通过对象组合的方式来依赖因素的抽象，这样当依赖的因素
     * 的具体实现发生变化后，而我们的具体的引用却不用发生改变，因为我们的对象是依赖于抽象的，而不是具体的实现。
     * 
     * 一个对象有多个变化因素的时候，通过抽象这些变化因素，将依赖具体实现，修改为依赖抽象。
     * 当某个变化因素在多个对象中共享时。我们可以抽象出这个变化因素，然后实现这些不同的变化因素。
     * 
     * 在以下的情况下应当使用桥梁模式：
     * 1．如果一个系统需要在构件的抽象化角色和具体化角色之间增加更多的灵活性，避免在两个层次之间建立静态的联系。
     * 2．设计要求实现化角色的任何改变不应当影响客户端，或者说实现化角色的改变对客户端是完全透明的。
     * 3．一个构件有多于一个的抽象化角色和实现化角色，系统需要它们之间进行动态耦合。
     * 4．虽然在系统中使用继承是没有问题的，但是由于抽象化角色和具体化角色需要独立变化，设计要求需要独立管理这两者。
     * 
     * 不同的人开着不同的汽车在不同的路上行驶(三个维度);
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            不同的人 people = new 男人();
            people.行驶();
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------


    public abstract class 不同的人
    {
        public 不同的车 car { get; set; }      

        public abstract void 行驶();
    }


    public class 男人 : 不同的人
    {
        public override void 行驶()
        {
            Console.WriteLine("男人");
            car.行驶();
            Console.WriteLine("行驶");
        }
    }


    public class 女人 : 不同的人
    {
        public override void 行驶()
        {
            Console.WriteLine("女人");
            car.行驶();
            Console.WriteLine("行驶");
        }
    }

    public abstract class 不同的车
    {
        public 不同的道路 road { get; set; }
        public abstract void 行驶();
    }


    public class 小汽车 : 不同的车
    {
        public override void 行驶()
        {
            Console.WriteLine("开着小汽车");
            road.行驶();
        }
        
    }


    public class 公共汽车 : 不同的车
    {
        public override void 行驶()
        {
            Console.WriteLine("开着公共汽车");
            road.行驶();
        }
    }

    public abstract class 不同的道路
    {
        public abstract void 行驶();
    }


    public class 高速公路 : 不同的道路
    {
        public override void 行驶()
        {
            Console.WriteLine("在高速公路上");
        }
    }


    public class 市区街道 : 不同的道路
    {
        public override void 行驶()
        {
            Console.WriteLine("在市区街道上");
        }
    }

}
