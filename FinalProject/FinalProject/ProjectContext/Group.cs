using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class Group
    {
        public Group()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string Group1 { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
