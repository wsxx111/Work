using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoveEveryDay.Data
{
    public partial class FileTree : System.Web.UI.Page
    {
        private static string[] s_IgnoreFolders = null;
        private static string[] s_IgnoreFiles = null;
        private static string  rootPathConfig = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            var getIgnoreFolders = Request.QueryString["ig_folder"];
            var getIgnoreFiles = Request.QueryString["ig_file"];
            var getRootPathConfig = Request.QueryString["rootpath"];
            s_IgnoreFolders = ConfigurationManager.AppSettings[getIgnoreFolders].ToString().Split(',');
            s_IgnoreFiles = ConfigurationManager.AppSettings[getIgnoreFiles].ToString().Split(',');
            rootPathConfig = ConfigurationManager.AppSettings[getRootPathConfig];
            Response.Write(getMenuTree(rootPathConfig));
        }

        public string getMenuTree(string rootPathconfig)
        {
            System.IO.DirectoryInfo topDir = System.IO.Directory.GetParent(HttpContext.Current.Request.MapPath("/"));
            string rootPath = topDir.Parent.FullName + rootPathconfig;// ConfigurationManager.AppSettings["rootPath"];                                 
            JsTreeNode root = new JsTreeNode();
            RecursiveDirectory(rootPath, root);
            return getTreeHtml(root);
            // return root.children.ToJson();
        }

        public string getTreeHtml(JsTreeNode nodeObj)
        {
            StringBuilder str = new StringBuilder();

            if (nodeObj != null && nodeObj.children != null)
            {
                str.Append("<ul id=\"red\" class=\"filetree\">");
                foreach (var o in nodeObj.children)
                {
                    if (o.children == null)
                    {
                        str.AppendFormat("<li><a class=\"file\" data-filetype=\"{2}\" data-path=\"{0}\" href=\"javascript:void(0)\">{1}</a></li>", o.attributes.FilePath, o.text, o.attributes.FileType);
                    }
                    else
                    {
                        str.AppendFormat("<li><span class=\"folder\">{0}</span><ul>", o.text);
                        str.Append(generateHtml(o));
                        str.Append("</ul></li>");
                    }
                }
                str.Append("</ul>");
            }

            return str.ToString();
        }

        private string generateHtml(JsTreeNode nodeObj)
        {
            StringBuilder str = new StringBuilder();
            foreach (var o in nodeObj.children)
            {
                if (o.children == null)
                {
                    str.AppendFormat("<li><a class=\"file\" data-filetype=\"{2}\" data-path=\"{0}\" href=\"javascript:void(0)\">{1}</a></li>", o.attributes.FilePath, o.text, o.attributes.FileType);
                }
                else
                {
                    str.AppendFormat("<li><span class=\"folder\">{0}</span><ul>", o.text);
                    str.Append(generateHtml(o));
                    str.Append("</ul></li>");
                }

            }
            return str.ToString();
        }

        private static void RecursiveDirectory(string fullPath, JsTreeNode root)
        {
            DirectoryInfo dir = new DirectoryInfo(fullPath);
            DirectoryInfo[] subDirArray = dir.GetDirectories();
            FileInfo[] fileArray = dir.GetFiles();

            List<JsTreeNode> children = new List<JsTreeNode>(subDirArray.Length + fileArray.Length);

            foreach (DirectoryInfo dinfo in subDirArray)
            {
                if (Array.Find<string>(s_IgnoreFolders, x => string.Compare(x, dinfo.Name, true) == 0) != null)
                    continue;

                JsTreeNode node = new JsTreeNode();
                node.text = dinfo.Name;
                node.attributes = new JsTreeNodeCustAttr();

                RecursiveDirectory(dinfo.FullName, node);

                if (node.children != null && node.children.Count > 0)
                {
                    children.Add(node);
                }
            }


            Dictionary<string, JsTreeNode> nestNodes = new Dictionary<string, JsTreeNode>(fileArray.Length, StringComparer.OrdinalIgnoreCase);

            foreach (FileInfo finfo in fileArray)
            {
                JsTreeNode node = new JsTreeNode();
                var isExit = false;
                foreach (var d in s_IgnoreFiles)
                {
                    if (finfo.Name.Contains(d))
                    {
                        isExit = true;
                    }
                }
                if (isExit)
                {
                    continue;
                }
                node.text = finfo.Name;
                node.iconCls = GetIconByFileName(finfo.Name);
                node.attributes = new JsTreeNodeCustAttr(finfo.FullName, finfo.Extension.ToLower());

                if (node.iconCls == "icon-cs2")
                    nestNodes.Add(finfo.Name, node);
                else
                    children.Add(node);
            }

            foreach (JsTreeNode node in children)
            {
                if (node.iconCls == "icon-aspx" || node.iconCls == "icon-ascx" || node.iconCls == "icon-master")
                {
                    JsTreeNode nestNode;
                    if (nestNodes.TryGetValue(string.Concat(node.text, ".cs"), out nestNode))
                    {
                        node.children = new List<JsTreeNode>(1);
                        node.children.Add(nestNode);
                    }
                }
            }

            foreach (JsTreeNode child in children)
                if (child.children != null && child.children.Count > 0)
                    child.state = "closed";

            if (children.Count > 0)
                root.children = children;
        }

        private static string GetIconByFileName(string filename)
        {
            if (filename.EndsWith(".aspx.cs", StringComparison.OrdinalIgnoreCase) ||
                filename.EndsWith(".ascx.cs", StringComparison.OrdinalIgnoreCase) ||
                filename.EndsWith(".master.cs", StringComparison.OrdinalIgnoreCase))
                return "icon-cs2";

            if (filename.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                return "icon-cs";

            if (filename.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
                return "icon-aspx";

            if (filename.EndsWith(".ascx", StringComparison.OrdinalIgnoreCase))
                return "icon-ascx";

            if (filename.EndsWith(".ashx", StringComparison.OrdinalIgnoreCase))
                return "icon-ashx";

            if (filename.EndsWith(".master", StringComparison.OrdinalIgnoreCase))
                return "icon-master";

            if (filename.EndsWith(".config", StringComparison.OrdinalIgnoreCase))
                return "icon-config";

            if (filename.EndsWith(".css", StringComparison.OrdinalIgnoreCase))
                return "icon-css";

            if (filename.EndsWith(".js", StringComparison.OrdinalIgnoreCase))
                return "icon-js";

            if (filename.EndsWith(".asax", StringComparison.OrdinalIgnoreCase))
                return "icon-asax";

            if (filename.EndsWith(".skin", StringComparison.OrdinalIgnoreCase))
                return "icon-skin";

            if (filename.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
                return "icon-sql";

            return null;
        }



        public sealed class JsTreeNode
        {
            public string text;
            public string state;
            public string iconCls;
            public List<JsTreeNode> children;
            public JsTreeNodeCustAttr attributes;
        }


        public sealed class JsTreeNodeCustAttr
        {
            public static readonly string InvalidFilePath = "###";

            public string FilePath;
            public string FileType;

            public JsTreeNodeCustAttr()
            {
                this.FilePath = InvalidFilePath;
                this.FileType = string.Empty;
            }
            public JsTreeNodeCustAttr(string path, string ext)
            {
                this.FilePath = path;
                this.FileType = ext;
            }
        }
    }
    public static class Extension
    {

        /// <summary>
        /// 返回对象的JSON序列化的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (obj == null)
                return string.Empty;

            return (new JavaScriptSerializer()).Serialize(obj);
        }
    }

}