using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkDemo
{
    public class BarkModel
    {
        private IList<People> _list;

        public IList<People> getPersons()
        {
            return _list;
        }
        public BarkModel(IList<People> list)
        {
            _list = list;
        }
    }
}
