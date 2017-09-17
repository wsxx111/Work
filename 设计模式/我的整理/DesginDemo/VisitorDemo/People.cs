using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public abstract class People
    {
     public abstract void getVisitor(IVisitor v);
    }
}
