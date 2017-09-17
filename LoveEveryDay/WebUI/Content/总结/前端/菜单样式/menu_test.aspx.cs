using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoveEveryDay.WebUI.Content.总结.前端.菜单样式
{
    public partial class menu_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Menu.Text = generateMenuHtml();
        }

        //生成菜单Html代码
        public string generateMenuHtml()
        {
            StringBuilder str = new StringBuilder();
            List<NavMenu> list = GetData.getMenuListData();
            if (list != null)
            {
                str.Append("<ul>");
                foreach (var entity in list.Where(k => k.ParentID == ""))
                {
                    str.AppendFormat(" <li class=\"L_item\"><a href=\"{0}\">{1}</a>", entity.LinkUrl, entity.Title);
                    var subs = list.Where(k => k.ParentID == entity.ID).ToList();
                    if (subs.Count > 0)
                    {
                        str.Append("<ul>");
                        foreach (var subEntity in subs)
                        {
                            str.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", subEntity.LinkUrl, subEntity.Title);
                        }
                        str.Append("</ul>");
                    }
                    str.Append("</li>");
                }
                str.Append("</ul>");
            }
            
            return str.ToString();
        }
    }

    public class NavMenu
    {
        //常规ID
        public string ID { get; set; }

        //菜单名
        public string Title { get; set; }

        //父节点ID
        public string ParentID { get; set; }

        //对应链接
        public string LinkUrl { get; set; }

        //对应图标
        public string IconImg { get; set; }

        //是否删除
        public int IsDelete { get; set; }

        //创建时间
        public DateTime CreateTime { get; set; }
    }

    public class GetData
    {
        public static List<NavMenu> getMenuListData()
        {
            string sql = @" SELECT [ID],[Title],[ParentID],[LinkUrl],[IconImg]  FROM [NavMenu] with(nolock) 
                            where [IsDelete]=0 order by [ParentID],[CreateTime] ";
            List<NavMenu> list = new List<NavMenu>();
            DbDataReader dataReader = null;// DBUniversalHelper.ExecuteReader(CommandType.Text, sql);
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var entity = new NavMenu();

                    entity.ID = dataReader["ID"].ToString();
                    entity.Title = dataReader["Title"].ToString();
                    entity.ParentID = dataReader["ParentID"].ToString();
                    entity.LinkUrl = dataReader["LinkUrl"].ToString();
                    entity.IconImg = dataReader["IconImg"].ToString();
                    list.Add(entity);
                }
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}