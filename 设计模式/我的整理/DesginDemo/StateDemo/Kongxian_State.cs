using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDemo
{
    public class Kongxian_State:State
    {
        public Kongxian_State(Room room):base(room)
        {
            this.TxtState = "空闲状态";
            this.room = room;
        }

        //入住
        public override void Zhu()
        {
            this.room.State = new RuZhu_State(this.room);
            Console.WriteLine("入住成功");
        }

        //预定
        public override void Ding()
        {
            this.room.State = new Yuding_State(this.room);
            Console.WriteLine("预定成功");
        }
    }
}
