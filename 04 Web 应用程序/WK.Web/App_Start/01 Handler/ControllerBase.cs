using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WK.Web
{
    [HandlerLogin(true)]
    public abstract class ControllerBase : Controller
    {
    }
}