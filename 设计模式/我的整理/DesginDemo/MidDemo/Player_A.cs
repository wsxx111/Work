using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidDemo
{
    public class Player_A:Player
    {       
        public Player_A(decimal m, string name, bool ishost)
            : base(m, name, ishost)
        {     
    
        }

        public override void WinMoney(decimal m, Middle mid)
        {
            Wincount++;
            mid.winA(m);
        }

    }
}
