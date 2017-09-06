using System;
using System.Collections.Generic;

namespace mvctest.Models
{
    public partial class Atsiskaitymas
    {
        public string Pavadinimas { get; set; }
        public int? Pazymys { get; set; }
        public int IdAtsiskaitymas { get; set; }
        public int FkStudentasidStudentas { get; set; }

        public Studentas FkStudentasidStudentasNavigation { get; set; }
    }
}
