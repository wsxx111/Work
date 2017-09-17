//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :Program
// created by 陈星宇
// at 2015/07/03 14:17:02
//--------------------------------------------
using System;

namespace DesignMethod.适配器
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region OpenClass

            IThreeHole threehole = new PowerAdpter();
            threehole.Requset();
            Console.ReadLine();

            #endregion OpenClass

            #region OpenObject

            ThreeHole2 three = new PowerAdapter();
            three.Request();
            Console.ReadLine();

            #endregion OpenObject
        }
    }
}