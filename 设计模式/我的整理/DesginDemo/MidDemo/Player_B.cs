using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidDemo
{
    public class Player_B:Player
    {
         public Player_B(decimal m, string name, bool ishost)
            : base(m, name, ishost)
        {     
    
        }

         public override void WinMoney(decimal m, Middle mid)
        {
            Wincount++;
            mid.winB(m);
        }
    }
}
