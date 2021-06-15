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
using WpfProject3App.Classes;

namespace WpfProject3App
{
    /// <summary>
    /// Interaction logic for CreatePartij.xaml
    /// </summary>
    public partial class CreatePartij : Window
    {
        public CreatePartij()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            PartijDB Partij = new PartijDB();
            if (Partij.InsertPartij(tbPartij.Text, tbAdres.Text, tbPostcode.Text, tbGemeente.Text, tbEmailAdres.Text, tbTelefoonNummer.Text))
            {
                MessageBox.Show($"Partij created");
            }
            else
            {
                MessageBox.Show($"creation failed");
            }
            this.Close();
        }
    }
}
