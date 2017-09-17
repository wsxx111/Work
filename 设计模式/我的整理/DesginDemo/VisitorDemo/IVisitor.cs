using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public interface IVisitor
    {
        void Action(Student p);
        void Action(Teacher p);
    }
}
