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

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy AddWindowsKlienci.xaml
    /// </summary>
    public partial class AddWindowsKlienci : Window
    {
        private string mode;
        private MainWindow parentWindow;

        public AddWindowsKlienci()
        {
            InitializeComponent();
        }

        public AddWindowsKlienci(string mode, MainWindow wnd)
        {
            InitializeComponent();

            if (mode == "dodaj")
            {
                this.Title = "Dodaj klienta";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if (mode == "edytuj")
            {
                this.Title = "Edytuj klienta";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtklientID.Text = parentWindow.wybranyKlient.klientID.ToString();
                txtnazwaFirmy.Text = parentWindow.wybranyKlient.nazwaFirmy;
                txtnazwaKontaktowa.Text = parentWindow.wybranyKlient.nazwaKontaktowa;
                txtadres.Text = parentWindow.wybranyKlient.adres;
                txtmiasto.Text = parentWindow.wybranyKlient.miasto;
                txtkodPocztowy.Text = parentWindow.wybranyKlient.kodPocztowy;
                txtkraj.Text = parentWindow.wybranyKlient.kraj;
                txttelefon.Text = parentWindow.wybranyKlient.kraj;
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

            if(mode == "dodaj")
            {
                cmd.Parameters.AddWithValue("@nazwaFirmy", txtnazwaFirmy.Text);
                cmd.Parameters.AddWithValue("@nazwaKontaktowa", txtnazwaKontaktowa.Text);
                cmd.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd.Parameters.AddWithValue("@miasto", txtmiasto.Text);
                cmd.Parameters.AddWithValue("@kodPocztowy", txtkodPocztowy.Text);
                cmd.Parameters.AddWithValue("@kraj", txtkraj.Text);
                cmd.Parameters.AddWithValue("@telefon", txttelefon.Text);
                cmd.CommandText = "INSERT INTO Klienci VALUES (@nazwaFirmy, @nazwaKontaktowa," +
                    "@adres, @miasto, @kodPocztowy, @kraj, @telefon)";
                cmd.ExecuteNonQuery();
            }
            else if(mode == "edytuj")
            {
                cmd.Parameters.AddWithValue("@klientID", txtklientID.Text);
                cmd.Parameters.AddWithValue("@nazwaFirmy", txtnazwaFirmy.Text);
                cmd.Parameters.AddWithValue("@nazwaKontaktowa", txtnazwaKontaktowa.Text);
                cmd.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd.Parameters.AddWithValue("@miasto", txtmiasto.Text);
                cmd.Parameters.AddWithValue("@kodPocztowy", txtkodPocztowy.Text);
                cmd.Parameters.AddWithValue("@kraj", txtkraj.Text);
                cmd.Parameters.AddWithValue("@telefon", txttelefon.Text);

                cmd.CommandText = "UPDATE Klienci set nazwaFirmy = @nazwaFirmy, nazwaKontaktowa = @nazwaKontaktowa," +
                    "adres = @adres, miasto = @miasto, kodPocztowy = @kodPocztowy, " +
                    "kraj = @kraj, telefon = @telefon WHERE klientID = @klientID";
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
