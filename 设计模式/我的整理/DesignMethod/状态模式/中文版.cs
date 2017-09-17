using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.状态模式
{
    #region  解析
    /*    
     * 
     * 
     * 
     * 
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            账户 account = new 账户("wk");
            account.存款(1000.00);
            account.存款(600.00);
            account.存款(200.00);

            account.计算利息();

            //取钱
            account.取款(2000.00);
            account.取款(500.00);

            Console.ReadKey();
        }
    }


    //----------------------------------------------------------------------------------------

    public class 账户
    {
        public 账户(string NameIn)
        {
            this.账户人姓名 = NameIn;
        }

        public string 账户人姓名 { get; set; }
        public double 余额 { get { return state.余额; } }
        public 等级 state { get; set; }

        public void 存款(double amount)
        {
            state.存款(amount);
            Console.WriteLine("存款金额：{0:C}--", amount);
            Console.WriteLine("账户余额为 =:{0:C}", this.余额);
            Console.WriteLine("账户状态为: {0}", this.state.GetType().Name);
        }

        public void 计算利息()
        {
            state.计算本利息();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine("账户余额为 =:{0:C}", this.余额);
            Console.WriteLine("账户状态为: {0}", this.state.GetType().Name);
            Console.WriteLine();
        }

        //取款
        public void 取款(double amount)
        {
            state.取钱(amount);
            Console.WriteLine("取款金额为：{0:C}---", amount);
            Console.WriteLine("账户余额为 =:{0:C}", this.余额);
            Console.WriteLine("账户状态为: {0}", this.state.GetType().Name);
            Console.WriteLine();
        }
    }


    public abstract class 等级
    {
        public 账户 用户 { get; set; }

        public double 余额 { get; set; }

        public double 利率 { get; set; }
       
        public double 上限 { get; set; }

        public double 下限 { get; set; }


        public abstract void 存款(double amount);

        public abstract void 计算本利息();

        public abstract void 取钱(double amount);

    }

    public class 黄金用户 : 等级
    {
        public 黄金用户(等级 state)
        {
            this.余额 = state.余额;
            this.用户 = state.用户;
            this.利率 = 0.05;
            this.下限 = 1000.00;
            this.上限 = 10000.00;
        }

        public override void 存款(double amount)
        {
           this.余额+=amount;
           更新();
        }

        public override void 计算本利息()
        {
            余额+=利率*余额;
            更新();
        }

        public override void 取钱(double amount)
        {
            余额 -= amount;
            更新();
        }

        private void 更新()
        {
            if (余额 < 0.0)
            {
                用户.state = new 赤字用户(this);
            }
            else if (余额 < this.下限)
            {
                用户.state = new 白银用户(this);
            }
        }
    }

    public class 赤字用户 : 等级
    {
        public 赤字用户(等级 state)
        {
            this.余额 = state.余额;
            this.用户 = state.用户;
            this.利率 = 0.0;
            this.下限 = -100.00;
            this.上限 = 0.00;
        }

        public override void 存款(double amount)
        {
            this.余额 += amount;
            更新();
        }

        public override void 计算本利息()
        {           
        }

        public override void 取钱(double amount)
        {
            Console.WriteLine("没钱可取");
        }

        private void 更新()
        {
            if (余额 > this.上限)
            {
                用户.state = new 白银用户(this);
            }
        }

    }


    public class 白银用户 : 等级
    {
        public 白银用户(等级 state) : this(state.余额, state.用户)
        { 
        }


        public 白银用户(double yu,账户 account )
        {
            this.余额 = yu;
            this.用户 = account;
            this.利率 = 0.0;
            this.下限 = 0.00;
            this.上限 = 1000.00;
        }

         public override void 存款(double amount)
         {
             this.余额 += amount;
             更新();
         }

         public override void 计算本利息()
         {
             余额 += 利率 * 余额;
             更新();
         }

         public override void 取钱(double amount)
         {
             余额 -= amount;
             更新();
         }

         private void 更新()
         {
             if (余额 < this.下限)
             {
                 用户.state = new 赤字用户(this);
             }
             else if (余额 > this.上限)
             {
                 用户.state = new 黄金用户(this);
             }
         }

    }


}
