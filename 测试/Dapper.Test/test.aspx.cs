using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace Dapper.Test
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlDiagnosticsDb"].ConnectionString))
            {
                conn.Open();
                var guid = Guid.NewGuid();
                var dog = conn.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });
                var rows = conn.Query("select 1 A, 2 B union all select 3, 4");
                //验证统计数量
                dog.Count();
                //验证属性是否为null
                dog.First();
                //验证属性是否匹配
                var grtId=dog.First().Id;  
            }
        }
    }

    public class Dog
    {
        public int? Age { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }

        public int IgnoredProperty { get { return 1; } }
    }      
}