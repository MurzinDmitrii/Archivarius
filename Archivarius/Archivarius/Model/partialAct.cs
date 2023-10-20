using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public string JudgeFullInfo
        {
            get
            {
                return "Судья - " + Worker.FirstName + " " + Worker.Name[0] + "." +
                (Worker.Patronimyc == null ? "" : $"{Worker.Patronimyc[0]}.");
            }
        }
    }
}
