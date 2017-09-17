using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public class IntervieweeActivity:IVisitor
    {
        public void Action(Student p)
        {
            Console.WriteLine(string.Format("问卷调查信息。姓名：{0}，性别：{1}，年纪：{2}",p.Name,p.Age,p.Grade));
        }

        public void Action(Teacher p)
        {
            Console.WriteLine(string.Format("问卷调查信息。姓名：{0}，性别：{1}，教学类型：{2}", p.Name, p.Age, p.Type));
        }
    }
}
