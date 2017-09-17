using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkDemo
{
    public class PhonePerson
    {
        private IList<People> p_list;

        public PhonePerson()
        {
            p_list = new List<People>();
            p_list.Add(new People("张三", false, "15245125235"));
            p_list.Add(new People("李四", false, "13526532562"));
            p_list.Add(new People("王五", true, "15415215363"));
            p_list.Add(new People("马六", true, "13452635214"));
            p_list.Add(new People("赵七", true, "13325125421"));
            p_list.Add(new People("牛八", false, "13956425621"));
        }
        //列表展示
        public void showPeople()
        {
            foreach (var item in p_list)
            {
                Console.WriteLine(string.Format("姓名{0},性别{1},手机号{2}", item.Name, item.IsMale == true ? "男" : "女", item.Phone));
            }
            Console.WriteLine(string.Format("共{0}条", p_list.Count));
        }

        //获取
        public IList<People> Persons { get { return p_list; } set { p_list = value; } }

        //创建备份
        public BarkModel ceratebark()
        {
            return new BarkModel(new List<People>(this.p_list));
            //下面这个方式是错误的，因为是引用类型，所有根本起不到备份的作用
            //return new BarkModel(p_list);
        }

        //从备份中回复
        public void revertByBark(BarkModel b)
        {
            p_list = b.getPersons();
        }
    }
}
