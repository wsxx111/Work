using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrameworkOfGoodMan.Tools.Helper;

namespace TestForm
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                List<People> list = new List<People>();
                People p1 = new People();
                p1.Address = "上海大厅sss";
                People p2 = new People();
                p2.Address = "北京大厅sss";
                list.Add(p1);
                list.Add(p2);
                IOHelper.SerializeToXml(list, FileType.Xml, "serialPath", "peoples", false);
                List<People> lists2 = (List<People>)IOHelper.DeserializeFromXML(typeof(List<People>), FileType.Xml, "serialPath", "peoples", false);
            }
            catch
            {
            }
        }
    }
     
    public class People
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public void ss()
        { 
      
        }
    }
}
