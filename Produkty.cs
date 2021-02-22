using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Produkty
    {

        public int produktID { get; set; }
        public string nazwaProduktu { get; set; }
        public int kategoriaID { get; set; }
        public int dostawcaID { get; set; }
        public int cena { get; set; }
        public int iloscMagazyn { get; set; }
        public int iloscZamowienie { get; set; }

        public Produkty(int produktID, string nazwaProduktu, int kategoriaID, int dostawcaID, int cena, int iloscMagazyn, int iloscZamowienie)
        {
            this.produktID = produktID;
            this.nazwaProduktu = nazwaProduktu;
            this.kategoriaID = kategoriaID;
            this.dostawcaID = dostawcaID;
            this.cena = cena;
            this.iloscMagazyn = iloscMagazyn;
            this.iloscZamowienie = iloscZamowienie;
        }

    }
}
