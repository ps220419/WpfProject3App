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
using System.Data;


namespace WpfProject3App
{
    /// <summary>
    /// Interaction logic for Thema.xaml
    /// </summary>
    public partial class Thema : Window
    {

        ThemaDB _dbThema = new ThemaDB();
        public Thema()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            DataTable Thema = _dbThema.SelectThema();
            if (Thema != null)
            {
                dgThema.ItemsSource = Thema.DefaultView;
            }
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgThema.SelectedItem as DataRowView;

            ThemaEdit Edit = new ThemaEdit(selectedRow);
            Edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgThema.SelectedItem as DataRowView;

            if (_dbThema.DeleteThema(selectedRow["ThemaId"].ToString()))
            {
                MessageBox.Show($"Thema {selectedRow["ThemaId"]} Deleted");
            }
            else
            {
                MessageBox.Show($"Deletion for {selectedRow["ThemaId"]} failed");
            }

            FillDataGrid();
        }
    }
}
