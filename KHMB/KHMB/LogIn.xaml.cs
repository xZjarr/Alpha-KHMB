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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LogIn1_Click(object sender, RoutedEventArgs e)
        {
            if (Txt_UserName.Text == ""||Txt_PassWord.Password.ToString() == "")
            {
                MessageBox.Show("Please write username and password");
            }
            try
            {
                DB.LogIn();
                
            }
        }
    }
}
