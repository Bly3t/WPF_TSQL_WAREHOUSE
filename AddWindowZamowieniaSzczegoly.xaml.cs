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
    /// Logika interakcji dla klasy AddWindowZamowieniaSzczegoly.xaml
    /// </summary>
    public partial class AddWindowZamowieniaSzczegoly : Window
    {
        private string mode;
        private MainWindow parentWindow;
        public SqlDataAdapter da, daa;
        public DataTable dt, dtt;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public AddWindowZamowieniaSzczegoly()
        {
            InitializeComponent();
        }
        public AddWindowZamowieniaSzczegoly(string mode, MainWindow wnd)
        {
            InitializeComponent();


            da = new SqlDataAdapter("select Z.zamowienieID, K.nazwaFirmy, P.imie, P.nazwisko from Zamowienia Z join Pracownicy P on Z.pracownikID = P.pracownikID join Klienci K on Z.klientID = K.klientID", conn);
            dt = new DataTable();
            da.Fill(dt);

            cbIDZamowienieSzczegoly.ItemsSource = dt.DefaultView;

            daa = new SqlDataAdapter("Select produktID, nazwaProduktu from Produkty", conn);
            dtt = new DataTable();
            daa.Fill(dtt);

            cbIDProdukt.ItemsSource = dtt.DefaultView;


            if (mode == "dodaj")
            {
                this.Title = "Dodaj szczegoly zamowienia";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if (mode == "edytuj")
            {

                this.Title = "Edytuj szczegoly zamowienia";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                cbIDZamowienieSzczegoly.SelectedValue = parentWindow.wybraneZamowienieSzczegoly.zamowienieID.ToString();
                cbIDProdukt.SelectedValue = parentWindow.wybraneZamowienieSzczegoly.produktID.ToString();

                txtilosc.Text = parentWindow.wybraneZamowienieSzczegoly.ilosc.ToString();


            }
            else
            {
                throw new Exception("Niepoprawny tryb dla nowego okna!");
            }
        }
        public void btnOK_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = parentWindow.conn;
            cmd.CommandType = CommandType.Text;

            if (mode == "dodaj")
            {
                cmd.Parameters.AddWithValue("@zamowienieID", cbIDZamowienieSzczegoly.SelectedValue);
                cmd.Parameters.AddWithValue("@produktID", cbIDProdukt.SelectedValue);
                cmd.Parameters.AddWithValue("@ilosc", txtilosc.Text);

                cmd.CommandText = "INSERT INTO zamowieniaszczegoly values(@zamowienieID, @produktID, @ilosc)";
                cmd.ExecuteNonQuery();


            }
            else if(mode == "edytuj")
            {
                cmd.Parameters.AddWithValue("@zamowienieID", cbIDZamowienieSzczegoly.SelectedValue);
                cmd.Parameters.AddWithValue("@produktID", cbIDProdukt.SelectedValue);
                cmd.Parameters.AddWithValue("@ilosc", txtilosc.Text);

                cmd.CommandText = "UPDATE zamowieniaszczegoly set " +
                    "zamowienieID = @zamowienieID," +
                    "produktID = @produktID," +
                    "ilosc = @ilosc " +
                    "where zamowienieid = @zamowienieID";

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
