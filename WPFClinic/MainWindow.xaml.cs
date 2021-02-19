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
//using System.ComponentModel.DataAnnotations.Schema;

namespace WPFClinic
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        projektjimmyEntities context = new projektjimmyEntities();
        //CollectionViewSource wizytyViewSource;
        CollectionViewSource pacjentViewSource;
        //CollectionViewSource lekarzViewSource;
        //CollectionViewSource czasViewSource;
        //CollectionViewSource chorobaViewSource;

        public MainWindow()
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
                string query = "INSERT INTO pacjent(imie, nazwisko, pesel, miasto, ulica, nrdomu, dataurodzenia, telefon, mail) values('" + this.imie.Text + "','" + this.nazwisko.Text + "','" + this.miasto.Text + "','" + this.ulica.Text + "','" + this.nrdomu.Text + "','" + this.pesel.Text + "','" + this.mail.Text + "','" + this.dataurodzenia + "','" + this.telefon + "');";
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
        //usuwanie
        //private void Delete_Order(object sender, ExecutedRoutedEventArgs e)
        //{ 
        //    var cur = pacjentViewSource.View.CurrentItem as pacjent;

        //    var cust = (from c in context.pacjents
        //                where c.CustomerID == cur.CustomerID
        //                select c).FirstOrDefault();

        //    if (cust != null)
        //    {
        //        foreach (var ord in cust.Orders.ToList())
        //        {
        //            Delete_Order(ord);
        //        }
        //        context.Customers.Remove(cust);
        //    }
        //    context.SaveChanges();
        //    custViewSource.View.Refresh();
        //}
        //private void Delete_Order(Order order)
        //{
        //    // Find the order in the EF model.  
        //    var ord = (from o in context.Orders.Local
        //               where o.OrderID == order.OrderID
        //               select o).FirstOrDefault();

        //    // Delete all the order_details that have  
        //    // this Order as a foreign key  
        //    foreach (var detail in ord.Order_Details.ToList())
        //    {
        //        context.Order_Details.Remove(detail);
        //    }

        //    // Now it's safe to delete the order.  
        //    context.Orders.Remove(ord);
        //    context.SaveChanges();

        //    // Update the data grid.  
        //    pacjentViewSource.View.Refresh();
        //}

        //private void DeleteOrderCommandHandler(object sender, ExecutedRoutedEventArgs e)
        //{
        //    // Get the Order in the row in which the Delete button was clicked.  
        //    Order obj = e.Parameter as Order;
        //    Delete_Order(obj);
        //}


        //refresh

            //protected void Timer1_Tick(object sender, EventArgs e)
            //{
            //    FillDataGridView();
            //}

            //protected void FillDataGridView()
            //{
            //    DataSet objDs = new DataSet();
            //    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
            //    SqlDataAdapter myCommand;
            //    string select = "SELECT * FROM Table1";
            //    myCommand = new SqlDataAdapter(select, myConnection);
            //    myCommand.SelectCommand.CommandType = CommandType.Text;
            //    myConnection.Open();
            //    myCommand.Fill(objDs);
            //    GridView1.DataSource = objDs;
            //    GridView1.DataBind();
            //}
    }
}
