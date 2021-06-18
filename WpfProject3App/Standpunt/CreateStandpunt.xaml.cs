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
using WpfProject3App.Classes;

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

        public void Create_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem comboPartij = (ComboBoxItem)cbPartijNaam.SelectedItem;
            string SelectedPartij = comboPartij.Content.ToString();

            ComboBoxItem comboThema = (ComboBoxItem)cbThema.SelectedItem;
            string SelectedThema = comboPartij.Content.ToString();



            StandpuntDB Standpunt = new StandpuntDB();
            if (Standpunt.InsertStandpunt(SelectedPartij, SelectedThema, tbStandpunt.Text))
            {
                MessageBox.Show($"Standpunt created");
            }
            else
            {
                MessageBox.Show($"creation failed");
            }
            this.Close();
        }
    }
}
