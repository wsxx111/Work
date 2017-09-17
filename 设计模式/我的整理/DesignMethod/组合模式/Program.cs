using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
 * 组合模式，是讲对象组合成树形结构以表示部分和整体的层次结构，组合模式使得用户对单个对象和组合对象的使用具有一致性
 * 
 * 当需求中体现部分与整体层次的结构时，以及你希望用户可以忽略组合对象与单个对象的不同，同意的使用组合结构中的所有对象时，就可以考虑使用组合模式了。
 * 
 * */

namespace DesignMethod.组合模式
{
    public class Program : OpenDesign
    {
        public static void Open1()
        {
            #region 安全式组合模式

            //ComplexGraphics2 complexGraphics = new ComplexGraphics2("复杂图形");
            //complexGraphics.Add(new Line2("线A"));
            //ComplexGraphics2 CompositeCG = new ComplexGraphics2("一个园和一条线");
            //CompositeCG.Add(new Circle2("圆"));
            //CompositeCG.Add(new Line2("线段B"));
            //complexGraphics.Add(CompositeCG);
            //Line2 l = new Line2("线段C");
            //complexGraphics.Add(l);
            ////显示复杂图形画法
            //Console.WriteLine("复杂图形的绘制如下：");
            //complexGraphics.Draw();
            //Console.WriteLine("复杂图形绘制完成");
            //Console.WriteLine("");
            ////移除一个组件再显示复杂图形的画法
            //complexGraphics.Remote(l);
            //Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            //complexGraphics.Draw();
            //Console.WriteLine("复杂图形绘制完成");
            //Console.Read();

            #endregion 安全式组合模式
        }

        public override void Open()
        {
            #region 透明式组合模式

            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            CompositeCG.Add(new Circle("圆"));
            CompositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(CompositeCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);
            //显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("");
            //移除一个组件再显示复杂图形的画法
            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.Read();

            #endregion 透明式组合模式

            #region 安全组合模式

            Open1();

            #endregion 安全组合模式
        }
    }

    /// <summary>
    /// 复杂图形
    /// </summary>
    public class ComplexGraphics : Graphics
    {
        private List<Graphics> complexGraphicsList = new List<Graphics>();

        public ComplexGraphics(string name)
            : base(name)
        { }

        public override void Add(Graphics g)
        {
            complexGraphicsList.Add(g);
        }

        public override void Draw()
        {
            foreach (Graphics g in complexGraphicsList)
            {
                g.Draw();
            }
        }

        public override void Remove(Graphics g)
        {
            complexGraphicsList.Remove(g);
        }
    }


    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class Graphics
    {
        public Graphics(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void Add(Graphics g);

        public abstract void Draw();

        public abstract void Remove(Graphics g);
    }

    /// <summary>
    /// 线
    /// </summary>
    public class Line : Graphics
    {
        public Line(string name)
            : base(name)
        { }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向线添加其他图形");
        }

        public override void Draw()
        {
            Console.WriteLine("画：" + Name);
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向线添加其他图形");
        }
    }

    /// <summary>
    /// 圆
    /// </summary>
    public class Circle : Graphics
    {
        public Circle(string name)
            : base(name)
        { }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向圆添加其他图形");
        }

        public override void Draw()
        {
            Console.WriteLine("画：" + Name);
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向圆添加其他图形");
        }
    }

}
