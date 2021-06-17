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
    /// Interaction logic for Standpunt.xaml
    /// </summary>
    public partial class Standpunt : Window
    {
        StandpuntDB _dbStandpunt = new StandpuntDB();
        public Standpunt()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void Create_Click(object sender, RoutedEventArgs e)

        {
            CreateStandpunt create = new CreateStandpunt();
            create.ShowDialog();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            DataTable Standpunt = _dbStandpunt.SelectStandpunt();
            if (Standpunt != null)
            {
                dgStandpunt.ItemsSource = Standpunt.DefaultView;
            }
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgStandpunt.SelectedItem as DataRowView;

            //StandpuntEdit Edit = new StandpuntEdit(selectedRow);
            //Edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgStandpunt.SelectedItem as DataRowView;

            if (_dbStandpunt.DeleteStandpunt(selectedRow["StandpuntId"].ToString()))
            {
                MessageBox.Show($"Satndpunt {selectedRow["StandpuntId"]} Deleted");
            }
            else
            {
                MessageBox.Show($"Deletion for {selectedRow["StanpuntId"]} failed");
            }

            FillDataGrid();
        }
    }
}