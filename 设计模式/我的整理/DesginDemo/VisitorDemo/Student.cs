using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public class Student : People
    {
        private string name;
        private int age;

        private string grade;

        public Student(string name, int age, string grade)
        {
            this.name = name;
            this.age = age;
            this.grade = grade;
        }

        public string Name { get { return name; } }

        public int Age { get { return age; } }

        public string Grade { get { return grade; } }

        public override void getVisitor(IVisitor v)
        {
            v.Action(this);
        }
    }
}
