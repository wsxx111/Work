using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.中介者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region 未使用观察者模式与状态者模式

            //AbstractCardPartner A = new ParterA();
            //A.MoneyCount = 20;
            //AbstractCardPartner B = new ParterB();
            //B.MoneyCount = 20;
            //AbstractMediator mediator = new Mediator(A, B);
            //mediator.AWin(5);
            //Console.WriteLine("A:{0}", A.MoneyCount);
            //Console.WriteLine("B:{0}", B.MoneyCount);
            //mediator.BWin(5);
            //Console.WriteLine("B:{0}", B.MoneyCount);
            //Console.WriteLine("A:{0}", A.MoneyCount);
            //Console.Read();

            #endregion 未使用观察者模式与状态者模式

            #region 完善中介者模式

            AbstractCardPartner A = new ParterA();
            AbstractCardPartner B = new ParterB();
            // 初始钱
            A.MoneyCount = 20;
            B.MoneyCount = 20;
            AbstractMediator mediator = new MediatorPater(new InitState());
            // A,B玩家进入平台进行游戏
            mediator.Enter(A);
            mediator.Enter(B);
            // A赢了
            mediator.State = new AWinState(mediator);
            mediator.ChangeCount(5);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);
            // 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount);
            // 应该是15
            // B 赢了
            mediator.State = new BWinState(mediator);
            mediator.ChangeCount(10);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);
            // 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount);
            // 应该是15
            Console.Read();

            #endregion 完善中介者模式
        }
    }


    public class InitState : State
    {
        public InitState()
        {
            Console.WriteLine("游戏才刚刚开始，暂时还没有玩家胜出");
        }

        public override void ChangeCount(int Count)
        {
            return;
        }
    }

    //A赢状态
    public class AWinState : State
    {
        public AWinState(AbstractMediator concretemediator)
        {
            this.mediator = concretemediator;
        }

        public override void ChangeCount(int Count)
        {
            foreach (AbstractCardPartner p in mediator.list)
            {
                ParterA a = p as ParterA;
                if (a != null)
                {
                    a.MoneyCount += Count;
                }
                else
                {
                    p.MoneyCount -= Count;
                }
            }
        }
    }

    //B赢状态
    public class BWinState : State
    {
        public BWinState(AbstractMediator concretemediator)
        {
            this.mediator = concretemediator;
        }

        public override void ChangeCount(int Count)
        {
            foreach (AbstractCardPartner p in mediator.list)
            {
                ParterB b = p as ParterB;
                if (b != null)
                {
                    b.MoneyCount += Count;
                }
                else
                {
                    p.MoneyCount -= Count;
                }
            }
        }
    }



    //抽象牌友类
    public abstract class AbstractCardPartner
    {
        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }

        public int MoneyCount { get; set; }

        public abstract void ChangeCount(int Count, AbstractMediator mediator);
    }

    //抽象中介者
    public abstract class AbstractMediator
    {
        public List<AbstractCardPartner> list = new List<AbstractCardPartner>();

        public AbstractMediator(State state)
        {
            this.State = state;
        }

        public State State { get; set; }

        public void ChangeCount(int Count)
        {
            State.ChangeCount(Count);
        }

        public void Enter(AbstractCardPartner partner)
        {
            list.Add(partner);
        }

        public void Exit(AbstractCardPartner partner)
        {
            list.Remove(partner);
        }
    }

    //具体中介者
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(State initState)
            : base(initState)
        {
        }
    }

    //牌友A类
    public class ParterA : AbstractCardPartner
    {
        //依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    //牌友B类
    public class ParterB : AbstractCardPartner
    {
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    //抽象状态类
    public abstract class State
    {
        protected AbstractMediator mediator;

        public abstract void ChangeCount(int Count);
    }

}
