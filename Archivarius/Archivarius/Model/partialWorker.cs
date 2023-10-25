using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivarius.Model
{
    partial class Worker
    {
        public string WorkerFullName
        {
            get
            {
                return FirstName + " " + (Name == null ? "" : $"{Name[0]}.") +
                (Patronimyc == null ? "" : $"{Patronimyc[0]}.");
            }
        }
    }
}
