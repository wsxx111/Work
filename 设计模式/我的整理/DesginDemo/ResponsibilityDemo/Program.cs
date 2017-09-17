using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResponsibilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestMan r = new RequestMan("张三", 18600);

            CheckMan c1 = new CheckTeacher("李老师");
            CheckMan c2 = new CheckMaster("张主任");
            CheckMan c3 = new CheckLord("牛老板");
            c1.nextCHeckMan = c2;           
            c2.nextCHeckMan = c3;
            c1.requestProcess(r);

            Console.ReadKey();
            
        }
    }
}
