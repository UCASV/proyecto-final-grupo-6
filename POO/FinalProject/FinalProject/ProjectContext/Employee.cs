using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int IdType { get; set; }
        public int IdCabin { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Type IdTypeNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
