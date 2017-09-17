using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidDemo
{
    public class Middle
    {
        private Player_A a =null;
        private Player_B b =null;
        private Player_C c = null;

        public Middle(Player_A a,Player_B b,Player_C c)          
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void winA(decimal m)
        {
            if (a.isHost)
            {
                a.Money += 4m;
                b.Money -= 2m;
                c.Money -= 2m;
            }
            else
            {
                a.Money += 2m;
                b.Money -= m;
                c.Money -= m;
                a.isHost = true;
                b.isHost = false;
                c.isHost = false;
            }
        }


        public void winB(decimal m)
        {
            if (b.isHost)
            {
                a.Money -= 2m;
                b.Money += 4m;
                c.Money -= 2m;
            }
            else
            {
                a.Money -= m;
                b.Money += 2m;
                c.Money -= m;
                a.isHost = false;
                b.isHost = true;
                c.isHost = false;
            }
        }

        public void winC(decimal m)
        {
            if (c.isHost)
            {
                a.Money -= 2m;
                b.Money -= 2m;
                c.Money += 4m;
            }
            else
            {
                a.Money -= m;
                b.Money -= m;
                c.Money += 2m;
                a.isHost = false;
                b.isHost = false;
                c.isHost = true;
            }
        }

    }
}
