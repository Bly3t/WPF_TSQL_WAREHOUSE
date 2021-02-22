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
    /// Logika interakcji dla klasy AddWindowDostawcy.xaml
    /// </summary>
    public partial class AddWindowDostawcy : Window
    {

        private string mode;
        private MainWindow parentWindow;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public AddWindowDostawcy()
        {
            InitializeComponent();
        }

        public AddWindowDostawcy(string mode, MainWindow wnd)
        {
            InitializeComponent();

            if (mode == "dodaj")
            {
                this.Title = "Dodaj dostawce";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if (mode == "edytuj")
            {
                this.Title = "Edytuj dostawce";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtdostawcaID.Text = parentWindow.wybranyDostawca.dostawcaID.ToString();
                txtnazwaFirmy.Text = parentWindow.wybranyDostawca.nazwaFirmy;
                txtnazwa.Text = parentWindow.wybranyDostawca.nazwa;
                txtstanowisko.Text = parentWindow.wybranyDostawca.stanowisko;
                txtadres.Text = parentWindow.wybranyDostawca.adres;
                txtmiasto.Text = parentWindow.wybranyDostawca.miasto;
                txtkodPocztowy.Text = parentWindow.wybranyDostawca.kodPocztowy;
                txttelefon.Text = parentWindow.wybranyDostawca.telefon;
            }
            else
            {
                throw new Exception("Niepoprawny tryb dla nowego okna!");
            }
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = parentWindow.conn;
            cmd.CommandType = CommandType.Text;

            if (mode == "dodaj")
            { 
                cmd.Parameters.AddWithValue("@nazwaFirmy", txtnazwaFirmy.Text);
                cmd.Parameters.AddWithValue("@nazwa", txtnazwa.Text);
                cmd.Parameters.AddWithValue("@stanowisko", txtstanowisko.Text);
                cmd.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd.Parameters.AddWithValue("@miasto", txtmiasto.Text);
                cmd.Parameters.AddWithValue("@kodPocztowy", txtkodPocztowy.Text);
                cmd.Parameters.AddWithValue("@telefon", txttelefon.Text);
                cmd.CommandText = "INSERT INTO Dostawcy VALUES (@nazwaFirmy, @nazwa, @stanowisko, @adres, @miasto, @kodPocztowy, @telefon)";
                cmd.ExecuteNonQuery();
            }
            else if (mode == "edytuj")
            {
                cmd.Parameters.AddWithValue("@dostawcaID", txtdostawcaID.Text);
                cmd.Parameters.AddWithValue("@nazwaFirmy", txtnazwaFirmy.Text);
                cmd.Parameters.AddWithValue("@nazwa", txtnazwa.Text);
                cmd.Parameters.AddWithValue("@stanowisko", txtstanowisko.Text);
                cmd.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd.Parameters.AddWithValue("@miasto", txtmiasto.Text);
                cmd.Parameters.AddWithValue("@kodPocztowy", txtkodPocztowy.Text);
                cmd.Parameters.AddWithValue("@telefon", txttelefon.Text);

                cmd.CommandText = "UPDATE Dostawcy set nazwaFirmy = @nazwafirmy," +
                    "nazwa = @nazwa," +
                    "stanowisko = @stanowisko," +
                    "adres = @adres," +
                    "miasto = @miasto," +
                    "kodPocztowy = @kodPocztowy," +
                    "telefon = @telefon" +
                    " where dostawcaID = @dostawcaID";
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
