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
        public string CaseFullNumber
        {
            get
            {
                return "№" + CategoryID + "-" + Number + "/" + Date.Year;
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
        public string BackColor
        {
            get; set;
        }
        public string ButtonType
        {
            get
            {
                if(Act.Count() % 2 == 1)
                {
                    return "Выдать";
                }
                else
                {
                    return "Принять";
                }
            }
        }
    }
}
