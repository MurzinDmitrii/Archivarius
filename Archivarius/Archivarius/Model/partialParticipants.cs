using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivarius.Model
{
    partial class Participants
    {
        public string ParticipantsFull
        {
            get
            {
                return FirstName + " " + LastName[0] + "." +
                (Patronymic == null ? "" : $"{Patronymic[0]}.") + 
                (Phone == null ? "" : $"({Phone})");
            }
        }
    }
}
