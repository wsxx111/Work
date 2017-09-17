using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace FrameworkOfGoodMan.Tools.ResourceRead
{
    internal class SlResource
    {

        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;


        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>     
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FrameworkOfGoodMan.ResourceRead", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>         
        internal static System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] MobilePhone
        {
            get
            {
                object obj = ResourceManager.GetObject("MobilePhone", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }

}
