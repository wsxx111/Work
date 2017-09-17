using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.访问者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            ObjectStructure objectstructure = new ObjectStructure();
            foreach (Element e in objectstructure.Element)
            {
                e.Accept(new ConcreteVistor());
            }

            Console.Read();
        }
    }

    //对象结构
    public class ObjectStructure
    {
        private ArrayList element = new ArrayList();

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = ran.Next(10);
                if (ranNum > 5)
                {
                    element.Add(new ElementA());
                }
                else
                {
                    element.Add(new ElementB());
                }
            }
        }

        public ArrayList Element
        {
            get { return element; }
        }


    }

    //抽象访问者
    public interface IVistor
    {
        void Visit(ElementA a);

        void Visit(ElementB b);
    }

    //具体访问者
    public class ConcreteVistor : IVistor
    {
        //再去调用元素
        public void Visit(ElementA a)
        {
            a.Print();
        }

        public void Visit(ElementB b)
        {
            b.Print();
        }
    }


    //抽象元素角色
    public abstract class Element
    {
        public abstract void Accept(IVistor vistor);

        public abstract void Print();
    }


    public class ElementA : Element
    {
        public override void Accept(IVistor vistor)
        {
            //调用访问者vilist
            vistor.Visit(this);
        }

        public override void Print()
        {
            Console.WriteLine("我是元素A");
        }
    }


    public class ElementB : Element
    {
        public override void Accept(IVistor vistor)
        {
            vistor.Visit(this);
        }

        public override void Print()
        {
            Console.WriteLine("我是元素B");
        }
    }




}
