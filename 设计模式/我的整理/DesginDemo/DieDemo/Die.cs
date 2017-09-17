using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DieDemo
{
    public interface Die
    {
        object getCurrent();

        void moveNext();

        void toFirst();

        bool isEnd();
    }
}
