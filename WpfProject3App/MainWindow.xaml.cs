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

namespace WpfProject3App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void Partij_Click(object sender, RoutedEventArgs e)
        {
            Partij Partij = new Partij();
            Partij.ShowDialog();
        }

        private void Standpunten_Click(object sender, RoutedEventArgs e)
        {
            Standpunt Standpunt = new Standpunt();
            Standpunt.ShowDialog();
        }

        private void Thema_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Verkiezing_Click(object sender, RoutedEventArgs e)
        {
            Verkiezing Verkiezing = new Verkiezing();
            Verkiezing.ShowDialog();
        }

        private void Verkiezingsoort_Click(object sender, RoutedEventArgs e)
        {
            VerkiezingSoort verkiezingsoort = new VerkiezingSoort();
            verkiezingsoort.ShowDialog();
        }

        private void Verkiezingspartijen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
