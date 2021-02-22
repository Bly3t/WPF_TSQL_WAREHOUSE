using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Dostawcy
    {
        public int dostawcaID { get; set; }
        public string nazwaFirmy { get; set; }
        public string nazwa { get; set; }
        public string stanowisko { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public string kodPocztowy { get; set; }
        public string telefon { get; set; }

        public Dostawcy(int dostawcaID, string nazwaFirmy, string nazwa, string stanowisko, string adres, string miasto, string kodPocztowy, string telefon)
        {
            this.dostawcaID = dostawcaID;
            this.nazwaFirmy = nazwaFirmy;
            this.stanowisko = stanowisko;
            this.adres = adres;
            this.miasto = miasto;
            this.kodPocztowy = kodPocztowy;
            this.telefon = telefon;
        }
    }
}
