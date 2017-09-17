using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResponsibilityDemo
{
    public class CheckTeacher : CheckMan
    {
        public CheckTeacher(string name)
        {
            this.Name = name;
        }

        public override void requestProcess(RequestMan requestor)
        {
            if (requestor.Amount < 500)
            {
                Console.WriteLine(string.Format("请求者：{0}，请求金费{1}.审批人：{2}通过", requestor.Name, requestor.Amount, this.Name));
            }
            else {
                Console.WriteLine(string.Format("请求者：{0}，请求金费{1}.审批人：{2}请求上级处理", requestor.Name, requestor.Amount, this.Name));            
                this.nextCHeckMan.requestProcess(requestor);
            }
        }
    }
}
