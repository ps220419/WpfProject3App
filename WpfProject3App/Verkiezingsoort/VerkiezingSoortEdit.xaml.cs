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

namespace WpfProject3App.Verkiezingsoort
{
    /// <summary>
    /// Interaction logic for VerkiezingSoortEdit.xaml
    /// </summary>
    public partial class VerkiezingSoortEdit : Window
    {
        public VerkiezingSoortEdit(DataRowView row)
        {
            InitializeComponent();
            FillScreen(row);
        }

        public void FillScreen(DataRowView row)
        {
            tbSoortId.Text = row["SoortId"].ToString();
            tbVerkiezingSoort.Text = row["Verkiezingsoort"].ToString();
            

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            VerkiezingSoortDB DB = new VerkiezingSoortDB();
            if (DB.UpdateVerkiezingSoort(tbSoortId.Text, tbVerkiezingSoort.Text))
            {
                MessageBox.Show($"VerkiezingSoort {tbSoortId.Text} edited");
                //MainWindow mainwindow = (MainWindow)Application.Current.MainWindow;
                //mainwindow.FillDataGrid();
            }
            else
            {
                MessageBox.Show($"editting for {tbSoortId.Text} failed");
            }
            this.Close();
        }
    }
}

    

