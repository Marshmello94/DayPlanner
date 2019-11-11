using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egednevnik.Model
{
    abstract class AbstractBaseDuty
    {
        private protected string _title;
        private protected string _description;
        private protected AbstractBaseDuty(string Title,string Description)
        {
            _title = Title;
            _description = Description;
        }
    }
}
