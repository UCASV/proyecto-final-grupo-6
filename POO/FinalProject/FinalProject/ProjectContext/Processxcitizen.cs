using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Processxcitizen
    {
        public string IdCitizen { get; set; }
        public int IdProcess { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
        public virtual ProcessVaccination IdProcessNavigation { get; set; }
    }
}
