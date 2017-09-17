using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkOfGoodMan.Tools.Helper;
using System.Xml;
using FrameworkOfGoodMan.Tools.Mail;
namespace TestWeb
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              // System.Collections.ArrayList dd= EnumHelper.ToArrayList(typeof(FileType));             
             // FileType dd = EnumHelper.GetEnumName<FileType>(".txt");
              //  int ss = 0;
              //  int dsfds = (ss + 2) / ss;
              //  var ds = IOHelper.WriteLog("WebForm写入", "LogPath", true);
                //List<People> list = new List<People>();
                People p1 = new People();
                p1.Address = "哈哈";
                p1.Name = "哈33哈";
                p1.Age =34;
             //   People p2 = new People();
              //  p2.Address = "北京大厅sss";
                //list.Add(p1);
                //list.Add(p2);
               // IOHelper.SerializeToXml(p1,FileType.Xml,"serialPath", "test", true);
               // People p2 = (People)IOHelper.DeserializeFromXML(typeof(People), FileType.Xml, "serialPath", "test", true);  
                //List<People> lists2 = (List<People>)IOHelper.DeserializeFromXML(typeof(List<People>), FileType.Xml, "serialPath", "peoples", true); 
                //bool ff = IOHelper.BinarySerialize<People>(p1, FileType.Bat, "serialPath", "New", true);
                //People p2 = (People)IOHelper.BinaryDesrialize<People>(new People(), FileType.Bat, "serialPath", "New", true);

                XmlDocument doc = new XmlDocument();
              //  string path = HttpContext.Current.Server.MapPath("test.xml");
              //  doc.LoadXml(path);
               // XmlNodeList xnl = doc.SelectNodes("/root/CityDetail");
                //doc.LoadXml();               

               // XmlElement root = doc.DocumentElement;
             // XmlNode xn = doc.SelectSingleNode("xml");
            //  string t1 = xn.SelectSingleNode("//People").InnerText;    
                string[] sendpeople = { "wangkaibj@fang.com","893130389@qq.com" };
                Mail.Send(false, "测试", "你好，我是你的测试邮件,发了凉粉", "13814432662","413761", "smtp.163.com", sendpeople);

              
            }
            catch 
            {
               // IOHelper.WriteExceptionLog(ex, "errorLogPath", true);
            }

        }
    }

    [Serializable]
    public class People
    {
        public string Name;
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Say()
        {
            return 5;
        }
    }
}