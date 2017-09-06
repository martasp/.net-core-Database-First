using System;
using System.Collections.Generic;

namespace mvctest.Models
{
    public partial class Studentas
    {
        public Studentas()
        {
            Atsiskaitymas = new HashSet<Atsiskaitymas>();
            ModulisFkStudentasidStudentas1Navigation = new HashSet<Modulis>();
            ModulisFkStudentasidStudentasNavigation = new HashSet<Modulis>();
        }

        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime? Metai { get; set; }
        public string Universitetas { get; set; }
        public int IdStudentas { get; set; }
        public int FkDestytojasidDestytojas { get; set; }

        public Destytojas FkDestytojasidDestytojasNavigation { get; set; }
        public ICollection<Atsiskaitymas> Atsiskaitymas { get; set; }
        public ICollection<Modulis> ModulisFkStudentasidStudentas1Navigation { get; set; }
        public ICollection<Modulis> ModulisFkStudentasidStudentasNavigation { get; set; }
    }
}
