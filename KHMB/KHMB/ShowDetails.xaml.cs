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
    /// Interaction logic for ShowDetails.xaml
    /// </summary>
    public partial class ShowDetails : Window
    {
        public ShowDetails()
        {
                InitializeComponent();

            JobO chosenJob = SelectedTempJob.ChosenJob;
            lbl_CreatedFill.Content = chosenJob.Created;
            lbl_DeadlineFill.Content = chosenJob.Deadline;
            lbl_CreatedByFill.Content = chosenJob.Created;
            lbl_NameFill.Content = chosenJob.JobName;
            lbl_PriorityFill.Content = chosenJob.Priority;

            //UserO chosenUser = SelectedTempUser.ChosenUser;
            //lbl_NameTitle.Content = ("Username: ");
            //lbl_CreatedByTitle.Content = ("Fornavn: ");
            //lbl_CreatedTitle.Content = ("Efternavn: ");
            //lbl_DeadlineTitle.Content = ("Password: ");
            //lbl_PriorityTitle.Content = ("Is User admin:");
            //lbl_NameFill.Content = chosenUser.UserName;
            //lbl_CreatedByFill.Content = chosenUser.FirstName;
            //lbl_CreatedFill.Content = chosenUser.SurName;
            //lbl_DeadlineFill.Content = chosenUser.Password;
            //lbl_PriorityFill.Content = chosenUser.IsAdmin;
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow returnWindow = new MainWindow();
            returnWindow.Show();
            this.Close();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
