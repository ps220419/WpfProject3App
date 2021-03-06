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
    public partial class Verkiezing : Window
    {

        VerkiezingDB _dbVerkiezing = new VerkiezingDB();
        public Verkiezing()
        {
            InitializeComponent();
            FillDataGrid();
            
        }


        public void FillDataGrid()
        {
            DataTable verkiezing = _dbVerkiezing.SelectVerkiezing();
            if (verkiezing != null)
            {
                dgVerkiezingen.ItemsSource = verkiezing.DefaultView;
            }
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingen.SelectedItem as DataRowView;

            VerkiezingEdit Edit = new VerkiezingEdit(selectedRow);
            Edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingen.SelectedItem as DataRowView;

            if (_dbVerkiezing.DeleteVerkiezing(selectedRow["VerkiezingId"].ToString()))
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
