using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Archivarius.Model
{
    partial class Query
    {
        public string Color
        {
            get
            {
                if(Complited == false)
                {
                    return "White";
                }
                return "#DDDDDD";
            }
        }
    }
}
