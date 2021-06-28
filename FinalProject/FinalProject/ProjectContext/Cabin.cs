using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Cabin
    {
        public Cabin()
        {
            Employees = new HashSet<Employee>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
