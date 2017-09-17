using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.状态模式
{
    #region  解析
    /* 当一个对象的行为取决于它的状态，并且它必须在运行时刻根据状态改变它的行为时，就可以考虑使用状态模式了   
     * 
     * 所谓的状态模式是允许对象在内部状态发生改变时改变它的行为，对象看起来好像修改了它的类
     * 
     * 有一个环境类：包括一些内部状态
     * 抽象状态类：定义了一个所有具体状态的共同接口，任何状态都实现这个相同的接口，这样状态之间就可以相互转化了
     * 具体状态类：用于请求环境类的请求，每一个具体状态类都提供了它对自己的实现，所有当环境类改变状态时行为也会跟着改变
     * 
     * 状态模式主要解决的是当控制一个对象状态转换的条件表达式国语复杂时的情况，把状态的判断逻辑转移到表示不同状态的一系列类当中，可以把复杂的判断逻辑简化。当然，如果这个状态判断 很简单，那就没有必要用状态模式了。
     * 
     * 状态模式的好处就是将与特定状态相关的行为局部化，并且将不同状态的行为分隔开来
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类2
    {
        public static void 运行()
        {
            房间 r1 = new 房间();
            r1.入住();
            r1.入住();
            r1.预定();
            r1.退订();
            r1.退房();
            //Console.WriteLine(r1.状态.StateTxt);
            Console.ReadKey();
        }
    }


    //-------------------------------------------------------------------------------------------

    public abstract class 状态
    {
        public string StateTxt { get; set; }

        public 房间 room { get; set; }

        public virtual void 预订()
        {
            Console.WriteLine("该房间状态为:" + this.StateTxt + ",不能预定");
        }

        public virtual void 入住()
        {
            Console.WriteLine("该房间状态为:" + this.StateTxt + ",不能入住");
        }

        public virtual void 退订()
        {
            Console.WriteLine("该房间状态为:" + this.StateTxt + ",不能退订");
        }

        public virtual void 退房()
        {
            Console.WriteLine("该房间状态为:" + this.StateTxt + ",不能退房");
        }
    }

    public class 空闲状态 : 状态
    {
        public 空闲状态(房间 r)
        {
            this.room = r;
            this.StateTxt = "空闲状态";
        }

        public override void 预订()
        {
            room.状态 = new 已预定状态(room);
            Console.WriteLine("成功预订");
        }

        public override void 入住()
        {
            room.状态 = new 已入住状态(room);
            Console.WriteLine("成功入住");
        }

    }

    public class 已预定状态 : 状态
    {
        public 已预定状态(房间 r)
        {
            this.room = r;
            this.StateTxt = "已预定状态";
        }

        public override void 退订()
        {
            room.状态 = new 已预定状态(room);
            Console.WriteLine("成功退订");
        }

        public override void 入住()
        {
            room.状态 = new 已入住状态(room);
            Console.WriteLine("成功入住");
        }

    }

    public class 已入住状态 : 状态
    {
        public 已入住状态(房间 r)
        {
            this.room = r;
            this.StateTxt = "已入住状态";
        }

        public override void 退房()
        {
            room.状态 = new 空闲状态(room);
            Console.WriteLine("成功退房");
        }

    }

    public class 房间
    {
        private 状态 state;

        public 房间()
        {
            this.state = new 空闲状态(this);
        }

        public 状态 状态
        {
            get { return state; }
            set
            {
                this.state = value;
            }
        }


        public void 预定()
        {
            state.预订();
        }

        public void 入住()
        {
            state.入住();
        }

        public void 退订()
        {
            state.退订();
        }

        public void 退房()
        {
            state.退房();
        }

    }

}
