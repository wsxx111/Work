using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorDemo
{
    public class School
    {
        private IList<People> peoples = null;

        public School()
        {
            peoples = new List<People>();
            peoples.Add(new Teacher("李老师",34,"英语老师"));
            peoples.Add(new Student("牛四", 11,"五年级"));
            peoples.Add(new Student("李三", 12, "六年级"));
            peoples.Add(new Teacher("李老师", 14, "数学老师"));
            peoples.Add(new Teacher("李老师", 38, "政治老师"));
            peoples.Add(new Student("赵七", 8, "二年级"));
            peoples.Add(new Student("马六", 11, "四年级"));
            peoples.Add(new Teacher("杜老师", 36, "语文老师"));
            peoples.Add(new Student("王五", 14, "三年级"));

        }

        public IList<People> getList()
        {
            return peoples;
        }
    }
}
