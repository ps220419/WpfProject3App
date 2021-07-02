
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
using WpfProject3App.Verkiezingsoort;

namespace WpfProject3App
{
    /// <summary>
    /// Interaction logic for VerkiezingSoort.xaml
    /// </summary>
    public partial class VerkiezingSoort : Window
    {

        VerkiezingSoortDB _dbVerkiezingSoort = new VerkiezingSoortDB();
        

        public VerkiezingSoort()
        {
            InitializeComponent();
            FillDataGrid();
            
        }


        public void FillDataGrid()
        {
            DataTable verkiezingsoort = _dbVerkiezingSoort.SelectVerkiezingSoort();
            if (verkiezingsoort != null)
            {
                dgSoort.ItemsSource = verkiezingsoort.DefaultView;
            }
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgSoort.SelectedItem as DataRowView;

            VerkiezingSoortEdit Edit = new VerkiezingSoortEdit(selectedRow);
            Edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgSoort.SelectedItem as DataRowView;

            if (_dbVerkiezingSoort.DeleteVerkiezingSoort(selectedRow["SoortId"].ToString()))
            {
                MessageBox.Show($"Verkiezingsoort {selectedRow["SoortId"]} Deleted");
            }
            else
            {
                MessageBox.Show($"Deletion for {selectedRow["SoortId"]} failed");
            }

            FillDataGrid();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            VerkiezingSoortCreate create = new VerkiezingSoortCreate();
            create.ShowDialog();
            FillDataGrid();
        }
    }
}
