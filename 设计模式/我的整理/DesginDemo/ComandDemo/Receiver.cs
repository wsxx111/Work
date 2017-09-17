using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComandDemo
{
    public class Receiver
    {
        private int _channel { get; set; }
        public void SwitchOff()
        {
            Console.WriteLine("-关闭");
        }
        public void SwitchOn()
        {
            Console.WriteLine("-打开");
        }

        public void SwitchChannel(int channel)
        {
            _channel = channel;
            Console.WriteLine("-已切换为频道" + this._channel);
        }

    }
}
