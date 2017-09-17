//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/02 18:07:23
//--------------------------------------------

namespace DesignMethod.单例模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Singleton let = Singleton.GetInstance();
            let.Co();
        }
    }
}