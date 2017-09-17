using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.装饰者模式
{
    #region  解析
    /*    
     * 动态的给一个对象添加一些额外职责。比继承灵活。
     * 
     * 装饰者模式隐含的是通过一条条装饰链去实现具体对象，每一条装饰链都始于一个Componet对象，每个装饰者对象后面紧跟着另一个装饰者对象，而对象链终于ConcreteComponet对象。
     * 相信大家都有用过PS，而且都了解过PS中图层的原理，当我们P图片时候使用图层可以实现很多效果，
     * 而且如果我们觉得其中一个图层效果不好看我们可以直接删除，而不影响其他图层，我们每次P出来的照片都是一层层图层的叠加得到的
     * 
     * 对于像透明的动态地给对象添加新的职责的时候，对象的这些职责在未来存在增加或者减少的可能，
     * 有效避免了使用继承的方式扩展对象功能而带来的灵活性差，子类无线制扩张的问题
     * 在灵活性和扩展性之间找到完美的平衡点
     * 
     * 装饰者 装饰链不能过长，否则会影响效率
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            Message m = new IPMessage();
            AddMessage m1 = new AddSourceMessage(m, "127.0.0.1");
            AddMessage m2 = new AddDestinationMessage(m1, "123.1.11.3");
            AddMessage m3 = new AddLockKeyMessage(m2, "s1a32csa21");
            m3.SendMessage();
            Console.ReadKey();
        }
    }


    //----------------------------------------------------------------------------------------


    
    public abstract class Message
    {
        public abstract void SendMessage();
    }

    public class IPMessage : Message
    {
        public override void SendMessage()
        {
            Console.WriteLine("原内部信息");
        }
    }

    /// <summary>
    /// 添加信息抽象类
    /// </summary>
    public abstract class AddMessage : Message
    {
        private Message message;
        public AddMessage(Message m)
        {
            this.message = m;
        }
        public override void SendMessage()
        {
            if (message != null)
            {
                message.SendMessage();
            }
        }
    }

    /// <summary>
    /// 添加源地址信息
    /// </summary>
    public class AddSourceMessage : AddMessage
    {
        public string Source{get;set;}
        public AddSourceMessage(Message m,string s): base(m)
        {           
            this.Source=s;
        }
        public void addSourceMessage()
        {
            Console.WriteLine("成功添加IP源地址为"+this.Source);
        }
        public override void SendMessage()
        {
            base.SendMessage();
            addSourceMessage();
        }
    }

    /// <summary>
    /// 添加目标地址信息
    /// </summary>
    public class AddDestinationMessage : AddMessage
    {
        public string Destination { get; set; }
        public AddDestinationMessage(Message m, string d): base(m)
        {
            this.Destination = d;
        }
        public void addDestinationMessage()
        {
            Console.WriteLine("成功添加IP目标地址为" + this.Destination);
        }
        public override void SendMessage()
        {
            base.SendMessage();
            addDestinationMessage();
        }
    }

    /// <summary>
    /// 添加秘钥信息
    /// </summary>
    public class AddLockKeyMessage : AddMessage
    {
        public string Key { get; set; }
        public AddLockKeyMessage(Message m, string k): base(m)
        {
            this.Key = k;
        }
        public void addLockKeyMessage()
        {
            Console.WriteLine("成功添加秘钥为" + this.Key);
        }
        public override void SendMessage()
        {
            base.SendMessage();
            addLockKeyMessage();
        }
    }

}
