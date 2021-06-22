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

namespace WpfProject3App.Verkiezingsoort
{ 
// Interaction logic for VerkiezingSoortCreate.xaml
// </summary>

    public partial class VerkiezingSoortCreate : Window
{
    public VerkiezingSoortCreate()
    {
        InitializeComponent();
    }
    private void Create_Click(object sender, RoutedEventArgs e)
    {
        VerkiezingSoortDB Soort = new VerkiezingSoortDB();
        if (Soort.InsertVerkiezingSoort(tbVerkiezingsoort.Text))
        {
            MessageBox.Show($"Verkiezingsoort created");
        }
        else
        {
            MessageBox.Show($"creation failed");
        }
        this.Close();
    }
}
}
