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
    /// Logika interakcji dla klasy logowanie.xaml
    /// </summary>
    public partial class logowanie : Window
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
        public logowanie()
        {
            InitializeComponent();
        }

        private void BtnLoguj_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                String query = "Select Count (*) from DaneLogowania Where login like @login and haslo like @haslo ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", txtnazwaUzyt.Text);
                cmd.Parameters.AddWithValue("@haslo", txtHaslo.Password);
                int ile = Convert.ToInt32(cmd.ExecuteScalar());
                if (ile == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login lub Haslo jest nieprawidłowe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }
    }
}