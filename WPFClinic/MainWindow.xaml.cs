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

    }
}
