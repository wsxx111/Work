using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
 * 将一个系统分割成一系列相互协作的类有一个很不好的副作用，那就是需要维护相关对象间的一致性，我们不希望为了维持一致性而使各个类紧密耦合，这样会给维护，扩展和重用都带来不便。而观察者模式的关键对象是主题Subject和观察者Obverser，一个Subject可以任意数目依赖它的Obverser,一旦Subject的状态发生变化，所有的Obverser都合一得到通知。Subject发出通知时，并不需要知道谁是它的观察者，也就是说，具体观察者是谁，它根本不需要知道，而任何一个具体的观察者不知道也不需要知道其他观察者的存在。
 * 
 * 当一个对象的改编需要同时改变其他对象的时候，而且它不知道具体有多少对象有待改变时，应该考虑使用观察者模式。
 * 
 * 观察者模式所做的工作其实就是在解除耦合，让耦合的双方都依赖于抽象，而不是依赖于具体，从而使得各自的变化都不会影响另一边的变化。
 * 
 * 观察者模式  又叫发布订阅模式，定义了一种一对多的依赖关系，让多个观察者对象同时监控某一个主题对象，这个主体对象在状态发生变化时，会同时监听某个主体对象，这个主体对象在状态发生变化时，会通知所有观察者对象，使它们能自动更新自己
 * 
 * Subject类是把所以观察者对象的引用保存在一个聚集里，每个主体都可以有任意数量的观察者，抽象主体提供一个借口，可以增加和删除观察者对象.是个主题或者抽象统治者，
 * Obverser类是抽象观察者，为所有的具体观察者定义一个接口，在得到主题的通知时更新自己
 * ConcreteSubject类是具体主题，讲有关状态存入具体观察者对象，在具体主题的内部状态改变时，给所有登记过的观察者发出通知
 * ConcreteObserver类是具体观察者，实现抽象观察者所要求的更新接口，一遍使本身的状态与主题的状态相协调
 * 
 * 
 * */
namespace DesignMethod.观察者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region 观察者模式

            TenXun tenXun = new TenXunGame("腾讯游戏", "建立了一个腾讯游戏");
            //添加订阅者
            tenXun.AddObserver(new Subscriber("学习硬件"));
            tenXun.AddObserver(new Subscriber("汤姆"));
            tenXun.Update();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除汤姆订阅者");
            tenXun.RemoveObserver(new Subscriber("汤姆"));
            tenXun.Update();

            #endregion 观察者模式

            #region 观察者模式使用委托

            //TenXunWt tenXun = new TenXunGameWt("腾讯游戏", "建立了一个腾讯游戏");
            ////添加订阅者
            //SubscriberWt lh = new SubscriberWt("学习硬件");
            //SubscriberWt tom = new SubscriberWt("汤姆");
            //tenXun.AddObserver(new 观察者模式.NotifyEventHandler(lh.ReceiveAndPrint));
            //tenXun.AddObserver(new 观察者模式.NotifyEventHandler(tom.ReceiveAndPrint));
            //tenXun.Update();
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("移除汤姆订阅者");
            //tenXun.RemoveObserver(new 观察者模式.NotifyEventHandler(tom.ReceiveAndPrint));
            //tenXun.Update();

            #endregion 观察者模式使用委托

            Console.ReadLine();
        }
    }



    //订阅号抽象类
    public abstract class TenXun
    {
        //保留订阅号列表
        private List<IObserver> observers = new List<IObserver>();

        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public string Info { get; set; }
        public string Symbol { get; set; }

        #region 新增对订阅号列表的维护操作

        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        #endregion 新增对订阅号列表的维护操作

        public void Update()
        {
            //遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }

    //具体订阅号
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info)
            : base(symbol, info)
        { }
    }


    //订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    //具体订阅类
    public class Subscriber : IObserver
    {
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("通知：{1}的{0}信息是: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }







    //委托--------------------------------------------------------------------------------------------------------------------------------------------------
    public delegate void NotifyEventHandler(object sender);

    //腾讯
    public class TenXunWt
    {
        //保留订阅号列表
        public event NotifyEventHandler NotifyEvent;

        public TenXunWt(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public string Info { get; set; }
        public string Symbol { get; set; }

        #region 新增对订阅号列表的维护操作

        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        #endregion 新增对订阅号列表的维护操作

        public void Update()
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }


    //腾讯游戏
    public class TenXunGameWt : TenXunWt
    {
        public TenXunGameWt(string symbol, string info)
            : base(symbol, info)
        {
        }
    }

    //委托
    public class SubscriberWt
    {
        public SubscriberWt(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ReceiveAndPrint(Object ob)
        {
            TenXunWt tenxun = ob as TenXunWt;
            if (tenxun != null)
            {
                Console.WriteLine("通知：{1}的{0}信息是: {2}", Name, tenxun.Symbol, tenxun.Info);
            }
        }
    }



}
