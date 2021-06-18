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
    /// Interaction logic for CreateVerkiezing.xaml
    /// </summary>
    public partial class CreateVerkiezing : Window
    {
        public CreateVerkiezing()
        {
            InitializeComponent();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            VerkiezingDB verkiezing = new VerkiezingDB();
            if (verkiezing.InsertVerkiezing(Convert.ToString(cbVerkiezingsoort.SelectedItem), Convert.ToString(dpDatum.SelectedDate)))
            {
                MessageBox.Show($"Verkiezing created");
            }
            else
            {
                MessageBox.Show($"creation failed");
            }
            this.Close();
        }
    }
}
