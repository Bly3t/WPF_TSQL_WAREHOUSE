using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy AddWindowProdukty.xaml
    /// </summary>
    public partial class AddWindowProdukty : Window
    {
        private string mode;
        private MainWindow parentWindow;
        public SqlDataAdapter da, daa;
        public DataTable dt, dtt;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public AddWindowProdukty()
        {
            InitializeComponent();

        }

        public AddWindowProdukty(string mode, MainWindow wnd)
        {
            InitializeComponent();

            da = new SqlDataAdapter("Select kategoriaID, nazwaKategoria from Kategorie", conn);
            dt = new DataTable();
            da.Fill(dt);

            cbIDkategori.ItemsSource = dt.DefaultView;

            daa = new SqlDataAdapter("Select dostawcaID, nazwaFirmy from dostawcy", conn);
            dtt = new DataTable();
            daa.Fill(dtt);

            cbIDdostawcy.ItemsSource = dtt.DefaultView;




            if (mode == "dodaj")
            {
                this.Title = "Dodaj Produkt";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if(mode == "edytuj")
            {
               
                this.Title = "Edytuj Produkt";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtproduktID.Text = parentWindow.wybranyProdukt.produktID.ToString();
                txtnazwaProduktu.Text = parentWindow.wybranyProdukt.nazwaProduktu;



                cbIDkategori.SelectedValue = parentWindow.wybranyProdukt.kategoriaID.ToString();
                cbIDdostawcy.SelectedValue = parentWindow.wybranyProdukt.dostawcaID.ToString();

                txtcena.Text = parentWindow.wybranyProdukt.cena.ToString();
                txtiloscMagazyn.Text = parentWindow.wybranyProdukt.iloscMagazyn.ToString();
                txtiloscZamowienie.Text = parentWindow.wybranyProdukt.iloscZamowienie.ToString();

            }
            else
            {
                throw new Exception("Niepoprawny tryb dla nowego okna!");
            }
        }
        public void btnOK_Click(object sender , RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = parentWindow.conn;
            cmd.CommandType = CommandType.Text;

            if(mode == "dodaj")
            {

                cmd.Parameters.AddWithValue("@nazwaProduktu", txtnazwaProduktu.Text);
                
                cmd.Parameters.AddWithValue("@kategoriaID", cbIDkategori.SelectedValue);
                cmd.Parameters.AddWithValue("@dostawcaID", cbIDdostawcy.SelectedValue);
                 
                cmd.Parameters.AddWithValue("@cena", txtcena.Text);
                cmd.Parameters.AddWithValue("@iloscMagazyn", txtiloscMagazyn.Text);
                cmd.Parameters.AddWithValue("@iloscZamowienie", txtiloscZamowienie.Text);

                cmd.CommandText = "INSERT INTO PRODUKTY VALUES(@nazwaProduktu, @kategoriaID, @dostawcaID, @cena, @iloscMagazyn, @iloscZamowienie)";
                cmd.ExecuteNonQuery();
            }
            else if(mode == "edytuj")
            {
                cmd.Parameters.AddWithValue("@produktID", txtproduktID.Text);
                cmd.Parameters.AddWithValue("@nazwaProduktu", txtnazwaProduktu.Text);
                
                cmd.Parameters.AddWithValue("@kategoriaID", cbIDkategori.SelectedValue);
                cmd.Parameters.AddWithValue("@dostawcaID", cbIDdostawcy.SelectedValue);
                 
                cmd.Parameters.AddWithValue("@cena", txtcena.Text);
                cmd.Parameters.AddWithValue("@iloscMagazyn", txtiloscMagazyn.Text);
                cmd.Parameters.AddWithValue("@iloscZamowienie", txtiloscZamowienie.Text);

                
                cmd.CommandText = "UPDATE Produkty set nazwaProduktu = @nazwaProduktu," +
                    "kategoriaID = @kategoriaID," +
                    "dostawcaID = @dostawcaID," +
                    "cena = @cena," +
                    "iloscMagazyn = @iloscMagazyn," +
                    "iloscZamowienie = @iloscZamowienie " +
                    "where produktID = @produktID";
         

                cmd.ExecuteNonQuery();
            }

            parentWindow.WypelnijListe();
            this.Close();
        }
        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
