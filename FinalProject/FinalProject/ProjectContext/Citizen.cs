using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
            Processxcitizens = new HashSet<Processxcitizen>();
        }

        public string Dui { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int IdInstitution { get; set; }
        public int IdGroup { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Processxcitizen> Processxcitizens { get; set; }
    }
}
