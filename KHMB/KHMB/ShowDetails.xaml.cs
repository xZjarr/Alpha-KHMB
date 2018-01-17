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
        public ShowDetails(string subject)
        {
            InitializeComponent();

            if (subject == "Jobs")
            {
                lbl_Title.Content = "Job";
                JobO chosenJob = SelectedTempJob.ChosenJob;
                lbl_CreatedFill.Content = chosenJob.Created;
                lbl_DeadlineFill.Content = chosenJob.Deadline;
                lbl_CreatedByFill.Content = chosenJob.Created;
                lbl_NameFill.Content = chosenJob.JobName;
                lbl_PriorityFill.Content = chosenJob.Priority;
            }
            else if (subject == "Users")
            {
                lbl_Title.Content = "User";
                UserO chosenUser = SelectedTempUser.ChosenUser;
                lbl_NameTitle.Content = ("Username: ");
                lbl_CreatedByTitle.Content = ("Fornavn: ");
                lbl_CreatedTitle.Content = ("Efternavn: ");
                lbl_DeadlineTitle.Content = ("Password: ");
                lbl_PriorityTitle.Content = ("Is User admin:");
                lbl_NameFill.Content = chosenUser.UserName;
                lbl_CreatedByFill.Content = chosenUser.FirstName;
                lbl_CreatedFill.Content = chosenUser.SurName;
                lbl_DeadlineFill.Content = chosenUser.Password;
                lbl_PriorityFill.Content = chosenUser.IsAdmin;
            }
            else if (subject == "Tarif")
            {
                lbl_Title.Content = "Tarif";
                TO chosenTarif = SelectedTempTarif.ChosenTarif;
                lbl_NameTitle.Content = ("Price: ");
                lbl_CreatedByTitle.Content = ("Start: ");
                lbl_CreatedTitle.Content = ("End: ");
                lbl_DeadlineTitle.Content = ("");
                lbl_PriorityTitle.Content = ("");
                lbl_NameFill.Content = chosenTarif.Cost;
                lbl_CreatedByFill.Content = chosenTarif.StartTime;
                lbl_CreatedFill.Content = chosenTarif.EndTime;
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Show returnWindow = new Show();
            returnWindow.Show();
            this.Close();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((string)lbl_Title.Content == "Job")
            {
                Job chosenJob = new Job();
                chosenJob.EditJob(SelectedTempJob.ChosenJob.JobID, SelectedTempJob.ChosenJob.CreatedUserID);
            }
            else if ((string)lbl_Title.Content == "User")
            {
                User chosenUser = new User();
                UserO selectedUser = SelectedTempUser.ChosenUser;
                chosenUser.EditUser(selectedUser.UserID);
            }
            else if ((string)lbl_Title.Content == "Tarif")
            {
                Tarif.Edit(SelectedTempTarif.ChosenTarif.Cost, SelectedTempTarif.ChosenTarif.StartTime, SelectedTempTarif.ChosenTarif.EndTime);
            }
        }
    }
}
