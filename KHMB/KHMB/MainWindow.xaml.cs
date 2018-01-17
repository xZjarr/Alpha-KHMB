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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KHMB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Made by Klaus
        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            Show showWindow = new Show();
            showWindow.Show();
            this.Close();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            Creator creatorWindow = new Creator();
            creatorWindow.Show();
            this.Close();
        }

        private void LogInTest_Click(object sender, RoutedEventArgs e)
        {
            LogIn lgin = new LogIn();
            lgin.Show();
            this.Close();
        }
    }
}
