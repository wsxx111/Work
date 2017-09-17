using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandDemo
{
    public class TelCloseCommand : ICommand
    {
        private Receiver te;
        public TelCloseCommand(Receiver tel)
        {
            te = tel;
        }

        public void ExecuteAction()
        {
            te.SwitchOff();
        }
    }
}
