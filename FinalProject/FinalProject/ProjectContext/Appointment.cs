using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Appointment
    {
        public Appointment()
        {
            ProcessVaccinations = new HashSet<ProcessVaccination>();
        }

        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public int IdPlace { get; set; }
        public int IdEmployee { get; set; }
        public string DuiCitizen { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Place IdPlaceNavigation { get; set; }
        public virtual ICollection<ProcessVaccination> ProcessVaccinations { get; set; }
    }
}
