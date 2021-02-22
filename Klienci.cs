using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Klienci
    {
        public int klientID { get; set; }
        public string nazwaFirmy { get; set; }
        public string nazwaKontaktowa { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public string kodPocztowy { get; set; }
        public string kraj { get; set; }
        public string telefon { get; set; }

        public Klienci(int klientID, string nazwaFirmy, string nazwaKontaktowa, string adres, string miasto, string kodPocztowy, string kraj, string telefon)
        {
            this.klientID = klientID;
            this.nazwaFirmy = nazwaFirmy;
            this.nazwaKontaktowa = nazwaKontaktowa;
            this.adres = adres;
            this.miasto = miasto;
            this.kodPocztowy = kodPocztowy;
            this.kraj = kraj;
            this.telefon = telefon;
        }


    }
}
