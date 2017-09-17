using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieDemo
{
    public interface IEnumera
    {
        int Index { get; set; }

        int Count { get;  }

        object current();

        Die getDie();
    }
}
