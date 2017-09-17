using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.责任链模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            PurchaseRequest requestTelphone = new PurchaseRequest(4000.0, "Telphone");
            PurchaseRequest requestSoftware = new PurchaseRequest(10000.0, "Visual Studio");
            PurchaseRequest requestComputers = new PurchaseRequest(40000.0, "Computers");

            Approver manager = new Manager("LearningHard");
            Approver Vp = new VicePresident("Tony");
            Approver Pre = new President("BoosTom");

            //设置责任链
            manager.NextApprover = Vp;
            Vp.NextApprover = Pre;

            //处理请求
            manager.ProcessRequest(requestTelphone);
            manager.ProcessRequest(requestSoftware);
            manager.ProcessRequest(requestComputers);
            Console.Read();
        }
    }

    //采购请求
    public class PurchaseRequest
    {
        public PurchaseRequest(double amount, string productName)
        {
            Amount = amount;
            ProductName = productName;
        }

        //金额
        public double Amount { get; set; }

        //产品名称
        public string ProductName { get; set; }
    }

      //审批人
    public abstract class Approver
    {
        public Approver(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public Approver NextApprover { get; set; }

        public abstract void ProcessRequest(PurchaseRequest request);
    }

    //管理者
    public class Manager : Approver
    {
        public Manager(string name)
            : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 10000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

   

    //副总经理
    public class VicePresident : Approver
    {
        public VicePresident(string name)
            : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 25000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    //总经理
    public class President : Approver
    {
        public President(string name)
            : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                Console.WriteLine("Request需要组织一个会议");
            }
        }
    }


}
