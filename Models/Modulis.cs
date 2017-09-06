using System;
using System.Collections.Generic;

namespace mvctest.Models
{
    public partial class Modulis
    {
        public string Kodas { get; set; }
        public string Pavadinimas { get; set; }
        public int FkStudentasidStudentas { get; set; }
        public int FkStudentasidStudentas1 { get; set; }

        public Studentas FkStudentasidStudentas1Navigation { get; set; }
        public Studentas FkStudentasidStudentasNavigation { get; set; }
    }
}
