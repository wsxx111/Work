using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.命令模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);
            i.ExecuteCommand();
            Console.Read();
        }
    }


    //命令接受者
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }



    //命令抽象类
    public abstract class Command
    {
        //命令应该知道接受者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        public abstract void Action();
    }

    //具体指令
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        { }

        public override void Action()
        {
            _receiver.Run1000Meters();
        }
    }

    //调用命令执行要求
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

}
