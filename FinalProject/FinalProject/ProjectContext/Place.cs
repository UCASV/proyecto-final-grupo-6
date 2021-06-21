using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Place
    {
        public Place()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Place1 { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
