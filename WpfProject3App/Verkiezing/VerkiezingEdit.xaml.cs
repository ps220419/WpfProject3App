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
    public partial class VerkiezingEdit : Window
    {
        public VerkiezingEdit(DataRowView row)
        {
            InitializeComponent();
            FillScreen(row);
        }


        public void FillScreen(DataRowView row)
        {
            tbId.Text = row["VerkiezingId"].ToString();
            tbSoortId.Text = row["SoortId"].ToString();
            cbVerkiezingsoort.Text = row["Verkiezingsoort"].ToString();
            dpDatum.Text = row["Datum"].ToString();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            VerkiezingDB DB = new VerkiezingDB();
            if (DB.UpdateVerkiezing(tbId.Text, tbSoortId.Text, cbVerkiezingsoort.Text, dpDatum.Text))
            {
                MessageBox.Show($"Verkiezing {tbId.Text} edited");
                //MainWindow mainwindow = (MainWindow)Application.Current.MainWindow;
                //mainwindow.FillDataGrid();
            }
            else
            {
                MessageBox.Show($"editting for {tbId.Text} failed");
            }
            this.Close();
        }
    }
}
