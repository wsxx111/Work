using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandDemo
{
    public class Invotor
    {
        private DateTime lastTime = DateTime.Now;
        private ICommand _command;

        public void SetCommand(ICommand command)
        {          
            _command = command;
        }

        public void Execute(ICommand command)
        {
            if (_command == null || (DateTime.Now - lastTime).TotalSeconds > 1)
            {
                _command = command;
                //记录日志
                _command.ExecuteAction();
            }
            else
            {
                Console.Write("操作过于频繁");
            }
        }

    }
}
