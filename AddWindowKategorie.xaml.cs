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
    /// Logika interakcji dla klasy AddWindowKategorie.xaml
    /// </summary>
    public partial class AddWindowKategorie : Window
    {
        private string mode;
        private MainWindow parentWindow;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public AddWindowKategorie()
        {
            InitializeComponent();
        }

        public AddWindowKategorie(string mode, MainWindow wnd)
        {
            InitializeComponent();

            if (mode == "dodaj")
            {
                this.Title = "Dodaj kategorie";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if (mode == "edytuj")
            {
                this.Title = "Edytuj kategorie";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtkategoriaID.Text = parentWindow.wybranaKategoria.kategoriaID.ToString();
                txtnazwaKategoria.Text = parentWindow.wybranaKategoria.nazwaKategoria;
                txtopis.Text = parentWindow.wybranaKategoria.opis;
            }
            else
            {
                throw new Exception("Niepoprawny tryb dla nowego okna!");
            }

        }

        private void btnOK_ClickKategorie(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = parentWindow.conn;
            cmd.CommandType = CommandType.Text;

            if (mode == "dodaj")
            {
                cmd.Parameters.AddWithValue("@nazwaKategoria", txtnazwaKategoria.Text);
                cmd.Parameters.AddWithValue("@opis", txtopis.Text);
                cmd.CommandText = "INSERT INTO Kategorie VALUES (@nazwakategoria, @opis)";
                cmd.ExecuteNonQuery();
            }
            else if (mode == "edytuj")
            {
                cmd.Parameters.AddWithValue("@kategoriaID", txtkategoriaID.Text);
                cmd.Parameters.AddWithValue("@nazwaKategoria", txtnazwaKategoria.Text);
                cmd.Parameters.AddWithValue("@opis", txtopis.Text);


                cmd.CommandText = "UPDATE Kategorie set nazwaKategoria = @nazwaKategoria," +
                    "opis = @opis" +
                    " where kategoriaID = @kategoriaID";
                cmd.ExecuteNonQuery();
            }

            parentWindow.WypelnijListe();

            this.Close();
        }

        private void btnAnuluj_ClickKategorie(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
