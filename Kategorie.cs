using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Kategorie
    {
        public int kategoriaID { get; set; }
        public string nazwaKategoria { get; set; }
        public string opis { get; set; }
        public Kategorie(int kategoriaID, string nazwaKategoria, string opis)
        {
            this.kategoriaID = kategoriaID;
            this.nazwaKategoria = nazwaKategoria;
            this.opis = opis;
        }
    }
}
