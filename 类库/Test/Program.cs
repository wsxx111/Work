using FrameworkOfGoodMan.Tools.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //  IOHelper.SerializeToXml(p1, "xuleihua", "People", false);

            //List<People> list = new List<People>();
            //People p1 = new People();
            //p1.Address = "上海大厅sss";
            //People p2 = new People();
            //p2.Address = "北京大厅sss";
            //list.Add(p1);
            //list.Add(p2);
            //IOHelper.SerializeToXml(list, FileType.Xml, "serialPath", "peoples", false);
            //List<People> lists2 = (List<People>)IOHelper.DeserializeFromXML(typeof(List<People>), FileType.Xml, "serialPath", "peoples", false);   
            //Console.WriteLine("OK");

            //People p = new People();
            //Man m = new Man();
            //SonTest ff = new SonTest();
            //ff.DoWork(p);
            //People v = new Man();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(Gccp.getInstance().Name);
            //}
            //Console.WriteLine("开始");
            //NewClass.Show("show方法");
            //string dd=NewClass.x;
            //if (dd != null)
            //{
            //    Console.WriteLine("最后");
            //}
            //Mack b = Singletonfactory.getSingle();
            //b.talk();
            
            

            Console.ReadKey();

        }

    }
    #region
    public class People
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class Man : People
    {
        public string Grade { get; set; }
    }

    public class Test
    {
        public void DoWork(Man m)
        {
            Console.WriteLine("test被调用");
        }
    }

    public class SonTest : Test
    {
        public void DoWork(People m)
        {
            Console.WriteLine("SonTest被调用");
        }
    }

    public class Gccp
    {
        private string _name;

        private static int instancecount = 4;
        static Gccp()
        {
            for (int i = 0; i < instancecount; i++)
            {
                GccpLists.Add(new Gccp(i.ToString()));
            }
        }
        private Gccp(string name)
        {
            _name = name;
        }

        private static List<Gccp> GccpLists = new List<Gccp>();

        public string Name { get { return _name; } }

        public static Gccp getInstance()
        {
            Random r = new Random();
            int index = r.Next(0, instancecount);
            return GccpLists[index];
        }

    }

    public class Mack
    {
        private Mack()
        {

        }
        public void talk()
        {
            Console.WriteLine("这是我");
        }
    }

    public class Singletonfactory
    {
        private static Mack _mack;

        static Singletonfactory()
        {

            _mack = (Mack)Activator.CreateInstance(Type.GetType("Test.Mack"));
            //(Mack)Assembly.GetExecutingAssembly().CreateInstance("Test.Mack", false); 
            //(Mack)Activator.CreateInstance(Type.GetType("Test.Mack"));
            //(Mack)Assembly.GetAssembly(typeof(Mack)).CreateInstance("Mack");
        }

        public static Mack getSingle()
        {
            return _mack;
        }
    }
    #endregion

    public class NewClass
    {
        //static NewClass()
        //{
        //    Console.WriteLine("构造");
        //}

        private NewClass()
        {
            Console.WriteLine("私有构造");
        }

        public static string x = NewChild.inst;// Show("前面");

        public static string Show(string s)
        {
            Console.WriteLine(s);
            return s;
        }

        private class NewChild
        {
            static NewChild()
            {
                Console.WriteLine("子构造");
            }

            public static readonly string inst = ShowChild("子");
            public static string ShowChild(string s)
            {
                Console.WriteLine(s);
                return s;
            }
        }

    }

   
}
