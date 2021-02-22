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
    /// Logika interakcji dla klasy AddWindowKurierzy.xaml
    /// </summary>
    public partial class AddWindowKurierzy : Window
    {
        private string mode;
        private MainWindow parentWindow;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public AddWindowKurierzy()
        {
            InitializeComponent();
        }
        public AddWindowKurierzy(string mode, MainWindow wnd)
        {
            InitializeComponent();
            
            if(mode == "dodaj")
            {
                this.Title = "Dodaj Kuriera";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if (mode == "edytuj")
            {
                this.Title = "Edytuj kuriera";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtkurierID.Text = parentWindow.wybranyKurier.kurierID.ToString();
                txtNazwaFirmy.Text = parentWindow.wybranyKurier.NazwaFirmy;
                txttelefon.Text = parentWindow.wybranyKurier.telefon;

              
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
                cmd.Parameters.AddWithValue("@NazwaFirmy", txtNazwaFirmy.Text);
                cmd.Parameters.AddWithValue("@telefon", txttelefon.Text);

                cmd.CommandText = "INSERT INTO kurierzy VALUES(@NazwaFirmy," +
                    "@telefon)";
                cmd.ExecuteNonQuery();

            }
            else if (mode == "edytuj")
            {
                cmd.Parameters.AddWithValue("@kurierID", txtkurierID.Text);
                cmd.Parameters.AddWithValue("@NazwaFirmy", txtNazwaFirmy.Text);
                cmd.Parameters.AddWithValue("@telefon", txttelefon.Text);

                cmd.CommandText = "UPDATE kurierzy SET NazwaFirmy = @NazwaFirmy, " +
                    "telefon = @telefon " +
                    "WHERE kurierID = @kurierID";

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
