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
    /// Logika interakcji dla klasy AddWindowZamowienia.xaml
    /// </summary>
    public partial class AddWindowZamowienia : Window
    {
        private string mode;
        private MainWindow parentWindow;
        public SqlDataAdapter da, daa, daaa;
        public DataTable dt, dtt, dttt;
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public AddWindowZamowienia()
        {
            InitializeComponent();
        }

        public AddWindowZamowienia(string mode, MainWindow wnd)
        {
            InitializeComponent();

            da = new SqlDataAdapter("Select pracownikID, imie, nazwisko from Pracownicy", conn);
            dt = new DataTable();
            da.Fill(dt);

            cbIDPracownik.ItemsSource = dt.DefaultView;

            daa = new SqlDataAdapter("Select kurierID, nazwaFirmy from Kurierzy", conn);
            dtt = new DataTable();
            daa.Fill(dtt);

            cbIDKuriera.ItemsSource = dtt.DefaultView;

            daaa = new SqlDataAdapter("Select klientID, nazwaFirmy from klienci", conn);
            dttt = new DataTable();
            daaa.Fill(dttt);

            cbIDKlienta.ItemsSource = dttt.DefaultView;

            if(mode == "dodaj")
            {
                this.Title = "Dodaj Zamowienie";
                btnOK.Content = "Dodaj";

                this.mode = mode;
                this.parentWindow = wnd;
            }
            else if(mode == "edytuj")
            {
                this.Title = "Edytuj Zamowienie";
                btnOK.Content = "Aktualizuj";

                this.mode = mode;
                this.parentWindow = wnd;

                txtzamowienieID.Text = parentWindow.wybraneZamowienie.zamowienieID.ToString();

                cbIDPracownik.SelectedValue = parentWindow.wybraneZamowienie.pracownikID.ToString();
                cbIDKuriera.SelectedValue = parentWindow.wybraneZamowienie.kurierID.ToString();
                cbIDKlienta.SelectedValue = parentWindow.wybraneZamowienie.klientID.ToString();

                txtdataZamowienia.Text = parentWindow.wybraneZamowienie.dataZamowienia.ToString();
                txtdataNadania.Text = parentWindow.wybraneZamowienie.dataNadania.ToString();
                txtadresDocelowy.Text = parentWindow.wybraneZamowienie.adresDocelowy.ToString();
                txtmiastoDocelowe.Text = parentWindow.wybraneZamowienie.miastoDocelowe.ToString();
                txtkodPocztowy.Text = parentWindow.wybraneZamowienie.kodPocztowy.ToString();
                txtkrajDostarczenia.Text = parentWindow.wybraneZamowienie.krajDostarczenia.ToString();
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
                cmd.Parameters.AddWithValue("@pracownikID", cbIDPracownik.SelectedValue);
                cmd.Parameters.AddWithValue("@kurierID", cbIDKuriera.SelectedValue);
                cmd.Parameters.AddWithValue("@klientID", cbIDKlienta.SelectedValue);
                cmd.Parameters.AddWithValue("@dataZamowienia", txtdataZamowienia.Text);
                cmd.Parameters.AddWithValue("@dataNadania", txtdataNadania.Text);
                cmd.Parameters.AddWithValue("@adresDocelowy", txtadresDocelowy.Text);
                cmd.Parameters.AddWithValue("@miastoDocelowe", txtmiastoDocelowe.Text);
                cmd.Parameters.AddWithValue("@kodPocztowy", txtkodPocztowy.Text);
                cmd.Parameters.AddWithValue("@krajDostarczenia", txtkrajDostarczenia.Text);

                cmd.CommandText = "INSERT INTO Zamowienia VALUES(@pracownikID, @kurierID, @klientID, @dataZamowienia, @dataNadania, @adresDocelowy, @miastoDocelowe, @kodPocztowy, @krajDostarczenia)";
                cmd.ExecuteNonQuery();


            }
            else if(mode == "edytuj")
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = parentWindow.conn;
                cmd2.CommandType = CommandType.StoredProcedure;


                cmd2.Parameters.AddWithValue("@zamowienieID", txtzamowienieID.Text);
                cmd2.Parameters.AddWithValue("@pracownikID", cbIDPracownik.SelectedValue);
                cmd2.Parameters.AddWithValue("@kurierID", cbIDKuriera.SelectedValue);
                cmd2.Parameters.AddWithValue("@klientID", cbIDKlienta.SelectedValue);


                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@dataZamowienia";
                param1.SqlDbType = SqlDbType.Date;
                param1.Direction = ParameterDirection.Input;
                param1.Value = txtdataZamowienia.Text;
                cmd2.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@dataNadania";
                param2.SqlDbType = SqlDbType.Date;
                param2.Direction = ParameterDirection.Input;
                param2.Value = txtdataNadania.Text;
                cmd2.Parameters.Add(param2);


                cmd2.Parameters.AddWithValue("@adresDocelowy", txtadresDocelowy.Text);
                cmd2.Parameters.AddWithValue("@miastoDocelowe", txtmiastoDocelowe.Text);
                cmd2.Parameters.AddWithValue("@kodPocztowy", txtkodPocztowy.Text);
                cmd2.Parameters.AddWithValue("@krajDostarczenia", txtkrajDostarczenia.Text);

                cmd2.CommandText = "ZamowieniaEdytuj";

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
