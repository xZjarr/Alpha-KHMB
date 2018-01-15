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
        }
        static void ShowList()
        {
            DB.OpenConnection();
            //Get info from db of the chosen object from drop down.
            DB.CloseConnection();
        }

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            //Show information of the chosen object.
            //(Klaus) Skal ændres til: Åbne nyt vindue med baseret på hvad der skal vises??
            ShowList();
            MainWindow returnWindow = new MainWindow();
            returnWindow.Show();
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
