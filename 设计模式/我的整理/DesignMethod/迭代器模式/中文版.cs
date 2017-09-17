using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.迭代器模式
{
     #region  解析
    /* 
     * 提供一种方法顺序访问一个聚合对象中的各种元素，而又不暴露该对象的内部表示,又可让外部代码透明的访问集合内部数据。
     *  当你需要访问一个聚合对象，而且不管这些对象是什么都需要遍历的时候，就应该考虑使用迭代器模式。
     *  另外，当需要对聚集有多种方式遍历时，可以考虑去使用迭代器模式。
     *  迭代器模式为遍历不同的聚集结构提供如开始、下一个、是否结束、当前哪一项等统一的接口。
     * 其实.net框架已经准备好了迭代器接口，只需要实现接口就行了IEumerator 支持对非泛型集合的简单迭代。
     *
     *  1.迭代器角色（Iterator）：迭代器角色负责定义访问和遍历元素的接口。
     *  2.具体迭代器角色（Concrete Iterator）：具体迭代器角色要实现迭代器接口，并要记录遍历中的当前位置。
     *  3.容器角色（Container）：容器角色负责提供创建具体迭代器角色的接口。
     *  4.具体容器角色（Concrete Container）：具体容器角色实现创建具体迭代器角色的接口——这个具体迭代器角色于该容器的结构相关。
     *  
     * 迭代器就是用于访问或者存取集合中的每一个组成元素。
     * 迭代器提供了遍历数组的方法，也就是说把之前遍历数据集合的这一部分抽出来，单独成类，而数据集合则通过参数由迭代器的构造函数传入。
     * 使用迭代器的好处就是在于保持良好的封装的同时对集合元素进行循环操作。
     * 不需要把数据集合展现给外部对象。
     * 不使用迭代器，外部对象会通过getter的方法获取数据集合然后遍历，
     * 这样把整个数据集合公开了，并且外部对象可以直接改写，
     * 另外遍历数据集合时也要知道数据结构，先分析数据结构才能进行迭代代码的书写，这样如果下次需要修改数据结构时，代码修改也会变的困难。
     * */

     #endregion


    public class 测试类
    {
        public static void 运行()
        {             
            客车乘客 passagener = new 小牛客车乘客();
            查票 进行查票 = passagener.本客车进行查票();

            while (进行查票.是否查完了())
            {
                string peopleName = (string)进行查票.当前被查票者();
                Console.WriteLine(peopleName);
                进行查票.下一个();
            }
            Console.Read();
        }
    }


    //----------------------------------------------------------------------------------------


    public interface 查票
    {      
        Object 当前被查票者();
     
        bool 是否查完了();
       
        void 下一个();
        
        void 从头开始();
    }

    public class 客车查票 : 查票
    {

        private int 已查位置;
       //
        private 小牛客车乘客 小牛客车乘客们;

        public 客车查票(小牛客车乘客 传入的乘客们)
        {
            小牛客车乘客们 = 传入的乘客们;
            已查位置 = 0;
        }

        public object 当前被查票者()
        {
            return 小牛客车乘客们.所在的位置(已查位置);
        }

        public bool 是否查完了()
        {
            if (已查位置 < 小牛客车乘客们.乘客个数)
            {
                return true;
            }
            return false;
        }

        public void 下一个()
        {
            if (已查位置 < 小牛客车乘客们.乘客个数)
            {
                已查位置++;
            }
        }

        public void 从头开始()
        {
            已查位置 = 0;
        }              
    }


    public interface 客车乘客
    {
        查票 本客车进行查票();
    }

    public class 小牛客车乘客 : 客车乘客
    {
        private string[] 本客车乘客们;

        public 小牛客车乘客()
        {
            本客车乘客们 = new string[] { "张三","李四","王五", "马六" };
        }

        public int 乘客个数
        {
            get { return 本客车乘客们.Length; }
        }

        public string 所在的位置(int 所在位置)
        {
            return 本客车乘客们[所在位置];
        }

        public 查票 本客车进行查票()
        {
            return new 客车查票(this);
        }
    }



}
