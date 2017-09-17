using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandDemo
{
    public class TelOpenCommand : ICommand
    {
        private Receiver te;

        public TelOpenCommand(Receiver re)
        {
            te = re;
        }
        public void ExecuteAction()
        {
            te.SwitchOn();
        }
    }
}
