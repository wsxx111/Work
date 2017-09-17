using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieDemo
{
    public class people:IEnumera
    {
        private IList<Card> cards=new List<Card>();
        private int index;         

        public people()
        {
            cards.Add(new Card("中国银行", "20130204"));
            cards.Add(new Card("中国工商银行", "20120204"));
            cards.Add(new Card("华夏银行", "20140204"));
            cards.Add(new Card("北京银行", "20150204"));
            index = 0;                     
        }
        public Die getDie()
        {
            return new CardDie(this);
        }

        public object current()
        {
            return cards[index];
        }


        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public int Count
        {
            get
            {
                return cards.Count;
            }          
        }
      
    }
}
