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
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace WPFClinic
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        projektjimmyEntities context = new projektjimmyEntities();
        CollectionViewSource pacjentViewSource;
        //CollectionViewSource wizytyViewSource;
        //CollectionViewSource lekarzViewSource;
        //CollectionViewSource czasViewSource;
        //CollectionViewSource chorobaViewSource;

        public AppWindow()
        {
            InitializeComponent();
            pacjentViewSource = ((CollectionViewSource)(FindResource("pacjentViewSource")));
            //wizytyViewSource = ((CollectionViewSource)(FindResource("wizytyViewSource")));
            //lekarzViewSource = ((CollectionViewSource)(FindResource("lekarzViewSource")));
            //czasViewSource = ((CollectionViewSource)(FindResource("czasViewSource")));
            //chorobaViewSource = ((CollectionViewSource)(FindResource("chorobaViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.pacjents.Load();
            //context.wizyties.Load();
            //context.lekarzs.Load();
            //context.czas.Load();
            //context.chorobas.Load();

            pacjentViewSource.Source = context.pacjents.Local;
            //wizytyViewSource.Source = context.wizyties.Local;
            //lekarzViewSource.Source = context.lekarzs.Local;
            //czasViewSource.Source = context.czas.Local;
            //chorobaViewSource.Source = context.chorobas.Local;
        }

        //dodawanie
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlCon1 = new SqlConnection(@"Data Source=LAPTOP-PPHH4AFT\SQLEXPRESS;Initial Catalog=projektjimmy;Integrated Security=True");
                if (sqlCon1.State == ConnectionState.Closed)
                    sqlCon1.Open();
                string query = "INSERT INTO pacjent(imie, nazwisko, pesel, miasto, ulica, nrdomu, telefon, mail) values('" + this.imie.Text + "','" + this.nazwisko.Text + "','" + this.pesel.Text + "','" + this.miasto.Text + "','" + this.ulica.Text + "','" + this.nrdomu.Text + "','" + this.mail.Text + "','" /*+ this.dataurodzenia + "','"*/ + this.telefon + "');";
                SqlCommand sqlCmd1 = new SqlCommand(query, sqlCon1);
                SqlDataReader sqlDataReader1;
                sqlDataReader1 = sqlCmd1.ExecuteReader();
                MessageBox.Show("Product added to database");
                while (sqlDataReader1.Read())
                {
                }
                sqlCon1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
