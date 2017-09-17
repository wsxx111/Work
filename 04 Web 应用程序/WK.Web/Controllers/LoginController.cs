using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WK.Application.SystemManage;
using WK.Code;
using WK.Code.Operator;
using WK.Domain.Entity.SystemSecurity;
using WK.Domain.Entity.SystemManage;
using WK.Domain.Infrastructure;
using WK.Application.SystemSecurity;

namespace WK.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult UserLogin()
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_Type = DbLogType.Login.ToString();
            var getUserName = HttpContext.Request["username"];
            var getUserPwd = HttpContext.Request["pwd"];
            var getCode = HttpContext.Request["code"];
            try
            {
                if (string.IsNullOrEmpty(WebHelper.GetSession("nfine_sessionVerifycode")) || Md5.md5(getCode.ToLower(), 16) != WebHelper.GetSession("nfine_sessionVerifycode"))
                {
                    throw new Exception("验证码错误，请重新输入");
                }
                //验证                
                UserEntity userEntity = new UserApp().CheckLogin(getUserName, getUserPwd);              

                OperatorModel operatorModel = new OperatorModel();
                operatorModel.UserId = Guid.NewGuid().ToString();
                operatorModel.UserName = getUserName;
                operatorModel.LoginIPAddress = WebHelper.Ip;
                operatorModel.LoginIPAddressName = WebHelper.GetLocation(operatorModel.LoginIPAddress);
                operatorModel.LoginTime = DateTime.Now;
                operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                //if (userEntity.F_Account == "admin")
                //{
                //    operatorModel.IsSystem = true;
                //}
                //else
                //{
                operatorModel.IsSystem = false;
                //}

                OperatorProvider.Provider.AddCurrent(operatorModel);
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch(Exception ex)
            {
                logEntity.F_Account = getUserName;
                logEntity.F_NickName = getUserName;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                try
                {
                    new LogApp().WriteDbLog(logEntity);
                }
                catch (Exception)
                {
                    
                    throw;
                }
              
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());                      
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult UserExit()
        {
            OperatorProvider.Provider.RemoveCurrent();
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "退出成功。" }.ToJson());
        }

        //验证码
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

    }

}
