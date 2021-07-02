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
using System.Data;
using WpfProject3App.Classes;

namespace WpfProject3App
{
    /// <summary>
    /// Interaction logic for ThemaEdit.xaml
    /// </summary>
    public partial class ThemaEdit : Window
    {
        public ThemaEdit(DataRowView row)
        {
            InitializeComponent();
            FillScreen(row);
        }
        public void FillScreen(DataRowView row)
        {
            tbId.Text = row["ThemaId"].ToString();
            tbThema.Text = row["Thema"].ToString();


        }



        public void Update_Click(object sender, RoutedEventArgs e)
        {
            ThemaDB DB = new ThemaDB();
            if (DB.UpdateThema(tbId.Text, tbThema.Text))
            {
                MessageBox.Show($"Thema {tbId.Text} edited");
               
            }
            else
            {
                MessageBox.Show($"editting for {tbId.Text} failed");
            }
            this.Close();
        }

        
    }
}
