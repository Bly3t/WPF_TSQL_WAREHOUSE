using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Zamowienia
    {

        public int zamowienieID { get; set; }
        public int pracownikID { get; set; }
        public int kurierID { get; set; }
        public int klientID { get; set; }
        public string dataZamowienia { get; set; }
        public string dataNadania { get; set; }
        public string adresDocelowy { get; set; }
        public string miastoDocelowe { get; set; }
        public string kodPocztowy { get; set; }
        public string krajDostarczenia { get; set; }

        public Zamowienia(int zamowienieID, int pracownikID, int kurierID, int klientID, string dataZamowienia, string dataNadania, string adresDocelowy, string miastoDocelowe, string kodPocztowy, string krajDostarczenia)
        {
            this.zamowienieID = zamowienieID;
            this.pracownikID = pracownikID;
            this.kurierID = kurierID;
            this.klientID = klientID;
            this.dataZamowienia = dataZamowienia;
            this.dataNadania = dataNadania;
            this.adresDocelowy = adresDocelowy;
            this.miastoDocelowe = miastoDocelowe;
            this.kodPocztowy = kodPocztowy;
            this.krajDostarczenia = krajDostarczenia;
        }

    }
}
