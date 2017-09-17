using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.解释器模式
{
    #region  解析
    /*    
     * 解释器模式 
     * 
     * 
     * 1.当有一个语言需要解释执行，并且你可将该语言中的句子表示为一个抽象语法树，可以使用解释器模式。而当存在以下情况时该模式效果最好
     * 2.该文法的类层次结构变得庞大而无法管理。此时语法分析程序生成器这样的工具是最好的选择。
     *   他们无需构建抽象语法树即可解释表达式，这样可以节省空间而且还可能节省时间。
     * 3.效率不是一个关键问题，最高效的解释器通常不是通过直接解释语法分析树实现的，而是首先将他们装换成另一种形式，
     *   例如，正则表达式通常被装换成状态机，即使在这种情况下，转换器仍可用解释器模式实现，该模式仍是有用的
     * 4.一些重复发生的问题，比如加减乘除四则运算，但是公式每次都不同，
     *   有时是a+b-c*d，有时是a*b+c-d，等等等等个，公式千变万化，但是都是由加减乘除四个非终结符来连接的，这时我们就可以使用解释器模式。
     *   
     * 解释器模式真的是一个比较少用的模式，因为对它的维护实在是太麻烦了，
     * 想象一下，一坨一坨的非终结符解释器，假如不是事先对文法的规则了如指掌，或者是文法特别简单，则很难读懂它的逻辑。
     * 解释器模式在实际的系统开发中使用的很少，因为他会引起效率、性能以及维护等问题
     * 尽量不要在重要模块中使用解释器模式，因为维护困难。在项目中，可以使用脚本语言来代替解释器模
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            原值 yuan = new 原值();
            yuan.Num = 25;
            加法 add = new 加法();
            List<运算> cal = new List<运算>();
            cal.Add(new 加法());
            cal.Add(new 加法());
            cal.Add(new 加法());
            cal.Add(new 减法());
            cal.Add(new 加法());
            cal.Add(new 减法());
            for (int i = 0; i < cal.Count; i++)
            {
                cal[i].操作(yuan);
            }
            Console.WriteLine(yuan.Num);
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------



    public class 原值
    {
        public int Num { get; set; }
    }

    public abstract class 运算
    {
        public abstract void 操作(原值 yuan);
    }

    public class 加法 : 运算
    {
        public override void 操作(原值 yuan)
        {
            yuan.Num++;
        }
    }

    public class 减法 : 运算
    {
        public override void 操作(原值 yuan)
        {
            yuan.Num--;
        }
    }
}
