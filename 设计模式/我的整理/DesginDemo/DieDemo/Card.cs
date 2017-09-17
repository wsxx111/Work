using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DieDemo
{
    public class Card
    {       
        public string card_Name { get; set; }
        public string card_openDate { get; set; }

        public Card(string  name,string date)
        {
            card_Name = name;
            card_openDate = date;
        }
    }
}
