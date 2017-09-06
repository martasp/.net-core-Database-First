using System;
using System.Collections.Generic;

namespace mvctest.Models
{
    public partial class Destytojas
    {
        public Destytojas()
        {
            Studentas = new HashSet<Studentas>();
        }

        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime? Metai { get; set; }
        public int IdDestytojas { get; set; }

        public ICollection<Studentas> Studentas { get; set; }
    }
}
