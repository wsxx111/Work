using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDemo
{
    public class RuZhu_State:State
    {
        public RuZhu_State(Room room)
            : base(room)
        {
            this.TxtState = "入住状态";
            this.room = room;
        }

        //退房
        public override void Tui_fang()
        {
            this.room.State = new Kongxian_State(this.room);
            Console.WriteLine(string.Format("退房成功", room.getState()));          
        }
    }
}
