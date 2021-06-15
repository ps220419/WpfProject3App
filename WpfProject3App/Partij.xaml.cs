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
    /// Interaction logic for Partij.xaml
    /// </summary>
    public partial class Partij : Window
    {

        PartijDB _dbPartij = new PartijDB();
        public Partij()
        {
            InitializeComponent();
            FillDataGrid();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }


        public void FillDataGrid()
        {
            DataTable Partij = _dbPartij.SelectPartij();
            if (Partij != null)
            {
                dgPartij.ItemsSource = Partij.DefaultView;
            }
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgPartij.SelectedItem as DataRowView;

            ParijEdit Edit = new ParijEdit(selectedRow);
            Edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgPartij.SelectedItem as DataRowView;

            if (_dbPartij.DeletePartij(selectedRow["PartijId"].ToString()))
            {
                MessageBox.Show($"Partij {selectedRow["PartijId"]} Deleted");
            }
            else
            {
                MessageBox.Show($"Deletion for {selectedRow["PartijId"]} failed");
            }

            FillDataGrid();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreatePartij create = new CreatePartij();
            create.ShowDialog();
            FillDataGrid();
        }
    }
}
