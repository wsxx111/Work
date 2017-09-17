using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            School s = new School();
            IntervieweeActivity iv=new IntervieweeActivity();
            CheckBody cb = new CheckBody();
            foreach (var item in s.getList())
            {
                item.getVisitor(iv);
                item.getVisitor(cb);
            }

            Console.ReadKey();
        }
    }
}
