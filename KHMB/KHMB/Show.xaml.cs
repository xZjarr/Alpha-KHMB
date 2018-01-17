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

namespace KHMB
{
    /// <summary>
    /// Interaction logic for Show.xaml
    /// </summary>
    public partial class Show : Window
    {
        public Show()
        {
            InitializeComponent();
            if (CurrentUser.IsAdmin == true)
            {
                EnableItems();
            }
        }

        private void EnableItems()
        {
            cbxi_ResourceTypes.IsEnabled = true;
            cbxi_Users.IsEnabled = true;
            cbxi_Tarif.IsEnabled = true;
            cbxi_ESP.IsEnabled = true;
        }

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            string chosen = cmbBox_Chose.Text;
            ShowList sl = new ShowList(chosen);
            sl.Show();
            this.Close();
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow returnWindow = new MainWindow();
            returnWindow.Show();
            this.Close();
        }

    }
}
