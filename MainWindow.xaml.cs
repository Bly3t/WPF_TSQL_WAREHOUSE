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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        private List<Dostawcy> dostawcy;
        private List<Kategorie> kategorie;
        private List<Klienci> klienci;
        private List<Kurierzy> kurierzy;
        private List<Pracownicy> pracownicy;
        private List<Produkty> produkty;
        private List<Zamowienia> zamowienia;
        private List<ZamowieniaSzczegoly> zamowieniaSzczegoly;

        public Dostawcy wybranyDostawca = null;
        public Kategorie wybranaKategoria = null;
        public Klienci wybranyKlient = null;
        public Kurierzy wybranyKurier = null;
        public Pracownicy wybranypracownik = null;
        public Produkty wybranyProdukt = null;
        public Zamowienia wybraneZamowienie = null;
        public ZamowieniaSzczegoly wybraneZamowienieSzczegoly = null;

        #region INICJALIZACJA
        public MainWindow()
        {
            InitializeComponent();
            InitializeDbConnection();
        }
        private void InitializeDbConnection()
        {

            conn.StateChange += Conn_StateChange;

            txtStan.Text = conn.State.ToString();
        }

        #endregion

        #region Obsługa zdarzeń

        private void Conn_StateChange(object sender, StateChangeEventArgs e)
        {
            txtStan.Text = conn.State.ToString();
        }


        private void lstDostawcy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstDostawcy.SelectedItems.Count > 0)
                {
                    wybranyDostawca = lstDostawcy.SelectedItems[0] as Dostawcy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void lstKategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstKategorie.SelectedItems.Count > 0)
                {
                    wybranaKategoria = lstKategorie.SelectedItems[0] as Kategorie;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void lstKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstKlienci.SelectedItems.Count > 0)
                {
                    wybranyKlient = lstKlienci.SelectedItems[0] as Klienci;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void lstKurierzy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstKurierzy.SelectedItems.Count > 0)
                {
                    wybranyKurier = lstKurierzy.SelectedItems[0] as Kurierzy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        private void lstPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstPracownicy.SelectedItems.Count > 0)
                {
                    wybranypracownik = lstPracownicy.SelectedItems[0] as Pracownicy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void lstProdukty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstProdukty.SelectedItems.Count > 0)
                {
                    wybranyProdukt = lstProdukty.SelectedItems[0] as Produkty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void lstZamowienia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstZamowienia.SelectedItems.Count > 0)
                {
                    wybraneZamowienie = lstZamowienia.SelectedItems[0] as Zamowienia;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void lstZamowieniaSzczegoly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstZamowieniaSzczegoly.SelectedItems.Count > 0)
                {
                    wybraneZamowienieSzczegoly = lstZamowieniaSzczegoly.SelectedItems[0] as ZamowieniaSzczegoly;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }





        private void BtnPolacz_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                BtnPolacz.IsEnabled = false;
                BtnRozlacz.IsEnabled = true;

                BtnDodaj.IsEnabled = true;
                BtnAktualizuj.IsEnabled = true;
                BtnUsun.IsEnabled = true;

                WypelnijListe();
            }
        }

        private void BtnRozlacz_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();

            if (conn.State == ConnectionState.Closed)
            {
                BtnPolacz.IsEnabled = true;
                BtnRozlacz.IsEnabled = false;

                BtnDodaj.IsEnabled = false;
                BtnAktualizuj.IsEnabled = false;
                BtnUsun.IsEnabled = false;

                WyczyscListe();
            }
        }


        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                TabItem selectedTab = Hurtownia.SelectedItem as TabItem;


                switch (selectedTab.Header)
                {
                    case "Dostawcy":

                        AddWindowDostawcy addWindow = new AddWindowDostawcy("dodaj", this);
                        addWindow.Owner = this;
                        addWindow.Show();
                        break;

                    case "Kategorie":
                        AddWindowKategorie addWindowKategorie = new AddWindowKategorie("dodaj", this);
                        addWindowKategorie.Owner = this;
                        addWindowKategorie.Show();

                        break;

                    case "Klienci":

                        AddWindowsKlienci addWindowKlienci = new AddWindowsKlienci("dodaj", this);
                        addWindowKlienci.Owner = this;
                        addWindowKlienci.Show();


                        break;

                    case "Kurierzy":

                        AddWindowKurierzy addWindowKurierzy = new AddWindowKurierzy("dodaj", this);
                        addWindowKurierzy.Owner = this;
                        addWindowKurierzy.Show();

                        break;

                    case "Pracownicy":

                        addWindowPracownicy addWindowPracownicy = new addWindowPracownicy("dodaj", this);
                        addWindowPracownicy.Owner = this;
                        addWindowPracownicy.Show();

                        break;

                    case "Produkty":

                        AddWindowProdukty addWindowProdukty = new AddWindowProdukty("dodaj", this);
                        addWindowProdukty.Owner = this;
                        addWindowProdukty.Show();
                        break;

                    case "Zamowienia":
                        AddWindowZamowienia addWindowZamowienia = new AddWindowZamowienia("dodaj", this);
                        addWindowZamowienia.Owner = this;
                        addWindowZamowienia.Show();

                        break;

                    case "Zamowienia Szczegoly":
                        AddWindowZamowieniaSzczegoly addWindowZamowieniaSzczegoly = new AddWindowZamowieniaSzczegoly("dodaj", this);
                        addWindowZamowieniaSzczegoly.Owner = this;
                        addWindowZamowieniaSzczegoly.Show();

                        break;
                    default:

                        break;


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAktualizuj_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                TabItem selectedTab = Hurtownia.SelectedItem as TabItem;



                switch (selectedTab.Header)
                {
                    case "Dostawcy":

                        AddWindowDostawcy edtWindow = new AddWindowDostawcy("edytuj", this);
                        edtWindow.Owner = this;
                        edtWindow.Show();

                        wybranyDostawca = null;

                        break;

                    case "Kategorie":
                        AddWindowKategorie editWindowKategorie = new AddWindowKategorie("edytuj", this);
                        editWindowKategorie.Owner = this;
                        editWindowKategorie.Show();

                        wybranaKategoria = null;

                        break;

                    case "Klienci":
                        AddWindowsKlienci editWindowKlienci = new AddWindowsKlienci("edytuj", this);
                        editWindowKlienci.Owner = this;
                        editWindowKlienci.Show();

                        wybranyKlient = null;

                        break;

                    case "Kurierzy":
                        AddWindowKurierzy editWindowKurierzy = new AddWindowKurierzy("edytuj", this);
                        editWindowKurierzy.Owner = this;
                        editWindowKurierzy.Show();

                        wybranyKurier = null;

                        break;

                    case "Pracownicy":

                        addWindowPracownicy editWindowPracownicy = new addWindowPracownicy("edytuj", this);
                        editWindowPracownicy.Owner = this;
                        editWindowPracownicy.Show();

                        wybranypracownik = null;

                        break;

                    case "Produkty":

                        AddWindowProdukty editWindowProdukty = new AddWindowProdukty("edytuj", this);
                        editWindowProdukty.Owner = this;
                        editWindowProdukty.Show();

                        wybranyProdukt = null;

                        break;

                    case "Zamowienia":

                        AddWindowZamowienia editWindowZamowienia = new AddWindowZamowienia("edytuj", this);
                        editWindowZamowienia.Owner = this;
                        editWindowZamowienia.Show();

                        wybraneZamowienie = null;

                        break;

                    case "Zamowienia Szczegoly":

                        AddWindowZamowieniaSzczegoly editWindowZamowieniaSzczegoly = new AddWindowZamowieniaSzczegoly("edytuj", this);
                        editWindowZamowieniaSzczegoly.Owner = this;
                        editWindowZamowieniaSzczegoly.Show();

                        wybraneZamowienieSzczegoly = null;

                        break;

                    default:

                        break;


                }









            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TabItem selectedTab = Hurtownia.SelectedItem as TabItem;

                switch (selectedTab.Header)
                {
                    case "Dostawcy":

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@dostawcaid", wybranyDostawca.dostawcaID);
                        cmd.CommandText = "DELETE FROM Dostawcy WHERE dostawcaid = @dostawcaid";

                        cmd.ExecuteNonQuery();
                        WypelnijListe();

                        break;

                    case "Kategorie":
                        SqlCommand cmdKategorie = new SqlCommand();
                        cmdKategorie.Connection = conn;
                        cmdKategorie.CommandType = CommandType.Text;
                        cmdKategorie.Parameters.AddWithValue("@kategoriaID", wybranaKategoria.kategoriaID);
                        cmdKategorie.CommandText = "DELETE FROM Kategorie WHERE kategoriaID = @kategoriaID";

                        cmdKategorie.ExecuteNonQuery();
                        WypelnijListe();

                        break;

                    case "Klienci":
                        SqlCommand cmdKlienci = new SqlCommand();
                        cmdKlienci.Connection = conn;
                        cmdKlienci.CommandType = CommandType.Text;
                        cmdKlienci.Parameters.AddWithValue("@klientID", wybranyKlient.klientID);
                        cmdKlienci.CommandText = "DELETE FROM Klienci WHERE klientID = @klientID";

                        cmdKlienci.ExecuteNonQuery();
                        WypelnijListe();


                        break;

                    case "Kurierzy":


                        SqlCommand cmdKurierzy = new SqlCommand();

                        cmdKurierzy.Connection = conn;

                        cmdKurierzy.CommandType = CommandType.Text;

                        cmdKurierzy.Parameters.AddWithValue("@kurierID", wybranyKurier.kurierID);

                        cmdKurierzy.CommandText = "DELETE from kurierzy WHERE kurierID = @kurierID";


                        cmdKurierzy.ExecuteNonQuery();

                        WypelnijListe();

                        break;

                    case "Pracownicy":

                        SqlCommand cmdPracownicy = new SqlCommand();
                        cmdPracownicy.Connection = conn;
                        cmdPracownicy.CommandType = CommandType.Text;
                        cmdPracownicy.Parameters.AddWithValue("@pracownikID", wybranypracownik.pracownikID);
                        cmdPracownicy.CommandText = "DELETE from pracownicy where pracownikID = @pracownikID";
                        cmdPracownicy.ExecuteNonQuery();

                        WypelnijListe();

                        break;

                    case "Produkty":

                        SqlCommand cmdProdukty = new SqlCommand();

                        cmdProdukty.Connection = conn;
                        cmdProdukty.CommandType = CommandType.Text;
                        cmdProdukty.Parameters.AddWithValue("@produktID", wybranyProdukt.produktID);
                        cmdProdukty.CommandText = "DELETE from produkty where produktID = @produktID";
                        cmdProdukty.ExecuteNonQuery();

                        WypelnijListe();

                        break;

                    case "Zamowienia":

                        SqlCommand cmdZamowienia = new SqlCommand();

                        cmdZamowienia.Connection = conn;
                        cmdZamowienia.CommandType = CommandType.Text;
                        cmdZamowienia.Parameters.AddWithValue("@zamowienieID", wybraneZamowienie.zamowienieID);
                        cmdZamowienia.CommandText = "DELETE from zamowienia where zamowienieID = @zamowienieID";
                        cmdZamowienia.ExecuteNonQuery();

                        WypelnijListe();

                        break;

                    case "Zamowienia Szczegoly":

                        SqlCommand cmdZamowieniaSzczegoly = new SqlCommand();

                        cmdZamowieniaSzczegoly.Connection = conn;
                        cmdZamowieniaSzczegoly.CommandType = CommandType.Text;
                        cmdZamowieniaSzczegoly.Parameters.AddWithValue("@zamowienieID", wybraneZamowienieSzczegoly.zamowienieID);
                        cmdZamowieniaSzczegoly.CommandText = "DELETE from zamowieniaszczegoly where zamowienieID = @zamowienieID";
                        cmdZamowieniaSzczegoly.ExecuteNonQuery();

                        WypelnijListe();

                        break;

                    default:

                        break;


                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        #endregion


        #region METODY

        public void WypelnijListe()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Dostawcy";

            dostawcy = new List<Dostawcy>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    dostawcy.Add(new Dostawcy((int)reader["dostawcaID"]
                        , reader["nazwaFirmy"].ToString()
                        , reader["nazwa"].ToString()
                        , reader["stanowisko"].ToString()
                        , reader["adres"].ToString()
                        , reader["miasto"].ToString()
                        , reader["kodPocztowy"].ToString()
                        , reader["telefon"].ToString()
                        ));
                }
            }

            lstDostawcy.ItemsSource = dostawcy;



            SqlCommand cmdKategorie = new SqlCommand();
            cmdKategorie.Connection = conn;
            cmdKategorie.CommandType = CommandType.Text;
            cmdKategorie.CommandText = "Select * from Kategorie";

            kategorie = new List<Kategorie>();

            using (SqlDataReader reader = cmdKategorie.ExecuteReader())
            {
                while (reader.Read())
                {
                    kategorie.Add(new Kategorie((int)reader["kategoriaID"]
                        , reader["nazwaKategoria"].ToString()
                        , reader["opis"].ToString()
                        ));
                }
            }
            lstKategorie.ItemsSource = kategorie;

            SqlCommand cmdKlienci = new SqlCommand();
            cmdKlienci.Connection = conn;
            cmdKlienci.CommandType = CommandType.Text;
            cmdKlienci.CommandText = "Select * from Klienci";

            klienci = new List<Klienci>();

            using (SqlDataReader reader = cmdKlienci.ExecuteReader())
            {
                while (reader.Read())
                {
                    klienci.Add(new Klienci((int)reader["KlientID"], reader["nazwaFirmy"].ToString(),
                        reader["nazwaKontaktowa"].ToString(), reader["adres"].ToString(), reader["miasto"].ToString(),
                        reader["kodPocztowy"].ToString(), reader["kraj"].ToString(), reader["kraj"].ToString()));
                }
            }
            lstKlienci.ItemsSource = klienci;


            SqlCommand cmdKurierzy = new SqlCommand();
            cmdKurierzy.Connection = conn;
            cmdKurierzy.CommandType = CommandType.Text;
            cmdKurierzy.CommandText = "SELECT * from Kurierzy";

            kurierzy = new List<Kurierzy>();

            using (SqlDataReader reader = cmdKurierzy.ExecuteReader())
            {
                while (reader.Read())
                {
                    kurierzy.Add(new Kurierzy((int)reader["kurierID"], reader["nazwaFirmy"].ToString(), reader["telefon"].ToString()));
                }
            }
            lstKurierzy.ItemsSource = kurierzy;



            SqlCommand cmdPracownicy = new SqlCommand();
            cmdPracownicy.Connection = conn;
            cmdPracownicy.CommandType = CommandType.Text;
            cmdPracownicy.CommandText = "Select * from Pracownicy";

            pracownicy = new List<Pracownicy>();

            using (SqlDataReader reader = cmdPracownicy.ExecuteReader())
            {
                while (reader.Read())
                {
                    pracownicy.Add(new Pracownicy((int)reader["pracownikID"], reader["imie"].ToString(), reader["nazwisko"].ToString(), reader["dataUrodzenia"].ToString(), reader["dataZatrudnienia"].ToString(), reader["dataZwolnienia"].ToString(), reader["pesel"].ToString(), reader["adres"].ToString(), reader["miasto"].ToString(), reader["email"].ToString()));
                   
                }
                
            }
            lstPracownicy.ItemsSource = pracownicy;



            SqlCommand cmdProdukty = new SqlCommand();
            cmdProdukty.Connection = conn;
            cmdProdukty.CommandType = CommandType.Text;
            cmdProdukty.CommandText = "SELECT * from Produkty";

            produkty = new List<Produkty>();

            using (SqlDataReader reader = cmdProdukty.ExecuteReader())
            {
                while (reader.Read())
                {
                    produkty.Add(new Produkty((int)reader["ProduktID"], reader["nazwaProduktu"].ToString(), (int)reader["kategoriaID"], (int)reader["dostawcaID"], (int)reader["cena"], (int)reader["iloscMagazyn"], (int)reader["iloscZamowienie"]));


                }
            }
            lstProdukty.ItemsSource = produkty;

            SqlCommand cmdZamowienia = new SqlCommand();
            cmdZamowienia.Connection = conn;
            cmdZamowienia.CommandType = CommandType.Text;
            cmdZamowienia.CommandText = "SELECT * from Zamowienia";

            zamowienia = new List<Zamowienia>();

            using (SqlDataReader reader = cmdZamowienia.ExecuteReader())
            {
                while(reader.Read())
                {
                    zamowienia.Add(
                        new Zamowienia((int)reader["zamowienieID"], (int)reader["pracownikID"], (int)reader["kurierID"], (int)reader["klientID"], reader["dataZamowienia"].ToString(), reader["dataNadania"].ToString(), reader["adresDocelowy"].ToString(), reader["miastoDocelowe"].ToString(), reader["kodPocztowy"].ToString(), reader["krajDostarczenia"].ToString()));
                }
            }
            lstZamowienia.ItemsSource = zamowienia;


            SqlCommand cmdZamowieniaSzczegoly = new SqlCommand();
            cmdZamowieniaSzczegoly.Connection = conn;
            cmdZamowieniaSzczegoly.CommandType = CommandType.Text;
            cmdZamowieniaSzczegoly.CommandText = "Select * from zamowieniaszczegoly";

            zamowieniaSzczegoly = new List<ZamowieniaSzczegoly>();

            using (SqlDataReader reader = cmdZamowieniaSzczegoly.ExecuteReader())
            {
                while(reader.Read())
                {
                    zamowieniaSzczegoly.Add(new ZamowieniaSzczegoly((int)reader["zamowienieID"], (int)reader["produktID"], (int)reader["ilosc"]));
                }
            }

            lstZamowieniaSzczegoly.ItemsSource = zamowieniaSzczegoly;


        }

        private void WyczyscListe()
        {
            dostawcy = new List<Dostawcy>();
            lstDostawcy.ItemsSource = dostawcy;

            kategorie = new List<Kategorie>();
            lstKategorie.ItemsSource = kategorie;


            klienci = new List<Klienci>();
            lstKlienci.ItemsSource = klienci;

            kurierzy = new List<Kurierzy>();
            lstKurierzy.ItemsSource = kurierzy;

            pracownicy = new List<Pracownicy>();
            lstPracownicy.ItemsSource = pracownicy;

            produkty = new List<Produkty>();
            lstProdukty.ItemsSource = produkty;

            zamowienia = new List<Zamowienia>();
            lstZamowienia.ItemsSource = zamowienia;

            zamowieniaSzczegoly = new List<ZamowieniaSzczegoly>();
            lstZamowieniaSzczegoly.ItemsSource = zamowieniaSzczegoly;


        }

        #endregion


    }
}