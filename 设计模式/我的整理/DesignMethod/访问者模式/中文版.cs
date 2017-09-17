using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.访问者模式
{
    #region  解析
    /*
     *访问者模式就是表示一个作用于某对象结构中的各元素的操作。
     *它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作。 
     *
     * 优点：
     * 1，访问者模式使得增加新的操作变得很容易。
     * 如果一些操作依赖于一个复杂的结构对象的话，那么一般而言，增加新的操作会很复杂。
     * 而使用访问者模式，增加新的操作就意味着增加一个新的访问者类，因此，变得很容易。
     * 2，访问者模式将有关的行为集中到一个访问者对象中，而不是分散到一个个的节点类中。
     * 3，访问者模式可以跨过几个类的等级结构访问属于不同的等级结构的成员类。
     * 迭代子只能访问属于同一个类型等级结构的成员对象，而不能访问属于不同等级结构的对象。访问者模式可以做到这一点。
     * 4，积累状态。
     * 每一个单独的访问者对象都集中了相关的行为，从而也就可以在访问的过程中将执行操作的状态积累在自己内部，而不是分散到很多的节点对象中。这是有益于系统维护的优点。
     * 
     * 缺点：
     * 1，增加新的节点类变得很困难。每增加一个新的节点都意味着要在抽象访问者角色中增加一个新的抽象操作，并在每一个具体访问者类中增加相应的具体操作。
     * 2，破坏封装。访问者模式要求访问者对象访问并调用每一个节点对象的操作，这隐含了一个对所有节点对象的要求：它们必须暴露一些自己的操作和内部状态。
     * 不然，访问者的访问就变得没有意义。由于访问者对象自己会积累访问操作所需的状态，从而使这些状态不再存储在节点对象中，这也是破坏封装的。
     * 
     * 
     * 是调用者作为访问者，传入接待者，实现执行的是接待者的方法，而接待者方法本身是以传入本调用者为代价的，即调用该访问者的本身的方法。
     * 归根到底是调用自己的方法，却巧妙的适应了各种情况的意义对应。
     * */

    #endregion


    public class 测试类
    {
        public static void 运行()
        {
            售票大厅 room = new 售票大厅();
            foreach (客户 p in room.办手续的各种客户())
            {
                p.办手续(new 柜台操作员());
                p.需求();
            }           
            Console.Read();
        }
    }


    //----------------------------------------------------------------------------------------


    //对象结构
    public class 售票大厅
    {
        private List<客户> 各种客户 = new List<客户>();

        public 售票大厅()
        {
            各种客户.Add(new 想退票的客户());
            各种客户.Add(new 想订票的客户());
            各种客户.Add(new 想改签的客户());
            各种客户.Add(new 想退票的客户());
            各种客户.Add(new 想改签的客户());
            各种客户.Add(new 想订票的客户());
            各种客户.Add(new 想订票的客户());
        }

        //对外的各种客户
        public List<客户> 办手续的各种客户()
        {
            return this.各种客户;
        }

    }



    public interface 售票处操作
    {
        void 如果是(想退票的客户 tui);
        void 如果是(想订票的客户 ding);
        void 如果是(想改签的客户 gai);
    }


    public class 柜台操作员 : 售票处操作
    {
        public void 如果是(想退票的客户 tui)
        {
            Console.WriteLine(tui.需求());
        }

        public void 如果是(想订票的客户 ding)
        {
            Console.WriteLine(ding.需求());
        }

        public void 如果是(想改签的客户 gai)
        {
            Console.WriteLine(gai.需求());
        }
    }




    public abstract class 客户
    {
        public abstract void 办手续(售票处操作 which);        
        public abstract string 需求();
    }

    public class 想退票的客户 : 客户
    {
        public override void 办手续(售票处操作 which)
        {
            which.如果是(this);
        }

        public override string 需求()
        {
            return "来退票";
        }      
    }

    public class 想订票的客户 : 客户
    {
        public override void 办手续(售票处操作 which)
        {
            which.如果是(this);
        }

        public override string 需求()
        {
            return "来订票";
        }
      
    }
    public class 想改签的客户 : 客户
    {
        public override void 办手续(售票处操作 which)
        {
            which.如果是(this);
        }

        public override string 需求()
        {
            return "来改签";
        }
       
    }



}
