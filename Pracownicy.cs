using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Pracownicy
    {


        public int pracownikID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string dataUrodzenia { get; set; }
        public string dataZatrudnienia { get; set; }
        public string dataZwolnienia { get; set; }
        public string pesel { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public string email { get; set; }

        public Pracownicy(int pracownikID, string imie, string nazwisko, string dataUrodzenia, string dataZatrudnienia, string dataZwolnienia, string pesel, string adres, string miasto, string email)
        {
            this.pracownikID = pracownikID;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = dataUrodzenia;
            this.dataZatrudnienia = dataZatrudnienia;
            this.dataZwolnienia = dataZwolnienia;
            this.pesel = pesel;
            this.adres = adres;
            this.miasto = miasto;
            this.email = email;
        }
    }
}