using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Session
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public int IdEmployee { get; set; }
        public int IdCabin { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
