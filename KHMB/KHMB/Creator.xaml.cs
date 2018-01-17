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
    // her samler vi knapper til de forskellige "create" knapper
    public partial class Creator : Window
    {
        public Creator()
        {
            InitializeComponent();
            if (CurrentUser.IsAdmin == true)
            {
                btn_CreateESP.IsEnabled = true;
                btn_CreateResource.IsEnabled = true;
                btn_CreateResourceType.IsEnabled = true;
                btn_CreateTarif.IsEnabled = true;
                btn_CreateUser.IsEnabled = true;
            }
            else
            {
                btn_CreateESP.IsEnabled = false;
                btn_CreateResource.IsEnabled = false;
                btn_CreateResourceType.IsEnabled = false;
                btn_CreateTarif.IsEnabled = false;
                btn_CreateUser.IsEnabled = false;
            }
        }

        private void NewJob_Click(object sender, RoutedEventArgs e)
        {
            Job NJ = new Job();
            NJ.ShowDialog();
        }

        private void btn_ShowScreen_Click(object sender, RoutedEventArgs e)
        {
            Show showScreen = new Show();
            showScreen.ShowDialog();
        }
        // skal kun kunne ses af admin
        private void btn_CreateResourceType_Click(object sender, RoutedEventArgs e)
        {
            ResourceType createRT = new ResourceType();
            createRT.ShowDialog();
        }
        // skal kun kunne ses af admin
        private void btn_CreateUser_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            newUser.Show();
        }
        // skal kun kunne ses af admin
        private void btn_CreateResource_Click(object sender, RoutedEventArgs e)
        {
            Resource createR = new Resource();
            createR.ShowDialog();
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow returnWindow = new MainWindow();
            returnWindow.Show();
            this.Close();
        }
        // skal kun kunne ses af admin
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tarif CT = new Tarif();
            CT.ShowDialog();
        }
        // skal kun kunne ses af admin
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ESP CESP = new ESP();
            CESP.ShowDialog();
        }
    }
}
