using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarkDemo
{
    public class People
    {
        /// <summary>
        /// 联系人姓名
        /// </summary>

        private string _name;      

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        private bool _isMale;

        public bool IsMale
        {
            get { return _isMale; }
            set { _isMale = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public People(string name, bool isMale, string phone)
        {
            _name = name;
            _isMale = isMale;
            _phone = phone;
        }
    }
}
