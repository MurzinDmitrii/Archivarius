//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Archivarius.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Responder
    {
        public int StringNumber { get; set; }
        public int ParticipantID { get; set; }
        public int CategoryID { get; set; }
        public int Number { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Case Case { get; set; }
        public virtual Participants Participants { get; set; }
    }
}
