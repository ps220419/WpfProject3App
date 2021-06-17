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

namespace WpfProject3App
{
    /// <summary>
    /// Interaction logic for CreateStandpunt.xaml
    /// </summary>
    public partial class CreateStandpunt : Window
    {
        public CreateStandpunt()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
           StandpuntDB Standpunt = new StandpuntDB();
            //if (Standpunt.InsertStandpunt(tbPartij.Text, tbAdres.Text, tbPostcode.Text, tbGemeente.Text, tbEmailAdres.Text, tbTelefoonNummer.Text))
            //{
            //    MessageBox.Show($"Standpunt created");
            //}
            //else
            //{
            //    MessageBox.Show($"creation failed");
            //}
            this.Close();
        }
    }
}
