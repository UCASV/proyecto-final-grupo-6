using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class ProcessVaccination
    {
        public ProcessVaccination()
        {
            Processxcitizens = new HashSet<Processxcitizen>();
        }

        public int Id { get; set; }
        public DateTime DatetimeRegistered { get; set; }
        public DateTime DatetimeInitiation { get; set; }
        public DateTime DatetimeVaccine { get; set; }
        public DateTime DatetimeEffect { get; set; }

        public virtual ICollection<Processxcitizen> Processxcitizens { get; set; }
    }
}
