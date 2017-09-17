using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public class CheckBody:IVisitor
    {
        public void Action(Student p)
        {
            Console.WriteLine(string.Format("体检信息。姓名：{0}，性别：{1}，年纪：{2}", p.Name, p.Age, p.Grade));
        }

        public void Action(Teacher p)
        {
            Console.WriteLine(string.Format("体检信息。姓名：{0}，性别：{1}，教学类型：{2}", p.Name, p.Age, p.Type));
        }
    }
}
