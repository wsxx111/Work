using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResponsibilityDemo
{
    public class CheckLord:CheckMan
    {
        public CheckLord(string name)
        {
            this.Name = name;
        }       

        public override void requestProcess(RequestMan requestor)
        {
            if (requestor.Amount < 2000)
            {
                Console.WriteLine(string.Format("请求者：{0}，请求金费{1}.审批人：{2}通过", requestor.Name, requestor.Amount, this.Name));
            }
            else {
                Console.WriteLine("上级不批准处理");               
            }
        }
    }
}
