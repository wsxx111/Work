using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.建造者
{
    public class 新的解析
    {
        public static void 运行()
        {           
            老板 boss = new 老板();
            组装人员 leveon = new 联想组装人员A();
            组装人员 dell = new 戴尔组装人员A();
            //布置任务
            boss.安排任务(leveon);
            boss.安排任务(dell);
            //组装好给老板
            电脑 lianxiang=leveon.GetComputer();
            电脑 daiar = dell.GetComputer();
            //老板给客户
            lianxiang.Show();
            daiar.Show();
            Console.ReadKey();
        }
    }


    /*
     * 概念：  将一个复杂对象的构造与它的表示分离，使同样的构建过程可以创建不同的表示。
     * 有时需要创建一个复杂的对象，这个复杂的对象是 由一些其他的对象按照一定的步骤组合而成的。
     * 现实中，公司要派一个人去采购两台电脑，一个是戴尔的，一个是联想的。采购员到商场给公司的 老板讲的时候，
     * 不可能说要什么主机，什么键盘，什么鼠标之类的， 而是直接给老板讲要两台不同表现样式的成品电脑就行了，关于电脑的组装部分由老板
     * 自己考虑就行了，老板直接交给特定的组装人员就行了。  这里电脑就是一个复杂的对象，包括主机 cpu,显示器，鼠标等等。是通过一定的步骤进行组装的，联想电脑和戴尔电脑的
     * 组装步骤都是一样的。这就可以应用建造者模式，包括如果采购员再需要惠普的电脑，一样都能适应。
     * 这里 采购员就是客户端 电脑是那个复杂的对象   老板就是Director  不同品牌的组装人员就是各个builder 各个组装人员可以抽象成一个抽象建造者对象
     * 
     * 建造者主要是用于创建一些复杂的对象，这些对象内部构建间的建造顺序通常是稳定的，但对象内部的构建通常面临着复杂的变化
     * 建造者模式是在当创建复杂对象的算法应该独立于该对象的组成部分以及她们装配方式时适用的模式
     *
     * * */

    ///小王和小李难道会自愿地去组装嘛，谁不想休息的，这必须有一个人叫他们去组装才会去的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    /// 指挥创建过程类,老板是指挥者,告诉做哪些，这些都是组装人员会的，指挥者是构建一个使用Builder接口的对象
    public class 老板
    {
        public void 安排任务(组装人员 builder)
        {
            builder.BuilderPartCPU();
            builder.BuilderPartMainBoard();
        }
    }

    //Builder是为创建一个Pruduct对象的各个部件指定的抽象接口
    //组装人员只负责按照老板的指示按照规定的任务步骤去完成指示
    public abstract class 组装人员
    {
        //装CPU
        public abstract void BuilderPartCPU();

        //装主机
        public abstract void BuilderPartMainBoard();

        //组装好的电脑给老板交差
        public abstract 电脑 GetComputer();

    }

    //具体建造者实现Builder的接口，构造和装配各个部件
    public class 联想组装人员A : 组装人员
    {
        public 电脑 computer = new 电脑("联想牌");
        public override void BuilderPartCPU()
        {
            computer.Add("联想牌CPU");
        }
        public override void BuilderPartMainBoard()
        {
            computer.Add("联想牌主机");
        }
        //给老板交差
        public override 电脑 GetComputer()
        {
            return computer;
        }
    }

    public class 戴尔组装人员A : 组装人员
    {
        public 电脑 computer = new 电脑("戴尔牌");
        public override void BuilderPartCPU()
        {
            computer.Add("戴尔牌CPU");
        }
        public override void BuilderPartMainBoard()
        {
            computer.Add("戴尔牌主机");
        }
        public override 电脑 GetComputer()
        {
            return computer;
        }
    }

    public class 电脑
    {
        private string Brand = "";

        public 电脑(string brand)
        {
            this.Brand = brand;
        }
        // 电脑组件集合
        private IList<string> parts = new List<string>();

        // 把单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine(this.Brand+"电脑已准备好");
        }
    }

}