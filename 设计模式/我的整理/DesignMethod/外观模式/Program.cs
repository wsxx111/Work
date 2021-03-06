﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.外观模式
{
    public class Program : OpenDesign
    {
        private static RegistrationFacade facade = new RegistrationFacade();

        public override void Open()
        {
            if (facade.RegistrationCourse("设计模式", "Lear"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }
            Console.Read();
        }
    }

    //外观类
    public class RegistrationFacade
    {
        private NotifyStudent notifyStu;
        private RegisterCourse registerCourse;

        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }

        public bool RegistrationCourse(string name, string stuName)
        {
            if (!registerCourse.CheckAvailable(name))
            {
                return false;
            }
            return notifyStu.Notify(stuName);
        }
    }

    //子系统B
    public class NotifyStudent
    {
        public bool Notify(string name)
        {
            Console.WriteLine("正在向{0}发生通知", name);
            return true;
        }
    }

    //子系统A
    public class RegisterCourse
    {
        public bool CheckAvailable(string name)
        {
            Console.WriteLine("正在验证课程{0}是否人数已满", name);
            return true;
        }
    }

}
