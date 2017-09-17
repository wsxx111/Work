using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.访问者模式
{
    #region  解析
    /*   
     * 访问者模式
     * 增加Action  即增加一个访问者很容易
     * 但对于增加Person 修改ObjectStru 数据结构会很不适合
     * 所以访问者模式适用于数据结构比较稳定的情况
     * 
     * */

    #endregion


    public class 新版
    {
        public static void 运行()
        {
            Action success = new Success();
            ObjectStru obj = new ObjectStru();
            obj.Attach(new Man());
            obj.Attach(new Woman());
            obj.Attach(new GoldPerson());
            obj.Display(success);            
        }
    }


    //----------------------------------------------------------------------------------------
    public abstract class Action
    {
        public abstract void GetManConclusion(Man man);
        public abstract void GetWomanConclusion(Woman woman);
        public abstract void GetGoldConclusion(GoldPerson gold);
        
    }

    public class Success : Action
    {
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine("男人成功，背后多半有个伟大的女人");
        }
        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine("女人成功，背后多半有个不成功的男人");
        }
        public override void GetGoldConclusion(GoldPerson gold)
        {
            Console.WriteLine("so easy");
        }
    }



    public class Fail : Action
    {
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine("男人失败，纯属没用");
        }
        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine("女人失败，有情可原");
        }

        public override void GetGoldConclusion(GoldPerson gold)
        {
            Console.WriteLine("impossible");
        }
    }

    public class ObjectStru
    {
        private IList<Person> elements = new List<Person>();
    
        //增加
        public void Attach(Person p)
        {
            elements.Add(p);
        }

        //移除
        public void Remove(Person p)
        {
            elements.Remove(p);
        }

        //查看显示
        public void Display(Action visitor)
        {
            foreach (var e in elements)
            {              
                e.Accept(visitor);
            }
        }
    }

    public abstract class Person
    {
        public abstract void Accept(Action visitor);
    }


    public class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }
    }

    public class Woman:Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }

    public class GoldPerson : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetGoldConclusion(this);
        }
    }
}
