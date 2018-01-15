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
    /// Interaction logic for ShowList.xaml
    /// </summary>
    public partial class ShowList : Window
    {
        public ShowList(string chosenObject)
        {
            InitializeComponent();
            lbl_Title.Content = chosenObject;
            //List<> items = DB.();
            //listbox_Show.ItemsSource = items;

        }
        static void ShowListOfChosenObject()
        {
            DB.OpenConnection();

            //Get info from db of the chosen object from drop down.
            DB.CloseConnection();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow returnWindow = new MainWindow();
            returnWindow.Show();
            this.Close();
        }
    }
}
