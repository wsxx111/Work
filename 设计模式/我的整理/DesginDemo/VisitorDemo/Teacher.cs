using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public class Teacher : People
    {
        private string name;
        private int age;

        private string type;
        public Teacher(string name, int age, string type)
        {
            this.name = name;
            this.age = age;
            this.type = type;
        }

        public string Name { get { return name; } }

        public int Age { get { return age; } }

        public string Type { get { return type; } }


        public override void getVisitor(IVisitor v)
        {
            v.Action(this);
        }
    }
}
