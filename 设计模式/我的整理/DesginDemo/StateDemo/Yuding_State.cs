using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDemo
{
    public class Yuding_State:State
    {
        public Yuding_State(Room room)
            : base(room)
        {
            this.TxtState = "预定状态";
            this.room = room;
        }

        //入住
        public override void Zhu()
        {
            this.room.State = new RuZhu_State(this.room);
            Console.WriteLine(string.Format("入住成功", room.getState()));
        }

        //退订
        public override void Tui_Ding()
        {
            this.room.State = new Kongxian_State(this.room);
            Console.WriteLine(string.Format("退订成功", room.getState()));
        }

    }
}
