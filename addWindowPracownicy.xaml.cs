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
    /// Logika interakcji dla klasy addWindowPracownicy.xaml
    /// </summary>
    public partial class addWindowPracownicy : Window
    {
        private string mode;
        private MainWindow parentWindow;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public addWindowPracownicy(string mode, MainWindow wnd)
        {
            InitializeComponent();

            if (mode == "dodaj")
            {
                this.Title = "Dodaj pracownika";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if (mode == "edytuj")
            {
                this.Title = "Edytuj pracownika";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtpracownikID.Text = parentWindow.wybranypracownik.pracownikID.ToString();
                txtimie.Text = parentWindow.wybranypracownik.imie.ToString();
                txtnazwisko.Text = parentWindow.wybranypracownik.nazwisko.ToString();
                txtdataUrodzenia.Text = parentWindow.wybranypracownik.dataUrodzenia.ToString();
                txtdataZatrudnienia.Text = parentWindow.wybranypracownik.dataZatrudnienia.ToString();
                txtdataZwolnienia.Text = parentWindow.wybranypracownik.dataZwolnienia.ToString();
                txtpesel.Text = parentWindow.wybranypracownik.pesel.ToString();
                txtadres.Text = parentWindow.wybranypracownik.adres.ToString();
                txtmiasto.Text = parentWindow.wybranypracownik.miasto.ToString();
                txtemail.Text = parentWindow.wybranypracownik.email.ToString();
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

                cmd.Parameters.AddWithValue("@imie", txtimie.Text);
                cmd.Parameters.AddWithValue("@nazwisko", txtnazwisko.Text);
                cmd.Parameters.AddWithValue("@dataUrodzenia", txtdataUrodzenia.Text);
                cmd.Parameters.AddWithValue("@dataZatrudnienia", txtdataZatrudnienia.Text);
                cmd.Parameters.AddWithValue("@dataZwolnienia", txtdataZwolnienia.Text);
                cmd.Parameters.AddWithValue("@pesel", txtpesel.Text);
                cmd.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd.Parameters.AddWithValue("@miasto", txtmiasto.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.CommandText = "INSERT INTO Pracownicy VALUES (@imie, @nazwisko, @dataUrodzenia, @dataZatrudnienia, @dataZwolnienia, @pesel, @adres, @miasto, @email)";
                cmd.ExecuteNonQuery();
            }
            else if (mode == "edytuj")
            {

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = parentWindow.conn;
                cmd2.CommandType = CommandType.StoredProcedure;
                


                cmd2.Parameters.AddWithValue("@pracownikID", txtpracownikID.Text);
                cmd2.Parameters.AddWithValue("@imie", txtimie.Text);
                cmd2.Parameters.AddWithValue("@nazwisko", txtnazwisko.Text);
                

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@dataUrodzenia";
                param1.SqlDbType = SqlDbType.Date;
                param1.Direction = ParameterDirection.Input;
                param1.Value = txtdataUrodzenia.Text;
                cmd2.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@dataZatrudnienia";
                param2.SqlDbType = SqlDbType.Date;
                param2.Direction = ParameterDirection.Input;
                param2.Value = txtdataZatrudnienia.Text;
                cmd2.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@dataZwolnienia";
                param3.SqlDbType = SqlDbType.Date;
                param3.Direction = ParameterDirection.Input;
                param3.Value = txtdataZwolnienia.Text;
                cmd2.Parameters.Add(param3);

                cmd2.Parameters.AddWithValue("@pesel", txtpesel.Text);
                cmd2.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd2.Parameters.AddWithValue("@miasto", txtmiasto.Text);
                cmd2.Parameters.AddWithValue("@email", txtemail.Text);

                cmd2.CommandText = "PracownicyEdytuj";

                cmd2.ExecuteNonQuery();
               
               
               
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



