using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.ccc
{
    #region  解析
    /*    
     * 在责任链模式里，很多对象由每一个对象对其下家的引用而连接起来形成一条链。
     * 请求在这个链上传递，直到链上的某一个对象决定处理此请求。
     * 发出这个请求的客户端并不知道链上的哪一个对象最终处理这个请求，这使得系统可以在不影响客户端的情况下动态地重新组织和分配责任。
     * 责任链模式（Chain of Responsibility Pattern）为请求创建了一个接收者对象的链。 
     * 这种模式给予请求的类型，对请求的发送者和接收者进行解耦。
     * 在这种模式中，通常每个接收者都包含对另一个接收者的引用。如果一个对象不能处理该请求，那么它会把相同的请求传给下一个接收者，依此类推。
     * 
     * 优点： 
     *   1、降低耦合度。它将请求的发送者和接收者解耦。 
     *   2、简化了对象。使得对象不需要知道链的结构。 
     *   3、增强给对象指派职责的灵活性。通过改变链内的成员或者调动它们的次序，允许动态地新增或者删除责任。 
     *   4、增加新的请求处理类很方便。
     * 
     * 缺点：
     *   1、不能保证请求一定被接收。
     *   2、系统性能将受到一定影响，而且在进行代码调试时不太方便，可能会造成循环调用。 
     *   3、可能不容易观察运行时的特征，有碍于除错。 
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            辞职人 p = new 辞职人("世界那么大，我想去看看", "王凯");
            审批人 z0 = new 组长("马云");
            审批人 z1 = new 技术总监("王思聪");
            审批人 z2 = new 人事部门("王健林");
            z0.下一个审批人 = z1;
            z1.下一个审批人 = z2;
            z0.签字(p, true);
            Console.ReadKey();
        }
    }


    //----------------------------------------------------------------------------------------

    public class 辞职人
    {
        public 辞职人(string ReasonIn, string NameIn)
        {
            辞职原因 = ReasonIn;
            辞职人姓名 = NameIn;
        }

        public string 辞职原因 { get; set; }

        public string 辞职人姓名 { get; set; }
    }


    public abstract class 审批人
    {
        public 审批人(string NameIn)
        {
            this.审批人姓名 = NameIn;
        }
        public string 审批人姓名 { get; set; }
        public bool 是否同意 { get; set; }
        public 审批人 下一个审批人 { get; set; }

        public abstract void 签字(辞职人 people, bool IsPass);
    }




    public class 组长 : 审批人
    {
        public 组长(string name)
            : base(name)
        {
            this.审批人姓名 = name;
        }

        public override void 签字(辞职人 people, bool IsPass)
        {
            Console.WriteLine("{0}申请辞职,辞职理由为：{1}.", people.辞职人姓名, people.辞职原因);
            this.是否同意 = IsPass;
            if (IsPass)
            {
                Console.WriteLine("组长:{0},签字同意", this.审批人姓名);
                if (下一个审批人 != null)
                {
                    下一个审批人.签字(people, this.是否同意);
                }
            }
            else
            {
                Console.WriteLine("组长:{0},不同意，意见驳回", this.审批人姓名);
            }
        }
    }
    public class 技术总监 : 审批人
    {
        public 技术总监(string name)
            : base(name) { this.审批人姓名 = name; }

        public override void 签字(辞职人 people, bool IsPass)
        {
            this.是否同意 = IsPass;
            if (IsPass)
            {
                Console.WriteLine("技术总监:{0},签字同意", this.审批人姓名);
                下一个审批人.签字(people, this.是否同意);
            }
            else
            {
                Console.WriteLine("技术总监:{0},不同意，意见驳回", this.审批人姓名);
            }
        }
    }
    public class 人事部门 : 审批人
    {
        public 人事部门(string name)
            : base(name) { this.审批人姓名 = name; }

        public override void 签字(辞职人 people, bool IsPass)
        {
            this.是否同意 = IsPass;
            if (IsPass)
            {
                Console.WriteLine("人事部门:{0},签字同意", this.审批人姓名);
                Console.WriteLine("辞职人:{0},手续办理成功",people.辞职人姓名);
            }
            else
            {
                Console.WriteLine("人事部门:{0},不同意，意见驳回", this.审批人姓名);
            }
        }
    }
}
