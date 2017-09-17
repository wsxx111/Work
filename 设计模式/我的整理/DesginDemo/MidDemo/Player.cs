using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidDemo
{
    public abstract class Player
    {
        private string _name;
        private decimal _money;
        public int Wincount;

        public bool isHost;

        public string Name { get { return _name; } }

        public decimal Money { get { return _money; } set { _money = value; } }      

        public Player(decimal money, string name,bool host)
        {
            Wincount = 0;
            _name = name;
            _money = money;
            isHost = host;
        }

        public abstract void WinMoney(decimal m, Middle mid);
    }
}
