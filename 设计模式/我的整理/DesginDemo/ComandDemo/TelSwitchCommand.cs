using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandDemo
{
    class TelSwitchCommand:ICommand
    {
        private Receiver te;
        private int _tochannel;

        public TelSwitchCommand(Receiver re,int channel)
        {
            _tochannel = channel;
            te = re;
        }
        public void ExecuteAction()
        {
            te.SwitchChannel(_tochannel);
        }
    }
}
