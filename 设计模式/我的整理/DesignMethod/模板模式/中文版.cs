using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cc.模板模式
{
    #region  解析
    /*    
     * 又叫模板方法模式，在一个方法中定义一个算法的骨架，而将一些步骤延迟到子类中。
     * 模板方法使得子类可以在不改变算法结构的情冴下，重新定义算法中的某些步骤。
     * 
     *通常我们会遇到这样的一个问题：我们知道一个算法所需的关键步聚，并确定了这些步聚的执行顺序。
     *但是某些步聚的具体实现是未知的，或者是某些步聚的实现与具体的环境相关。
     *模板方法模式把我们不知道具体实现的步聚封装成抽象方法，
     *提供一些按正确顺序调用它们的具体方法(这些具体方法统称为模板方法)，这样构成一个抽象基类
     *子类通过继承这个抽象基类去实现各个步聚的抽象方法，而工作流程却由父类来控制。
     * 
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            咖啡 yin = new 咖啡();
            yin.制作();           
            饮料 yin2 = new 茶();
            yin2.制作();
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------

    //    加工流程：
    //    咖啡冲泡法：1.把水煮沸、2.用沸水冲泡咖啡、3.倒进杯子、4.加糖和牛奶
    //    茶冲泡法：  1.把水煮沸、2.用沸水冲泡茶叶、3.倒进杯子、4.加蜂蜜

    public abstract class 饮料
    {
        public void 制作()
        {
            把水煮沸();
            用沸水冲泡();
            把东西倒进杯子();
            加东西();
        }

        public abstract void 用沸水冲泡();

        public abstract void 加东西();

        public void 把水煮沸()
        {
            Console.WriteLine("把水煮沸");
        }

        public virtual void 把东西倒进杯子()
        {
            Console.WriteLine("倒进杯子");
        }
    }

    public class 咖啡 : 饮料
    {
        public override void 用沸水冲泡()
        {
            Console.WriteLine("添加糖喝牛奶");
        }

        public override void 加东西()
        {
            Console.WriteLine("用沸水重开咖啡");
        }
    }

    public class 茶 : 饮料
    {
        public override void 用沸水冲泡()
        {
            Console.WriteLine("添加蜂蜜");
        }

        public override void 加东西()
        {
            Console.WriteLine("用沸水泡茶叶");
        }
    }

}
