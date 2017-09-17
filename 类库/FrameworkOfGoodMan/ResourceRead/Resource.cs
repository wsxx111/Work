using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace FrameworkOfGoodMan.Tools.ResourceRead
{
    public static class Resource
    {   

        private static  global::System.Globalization.CultureInfo resourceCulture;    

        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        public static byte[] MobilePhone
        {
            get
            {                
                return null;
                //object obj = r.GetObject("MobilePhone", resourceCulture);
                //return ((byte[])(obj));
            }
        }
    }
}
