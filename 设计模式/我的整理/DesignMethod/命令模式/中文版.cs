using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.命令模式
{
    #region  解析
    /*    
     * 命令模式的本质是对命令进行封装，将发出命令的责任和执行命令的责任分割开
     * 每一个命令都是一个操作：请求的一方发出请求，要求执行一个操作；接收的一方收到请求，并执行操作。
     * 命令模式允许请求的一方和接收的一方独立开来，使得请求的一方不必知道接收请求的一方的接口，更不必知道请求是怎么被接收，以及操作是否被执行、何时被执行，以及是怎么被执行的。
     * 命令模式的关键在于引入了抽象命令接口，且发送者针对抽象命令接口编程，只有实现了抽象命令接口的具体命令才能与接收者相关联。
     * 
     * 优点：
     * 1.降低对象之间的耦合度。
     * 2.新的命令可以很容易地加入到系统中。
     * 3.可以比较容易地设计一个组合命令。
     * 4.调用同一方法实现不同的功能
     * 
     * 缺点：
     * 使用命令模式可能会导致某些系统有过多的具体命令类。
     * 因为针对每一个命令都需要设计一个具体命令类，因此某些系统可能需要大量具体命令类，这将影响命令模式的使用。
     * 
     * 适用环境
     * 1.系统需要将请求调用者和请求接收者解耦，使得调用者和接收者不直接交互。
     * 2.系统需要在不同的时间指定请求、将请求排队和执行请求。
     * 3.系统需要支持命令的撤销(Undo)操作和恢复(Redo)操作。
     * 4.系统需要将一组操作组合在一起，即支持宏命令。
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            电视机 tv = new 电视机();
            执行命令 com= new 开机命令(tv);
            执行命令 com2 = new 关机命令(tv);
            执行命令 com3 = new 切换命令(tv,5);
            com.执行命令();
            com2.执行命令();
            com3.执行命令();

           
           
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------


    //接收者
    public class 电视机
    {
        public int 当前频道 = 0;
        public void 打开()
        {
            Console.WriteLine("电视机已打开");
        }
        public void 关闭()
        {
            Console.WriteLine("电视机已关闭");
        }
        public void 换台(int 要换的台)
        {
            this.当前频道 = 要换的台;
            Console.WriteLine("现在换台后电视机的频道是：" + 要换的台);
        }
    }

    public interface 执行命令
    {
        void 执行命令();
    }

    public class 开机命令 : 执行命令
    {
        private 电视机 tv;

        public 开机命令(电视机 tvIn)
        {
            this.tv = tvIn;
        }

        public void 执行命令()
        {
            this.tv.打开();
        }
    }

    public class 关机命令 : 执行命令
    {
        private 电视机 tv;

        public 关机命令(电视机 tvIn)
        {
            this.tv = tvIn;
        }

        public void 执行命令()
        {
            this.tv.关闭();
        }
    }


    public class 切换命令 : 执行命令
    {
        private 电视机 tv;
        private int Channel;

        public 切换命令(电视机 tvIn,int ChannelIn)
        {
            this.tv = tvIn;
            this.Channel = ChannelIn;
        }

        public void 执行命令()
        {
            this.tv.换台(Channel);
        }
    }

   


}
