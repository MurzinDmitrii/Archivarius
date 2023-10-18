using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivarius.Model
{
    partial class Case
    {
        public string ActFullNumber
        {
            get
            {
                return "Дело №" + CategoryID + "-" + Number + "//" + Date.Year;
            }
        }
    }
}
