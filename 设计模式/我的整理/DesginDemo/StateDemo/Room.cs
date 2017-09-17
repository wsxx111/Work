using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDemo
{
    public class Room
    {
        public State State { set; get; }
        public Room()
        {
            State = new Kongxian_State(this);
        }

        public string getState()
        {
            return State.TxtState;
        }
        //入住
        public void Zhu()
        {
            State.Zhu();
        }

        //预定
        public void Ding()
        {
            State.Ding();
        }

        //退订
        public void Tui_Ding()
        {
            State.Tui_Ding();
        }

        //退房
        public void Tui_fang()
        {
            State.Tui_fang();
        }

    }
}
