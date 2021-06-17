
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
    /// Interaction logic for Verkiezing.xaml
    /// </summary>
    public partial class VerkiezingSoortDB : Window
    {

        VerkiezingSoortDB _dbVerkiezingSoort = new VerkiezingSoortDB();
        public VerkiezingSoortDB()
        {
            InitializeComponent();
            FillDataGrid();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }


        public void FillDataGrid()
        {
            DataTable verkiezing = _dbVerkiezingSoort.SelectVerkiezing();
            if (verkiezing != null)
            {
                dgVerkiezingen.ItemsSource = verkiezing.DefaultView;
            }
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingenSoort.SelectedItem as DataRowView;

            VerkiezingEdit Edit = new VerkiezingEdit(selectedRow);
            Edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingenSoort.SelectedItem as DataRowView;

            if (_dbVerkiezingSoort.DeleteVerkiezing(selectedRow["VerkiezingId"].ToString()))
            {
                MessageBox.Show($"Verkieizing {selectedRow["VerkiezingId"]} Deleted");
            }
            else
            {
                MessageBox.Show($"Deletion for {selectedRow["VerkiezingId"]} failed");
            }

            FillDataGrid();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateVerkiezing create = new CreateVerkiezing();
            create.ShowDialog();
            FillDataGrid();
        }
    }
}
