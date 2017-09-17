using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResponsibilityDemo
{
    public class RequestMan
    {
        public RequestMan(string name, int amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
        //请求人姓名
        public string Name { get; set; }

        //请求金费
        public int Amount { get; set; }
    }
}
