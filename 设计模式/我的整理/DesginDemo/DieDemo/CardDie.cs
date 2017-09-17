using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DieDemo
{
    public class CardDie:Die
    {
        private IEnumera e;
        public CardDie(IEnumera e)
        {
            this.e = e;
        }

        public object getCurrent()
        {
            return e.current();
        }

        public void moveNext()
        {
            e.Index++;
        }

        public void toFirst()
        {
            e.Index = 0;
        }

        public bool isEnd()
        {
            return e.Index > (e.Count - 1);
        }
    }
}
