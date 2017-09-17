using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResponsibilityDemo
{
    public abstract class CheckMan
    {
        public string Name { get; set; }

        public CheckMan nextCHeckMan { get; set; }

        public abstract void requestProcess(RequestMan requestor);

    }
}
