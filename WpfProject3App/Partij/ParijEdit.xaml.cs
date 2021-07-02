using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ParijEdit.xaml
    /// </summary>
    public partial class ParijEdit : Window
    {
        public ParijEdit(DataRowView Partij)
        {
            InitializeComponent();
            FillScreen(Partij);
        }


        public void FillScreen(DataRowView Partij)
        {
            tbId.Text = Partij["PartijId"].ToString();
            tbPartij.Text = Partij["PartijName"].ToString();
            tbAdres.Text = Partij["Adres"].ToString();
            tbPostcode.Text = Partij["Postcode"].ToString();
            tbGemeente.Text = Partij["Gemeente"].ToString();
            tbEmailAdres.Text = Partij["EmailAdres"].ToString();
            tbTelefoonNummer.Text = Partij["TelefoonNummer"].ToString();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            PartijDB DB = new PartijDB();
            if (DB.UpdatePartij(tbId.Text, tbPartij.Text, tbAdres.Text, tbPostcode.Text, tbGemeente.Text, tbEmailAdres.Text, tbTelefoonNummer.Text))
            {
                MessageBox.Show($"Partij {tbId.Text} edited");
               
            }
            else
            {
                MessageBox.Show($"editting for {tbId.Text} failed");
            }
            this.Close();
        }
    }
}
