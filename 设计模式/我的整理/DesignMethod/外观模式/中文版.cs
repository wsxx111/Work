using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.外观模式
{
    #region  解析
    /*    
     *  外观模式（Facade），为子系统中的一组接口提供一个一致的界面，定义一个高层接口，这个接口使得这一子系统更加容易使用。
     *  引入外观角色之后，用户只需要直接与外观角色交互，用户与子系统之间的复杂关系由外观角色来实现，从而降低了系统的耦合度
     *  外观模式，我们通过外观的包装，使应用程序只能看到外观对象，而不会看到具体的细节对象，这样无疑会降低应用程序的复杂度，并且提高了程序的可维护性。
     *  
     * 在以下情况下可以考虑使用外观模式：
     * (1)设计初期阶段，应该有意识的将不同层分离，层与层之间建立外观模式。
     * (2) 开发阶段，子系统越来越复杂，增加外观模式提供一个简单的调用接口。
     * (3) 维护一个大型遗留系统的时候，可能这个系统已经非常难以维护和扩展，但又包含非常重要的功能，为其开发一个外观类，以便新系统与其交互。
     * 
     * 优点：
     * (1)实现了子系统与客户端之间的松耦合关系。
     * (2)客户端屏蔽了子系统组件，减少了客户端所需处理的对象数目，并使得子系统使用起来更加容易。
     * (3)降低了大型软件系统中的编译依赖性，并简化了系统在不同平台之间的移植过程，因为编译一个子系统一般不需要编译所有其他的子系统。
     *    一个子系统的修改对其他子系统没有任何影响，而且子系统内部变化也不会影响到外观对象。
     * (4)只是提供了一个访问子系统的统一入口，并不影响用户直接使用子系统类。
     * 
     * 缺点:
     * 1.不能很好地限制客户使用子系统类，如果对客户访问子系统类做太多的限制则减少了可变性和灵活性。
     * 2.在不引入抽象外观类的情况下，增加新的子系统可能需要修改外观类或客户端的源代码，违背了“开闭原则”。
     * 
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            总开关 swit = new 总开关();
            swit.开关();
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------

    //一个电源总开关可以控制四盏灯、一个风扇、一台空调和一台电视机的启动和关闭。该电源总开关可以同时控制上述所有电器设备，电源总开关即为该系统的外观模式设计。

    public class 总开关
    {
        private 灯 deng;
        private 空调 conditioner;
        private 电扇 dianshan;
        private 电视 tv;

        public 总开关()
        {
            this.deng = new 灯();
            this.conditioner = new 空调();
            this.dianshan = new 电扇();
            this.tv = new 电视();
        }
        private bool isOpen = false;
        public void 开关()
        {
            if (isOpen)
            {
                deng.打开();
                conditioner.打开();
                dianshan.打开();
                tv.打开();
            }
            else
            {
                deng.关闭();
                conditioner.关闭();
                dianshan.关闭();
                tv.关闭();
            }
        }

    }


    public class 灯
    {
        private bool isOpen = false;
        public 灯()
        {
            isOpen = false;
        }
        public void 打开()
        {
            isOpen = true;
        }
        public void 关闭()
        {
            isOpen = false;
        }
    }
    public class 空调
    {
        private bool isOpen = false;
        public 空调()
        {
            isOpen = false;
        }
        public void 打开()
        {
            isOpen = true;
        }
        public void 关闭()
        {
            isOpen = false;
        }
    }

    public class 电扇
    {
        private bool isOpen = false;
        public 电扇()
        {
            isOpen = false;
        }
        public void 打开()
        {
            isOpen = true;
        }
        public void 关闭()
        {
            isOpen = false;
        }
    }

    public class 电视
    {
        private bool isOpen;
        public void 打开()
        {
            isOpen = true;
        }
        public void 关闭()
        {
            isOpen = false;
        }
    }
}
