using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//在不破坏封闭的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可将该对象恢复到原先保存的状态。又叫快照模式
namespace DesignMethod.备忘录模式
{
    public class Program:OpenDesign
    {
        public override void Open()
        {
            List<ContactPerson> persons = new List<ContactPerson>()
            {
                new ContactPerson(){ Name="Learning Hard",MobileNum="123456" },
                new ContactPerson(){ Name="Tony",MobileNum="234567" },
                new ContactPerson(){ Name="Jock",MobileNum="345678" }
            };

            MobileOwner mobileOwner = new MobileOwner(persons);
            mobileOwner.Show();
            //创建备忘录并保存对象
            Caretaker caretaker = new Caretaker();
            caretaker.ContactM = mobileOwner.CreateMemento();
            //更改发起联系人列表
            Console.WriteLine("----移除最后一个联系人----");
            mobileOwner.ContactPersons.RemoveAt(2);
            mobileOwner.Show();
            //恢复到原始状态
            Console.WriteLine("----恢复联系人列表----");
            mobileOwner.RestoreMemento(caretaker.ContactM);
            mobileOwner.Show();
            Console.Read();
        }
    }








     //发起人
    public class MobileOwner
    {
        public MobileOwner(List<ContactPerson> persons)
        {
            ContactPersons = persons;
        }

        //发起人需要保存内部状态
        public List<ContactPerson> ContactPersons { get; set; }

        public void Show()
        {
            Console.WriteLine("联系人列表中有{0}个人", ContactPersons.Count);
            foreach (ContactPerson per in ContactPersons)
            {
                Console.WriteLine("姓名：{0} 号码{1}", per.Name, per.MobileNum);
            }
        }

        //创建备忘录
        public ContactMemento CreateMemento()
        {
            return new ContactMemento(new List<ContactPerson>(this.ContactPersons));
        }

        //将备忘录中的数据备份导入联系人中
        public void RestoreMemento(ContactMemento memento)
        {
            this.ContactPersons = memento.contactPersonBack;
        }
    }

    //管理角色
    public class Caretaker
    {
        public ContactMemento ContactM { get; set; }
    }

    //备忘录
    public class ContactMemento
    {
        //保存发起人的状态
        public List<ContactPerson> contactPersonBack;

        public ContactMemento(List<ContactPerson> persons)
        {
            contactPersonBack = persons;
        }
    }



    //联系人
    public class ContactPerson
    {
        public string MobileNum { get; set; }
        public string Name { get; set; }
    }

}

