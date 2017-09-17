using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDemo
{
    public abstract class State
    {
        public string TxtState;
        public Room room;

        public State(Room  room)
        {
            this.room = room;
        }

        //入住
        public virtual void Zhu()
        {
            Console.WriteLine(string.Format("当前房间状态为：{0}，不能入住",room.getState()));
        }

        //预定
        public virtual void Ding()
        {
            Console.WriteLine(string.Format("当前房间状态为：{0}，不能预定", room.getState()));
        }

        //退订
        public virtual void Tui_Ding()
        {
            Console.WriteLine(string.Format("当前房间状态为：{0}，不能退订", room.getState()));
        }

        //退房
        public virtual void Tui_fang()
        {
            Console.WriteLine(string.Format("当前房间状态为：{0}，不能退房", room.getState()));
        }
    }
}
