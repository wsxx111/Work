using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.建造者
{
    #region  解析
    /* 
     *  将一个复杂对象的构造与它的表示分离，使同样的构建过程可以创建不同的表示，
     *  
     * 1. builder：给出一个抽象接口，以规范产品对象的各个组成成分的建造。这个接口规定要实现复杂对象的哪些部分的创建，并不涉及具体的对象部件的创建。
     * 2. ConcreteBuilder：实现Builder接口，针对不同的商业逻辑，具体化复杂对象的各部分的创建。 在建造过程完成后，提供产品的实例。
     * 3. Director：调用具体建造者来创建复杂对象的各个部分，在指导者中不涉及具体产品的信息，只负责保证对象各部分完整创建或按某种顺序创建。
     * 4. Product：要创建的复杂对象。
     * 
     *  当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。
     *  当构造过程必须允许被构造的对象有不同表示时。
     *   
     * 使用建造者模式的好处：
     *   1.使用建造者模式可以使客户端不必知道产品内部组成的细节。
     *   2.具体的建造者类之间是相互独立的，对系统的扩展非常有利。
     *   3.由于具体的建造者是独立的，因此可以对建造过程逐步细化，而不对其他的模块产生任何影响。
     * 使用建造模式的场合：
     *   1.创建一些复杂的对象时，这些对象的内部组成构件间的建造顺序是稳定的，但是对象的内部组成构件面临着复杂的变化。
     *   2.要创建的复杂对象的算法，独立于该对象的组成部分，也独立于组成部分的装配方法时。
     *   
     * */

    #endregion


    public class 测试类
    {
        public static void 运行()
        {
            //初始化指挥者、构造者
            面试官 mian = new 面试官();
            考生 huang = new 黄晓明();
            考生 ang = new AngelaBaby();
            mian.面试(huang);
            mian.面试(ang);
            得分情况 sc = huang.总得分();
            sc.显示();
            得分情况 sc2 = ang.总得分();
            sc2.显示();
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------

    public class 面试官
    {
        public void 面试(考生 student)
        {
            //按照一定顺序表演
            student.自我介绍();
            student.才艺表演();
            student.即兴表演();
        }
    }


    //抽象产品
    public abstract class 考生
    {
        public abstract void 自我介绍();
        public abstract void 才艺表演();
        public abstract void 即兴表演();

        public abstract 得分情况 总得分();
    }

    public class 得分情况
    {
        public IList<string> 各项得分 = new List<string>();

        public void Add(string 考项, double 某项得分)
        {
            各项得分.Add(考项 + 某项得分);
        }

        public void 显示()
        {
            Console.WriteLine("以下是得分情况");
            foreach (string score in 各项得分)
            {
                Console.WriteLine("" + score + "");
            }
            Console.WriteLine("--------------");
        }
    }

    //具体创建者
    public class 黄晓明 : 考生
    {
        private 得分情况 得分 = new 得分情况();

        public override void 自我介绍()
        {
            得分.Add("自我介绍", 98);
        }

        public override void 才艺表演()
        {
            得分.Add("才艺表演",88);
        }

        public override void 即兴表演()
        {
            得分.Add("即兴表演",80);
        }


        public override 得分情况 总得分()
        {
            return 得分;
        }
    }

    //具体创建者
    public class AngelaBaby : 考生
    {
        private 得分情况 得分 = new 得分情况();

        public override void 自我介绍()
        {
            得分.Add("自我介绍", 86);
        }

        public override void 才艺表演()
        {
            得分.Add("才艺表演", 95);
        }

        public override void 即兴表演()
        {
            得分.Add("即兴表演", 92);
        }


        public override 得分情况 总得分()
        {
            return 得分;
        }
    }

}
