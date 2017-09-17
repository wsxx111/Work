using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.单例模式
{
   /*  使用Singleton模式有一个必要条件：在一个系统要求一个类只有一个实例时才应当使用单例模式。
    * 反之，如果一个类可以有几个实例共存，就不要使用单例模式。
    * 不要使用单例模式存取全局变量。这违背了单例模式的用意，最好放到对应类的静态成员中。
    * 不要将数据库连接做成单例，因为一个系统可能会与数据库有多个连接，并且在有连接池的情况下，应当尽可能及时释放连接。
    * Singleton模式由于使用静态成员存储类实例，所以可能会造成资源无法及时释放，带来问题.
    * */
    public class 单例模式扩展
    {
        public class NewClass
        {
            //static NewClass()
            //{
            //    Console.WriteLine("构造");
            //}

            private NewClass()
            {
                Console.WriteLine("私有构造");
            }

            public static string x = NewChild.inst;// Show("前面");

            public static string Show(string s)
            {
                Console.WriteLine(s);
                return s;
            }

            public class NewChild
            {
                private NewChild()
                {

                }
                static NewChild()
                {
                    Console.WriteLine("子构造");
                }

                public static readonly string inst = ShowChild("子");
                public static string ShowChild(string s)
                {
                    Console.WriteLine(s);
                    return s;
                }
            }

        }

    }
}

// 嵌套类  静态构造出现影响静态字段的执行顺序

/*嵌套类：https://msdn.microsoft.com/zh-cn/library/ms173120
不管外部类型是类还是结构，嵌套类型均默认为 private，但是可以设置为 public、protected internal、protected、internal 或 private。在上面的示例中，NewChild 对外部类型是不可访问的，但可以设置为 public，
 * 
 * 嵌套类型（或内部类型）可访问包含类型（或外部类型）。若要访问包含类型，请将其作为构造函数传递给嵌套类型。
 public class Container
{
    public class Nested
    {
        private Container parent;

        public Nested()
        {
        }
        public Nested(Container parent)
        {
            this.parent = parent;
        }
    }
}
 * 
 * 嵌套类型可以访问其包含类型可以访问的所有成员。它可以访问包含类型的私有成员和受保护成员（包括所有继承的受保护成员）。
 * Container.Nested nest = new Container.Nested();
 * 
 * 嵌套类可以很好的适用于「需要一个辅助类来代替包含类工作的情形」。例如，容器类可能维护了一组对象，假设你需要一些工具来迭代这些被包含的对象，并允许执行迭代的外部用户维护一个代表迭代过程中当前位置的标记或迭代器——这可以改变容器类的内部行为而不会破坏使用容器类的代码，带来的巨大的灵活性。这个时候嵌套类就可以提供一个很好的解决方案。 
 * */
