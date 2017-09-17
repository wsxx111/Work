using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.备忘录模式
{

    #region  解析
    /* 原类：发起人
       备份：备忘录
       存储备份：管理者
     * 
     * 发起人：负责创建一个备忘录，用以记录当前时刻自身的内部状态，并可使用备忘录恢复内部状态。发起人可以根据需要决定备忘录存储自己的哪些内部状态。
     * 
     * 备忘录：负责存储发起人对象的内部状态，并可以防止发起人以外的其他对象访问备忘录。备忘录有两个接口：管理者只能看到备忘录的窄接口，他只能将备忘录传递给其他对象。发起人却可看到备忘录的宽接口，允许它访问返回到先前状态所需要的所有数据
     * 
     * 管理者:负责备忘录，不能对备忘录的内容进行访问或者操作。
     * 
     * 
     * 发起人   管理者   备忘录     等价于 图书馆----图书管理员----借阅记录本      提供了撤销的功能
     * 
     * 
     * 备忘录模式的优点有：
         当发起人角色中的状态改变时，有可能这是个错误的改变，我们使用备忘录模式就可以把这个错误的改变还原。
         备份的状态是保存在发起人角色之外的，这样，发起人角色就不需要对各个备份的状态进行管理。
     * 
      备忘录模式的缺点：
         在实际应用中，备忘录模式都是多状态和多备份的，发起人角色的状态需要存储到备忘录对象中，对资源的消耗是比较严重的。
         如果有需要提供回滚操作的需求，使用备忘录模式非常适合，比如jdbc的事务操作，文本编辑器的Ctrl+Z恢复等。
     * */

    #endregion


    public class 测试类
    {
        public static void 运行()
        {
            var 图书集 = new List<图书>(){
        new 图书(){Name="《你在哪里》",Writer="张三"},
        new 图书(){Name="《我在北京》",Writer="李四"},
        new 图书(){Name="《这里很好》",Writer="王五"}
        };

            图书馆 test = new 图书馆(图书集);
            test.显示各种图书();

            图书管理员.拿出原记录 = test.创建原图书馆记录(test.各种图书);

            //图书馆的书开始变动
            test.各种图书.RemoveAt(2);
            test.显示各种图书();

            //图书馆的书究竟原来有多少
            test.恢复图书馆(图书管理员.拿出原记录);
            test.显示各种图书();
        }

    }


    //-------------------------------------------------------------------------------------------------


    public class 图书馆
    {
        //一个属性
        public List<图书> 各种图书 { get; set; }

        //构造函数
        public 图书馆(List<图书> 传入各种图书)
        {
            各种图书 = 传入各种图书;
        }

        //显示实体集 方法
        public void 显示各种图书()
        {
            Console.WriteLine(string.Format("共有{0}个图书", this.各种图书.Count));
            foreach (图书 book in 各种图书)
            {
                Console.WriteLine("名字：{0} 作者{1}", book.Name, book.Writer);
            }
        }

        //创建备份 方法
        public 原记录 创建原图书馆记录(List<图书> 传入各种图书)
        {
            return new 原记录(传入各种图书);
        }


        //恢复备份 方法
        public void 恢复图书馆(原记录 传入的记录)
        {
            this.各种图书 = 传入的记录.各种图书;
        }

    }





    public class 图书管理员
    {
        public static 原记录 拿出原记录 { get; set; }
    }



    public class 原记录
    {
        //一个属性
        public List<图书> 各种图书 { get; set; }

        //构造函数
        public 原记录(List<图书> 传入各种图书)
        {
            各种图书 = 传入各种图书;
        }
    }



    public class 图书
    {
        public string Name { get; set; }
        public string Writer { get; set; }
    }
}
