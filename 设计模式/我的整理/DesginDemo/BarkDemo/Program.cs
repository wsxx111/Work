using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PhonePerson p = new PhonePerson();
            BarkManger.Persons = p.ceratebark();
            Console.WriteLine("-----------原来-----------");
            p.showPeople();
            Console.WriteLine("-----------修改-----------");
            p.Persons.RemoveAt(2);
            p.Persons.RemoveAt(2);
            p.Persons.Add(new People("杜九", false, "13524312254"));
            p.Persons.RemoveAt(2);
            p.showPeople();
            Console.WriteLine("-----------恢复-----------");
            p.revertByBark(BarkManger.Persons);
            p.showPeople();
            Console.ReadKey();
        }
    }
}
