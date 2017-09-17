using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WK.Web.Models;
using WK.Code;

namespace WK.Web.Controllers
{
    public class MainController : ControllerBase
    {
        public ActionResult Index()
        {                 
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        [HandlerAuthorize(true)]
        public ActionResult GetData()
        {
            string getToken = HttpContext.Session["token"] as string;
            if (getToken == null)
            {
                getToken = "hah123"; // Guid.NewGuid().ToString();
                HttpContext.Session["token"] = getToken;
            }
            else
            {
                var getRequestSession = HttpContext.Request.Headers["token"];
                if (getRequestSession == null || getRequestSession != getToken)
                {
                    //不执行，跳转
                    return Content(new AjaxResult { state = ResultType.error.ToString(), message = "错误" }.ToJson());
                }
            }

            var data = new UserData()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "王山",
                Age = 2,
                Birthday = "1991-1-3"
            };
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = data.ToJson() }.ToJson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestRemove()
        {
            return Content("清空成功。");
        }
    }
}
