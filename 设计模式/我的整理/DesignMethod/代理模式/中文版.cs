﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.代理模式
{
    #region  解析
    /* ：为其他对象提供一种代理以控制对这个对象的访问。在某些情况下，一个对象不适合或者不能直接引用另一个对象，而代理对象可以在客户端和目标对象之间起到中介的作用。
     * 
     * 抽象角色：通过接口或抽象类声明真实角色实现的业务方法。
     * 
     * 代理角色：实现抽象角色，是真实角色的代理，通过真实角色的业务逻辑方法来实现抽象方法，并可以附加自己的操作。
     * 真实角色：实现抽象角色，定义真实角色所要实现的业务逻辑，供代理角色调用。
     * 
     * 一个是真正的你要访问的对象(目标类)，一个是代理对象,真正对象与代理对象实现同一个接口,先访问代理类再访问真正要访问的对象
     * 
     * 声明真实对象和代理对象的共同接口，代理对象角色内部含有对真实对象的引用，从而可以操作真实对象，
     * 同时代理对象提供与真实对象相同的接口以便在任何时刻都能代替真实对象
     * 对真实的对象进行保护
     * 
     * 接口  代理类 委托类      订票员作为代理 帮 购票者这个委托类 定好了 火车票
     * 
     * 个对象，比如一幅很大的图像，需要载入的时间很长。　　　　
     * 一个需要很长时间才可以完成的计算结果，并且需要在它计算过程中显示中间结果
     * 一个存在于远程计算机上的对象，需要通过网络载入这个远程对象则需要很长时间，特别是在网络传输高峰期。
     * 一个对象只有有限的访问权限，代理模式(Proxy)可以验证用户的权限
     * 代理模式其实就是在访问对象时引入一定程度的间接性，因为这种间接性，可以附加多种用途，代理就是真实对象的代表。
     * 
     * 优点：
     * (1).职责清晰，真实的角色就是实现实际的业务逻辑，不用关心其他非本职责的事务，通过后期的代理完成一件完成事务，附带的结果就是编程简洁清晰。
     * (2).代理对象可以在客户端和目标对象之间起到中介的作用，这样起到了中介的作用和保护了目标对象的作用。     
     * (3).高扩展性
     * 
     * 缓存代理 日志代理 权限代理 单例代理 延迟代理
     * 
     * */

    #endregion


    public class 测试类
    {
        public static void 运行()
        {
            人 ren = new 订票员();

            //问代理就知道她都帮谁订了什么火车票
            ren.订车票();
        }
    }


    //----------------------------------------------------------------------------------------

    
    public abstract class 人
    {
        public abstract void 订车票();
    }

    //委托类
    public class 购票者 : 人
    {
        public override void 订车票()
        {
            Console.WriteLine("购票者：我要订今天去北京的火车票");
        }
    }


    //代理类
    public class 订票员 : 人
    {
        private 购票者 订票人选;

        public override void 订车票()
        {
            Console.WriteLine("订票员：谁要订票");
            if (订票人选 == null)
            {
                订票人选 = new 购票者();
            }
            订票人选.订车票();
            Console.WriteLine("订票员：已帮你订票成功");
        }
    }

}
