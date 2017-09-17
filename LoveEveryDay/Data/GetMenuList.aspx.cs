using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoveEveryDay.Data
{
    public partial class GetMenuList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = Request.Params["path"];            
            Response.Write(File.ReadAllText(path, Encoding.UTF8));     
        }
    }
}