using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class ZamowieniaSzczegoly
    {

        public int zamowienieID { get; set; }
        public int produktID { get; set; }
        public int ilosc { get; set; }
        public ZamowieniaSzczegoly(int zamowienieID, int produktID, int ilosc)
        {
            this.zamowienieID = zamowienieID;
            this.produktID = produktID;
            this.ilosc = ilosc;
        }

    }
}
