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

namespace WPFClinic
{
    /// <summary>
    /// Logika interakcji dla klasy loginscreen.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnLogginClick(object sender, RoutedEventArgs e)
        {
            string user, pass;
            user = txtloggin.Text;
            pass = txtpassword.Password;

            if (user == "admin" && pass == "admin")
            {
                new AppWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niepoprawne login i hasło");
            }
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
