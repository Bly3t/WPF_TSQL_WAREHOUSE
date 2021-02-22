using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Kurierzy
    {
        public int kurierID { get; set; }
        public string NazwaFirmy { get; set; }
        public string telefon { get; set; }

        public Kurierzy(int kurierID, string NazwaFirmy, string telefon)
        {
            this.kurierID = kurierID;
            this.NazwaFirmy = NazwaFirmy;
            this.telefon = telefon;
        }

    }
}
