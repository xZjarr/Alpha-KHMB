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
                JobO chosenJob = SelectedTemp.ChosenJob;
                lbl_CreatedFill.Content = chosenJob.Created;
                lbl_DeadlineFill.Content = chosenJob.Deadline;
                UserO createdBy = DB.GetUser(chosenJob.CreatedUserID);
                lbl_CreatedByFill.Content = (createdBy.FirstName+""+createdBy.SurName);
                lbl_NameFill.Content = chosenJob.JobName;
                lbl_PriorityFill.Content = chosenJob.Priority;
            }
            else if (subject == "Users")
            {
                lbl_Title.Content = "User";
                UserO chosenUser = SelectedTemp.ChosenUser;
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
                TO chosenTarif = SelectedTemp.ChosenTarif;
                lbl_NameTitle.Content = ("Price: ");
                lbl_CreatedByTitle.Content = ("Start: ");
                lbl_CreatedTitle.Content = ("End: ");
                lbl_DeadlineTitle.Content = ("");
                lbl_PriorityTitle.Content = ("");
                lbl_NameFill.Content = chosenTarif.Cost;
                lbl_CreatedByFill.Content = chosenTarif.StartTime;
                lbl_CreatedFill.Content = chosenTarif.EndTime;
            }
            else if (subject == "ESPs")
            {
                lbl_Title.Content = "ESP";
                ESPO chosenESP = SelectedTemp.ChosenESP;
                lbl_NameTitle.Content = ("Energy Surplus: ");
                lbl_CreatedByTitle.Content = ("Start date: ");
                lbl_CreatedTitle.Content = ("End date: ");
                lbl_DeadlineTitle.Content = ("start time: ");
                lbl_PriorityTitle.Content = ("End time: ");
                lbl_NameFill.Content = chosenESP.EnergySurplus;
                lbl_CreatedByFill.Content = chosenESP.StartDate;
                lbl_CreatedFill.Content = chosenESP.EndDate;
                lbl_DeadlineFill.Content = chosenESP.StartTime;
                lbl_PriorityFill.Content = chosenESP.EndTime;
            }
            else if (subject == "Resources")
            {
                RO chosenR = SelectedTemp.ChosenR;
                lbl_Title.Content = "Resource";
                lbl_NameTitle.Content = ("Name: ");
                lbl_CreatedByTitle.Content = ("");
                lbl_CreatedTitle.Content = ("");
                lbl_DeadlineTitle.Content = ("");
                lbl_PriorityTitle.Content = ("");
                lbl_NameFill.Content = chosenR.Name;
            }
            else if (subject == "ResourceTypes")
            {
                RTO chosenRT = SelectedTemp.ChosenRT;
                lbl_Title.Content = "Resource type";
                lbl_NameTitle.Content = ("Name: ");
                lbl_CreatedByTitle.Content = ("");
                lbl_CreatedTitle.Content = ("");
                lbl_DeadlineTitle.Content = ("");
                lbl_PriorityTitle.Content = ("");
                lbl_NameFill.Content = chosenRT.Name;
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
                chosenJob.EditJob(SelectedTemp.ChosenJob.JobID, SelectedTemp.ChosenJob.CreatedUserID);
            }
            else if ((string)lbl_Title.Content == "User")
            {
                User.Editing = true;
                User chosenUser = new User();
                UserO selectedUser = SelectedTemp.ChosenUser;
                chosenUser.EditUserShow(selectedUser.UserID);
                User.EditUserID = selectedUser.UserID;
            }
            else if ((string)lbl_Title.Content == "Tarif")
            {
                Tarif.Edit(SelectedTemp.ChosenTarif.Cost, SelectedTemp.ChosenTarif.StartTime, SelectedTemp.ChosenTarif.EndTime);
            }
            else if ((string)lbl_Title.Content == "ESP")
            {
                //ESP.Edit();
            }
            else if ((string)lbl_Title.Content == "Resource")
            {
                Resource.EditResource(SelectedTemp.ChosenR.ResourceID);
            }
            else if ((string)lbl_Title.Content == "Resource type")
            {
                ResourceType.Edit(SelectedTemp.ChosenRT.Name);
            }
        }

        //By Klaus
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            switch ((string)lbl_Title.Content)
            {
                case "Job":
                    {
                        Job chosenJob = new Job();
                        chosenJob.DeleteJob(SelectedTemp.ChosenJob.JobID);
                    }
                    break;
                case "User":
                    {
                        User chosenUser = new User();
                        chosenUser.DeleteUser(SelectedTemp.ChosenUser.UserID);
                    }
                    break;
                case "Tarif":
                    {
                        Tarif chosenTarif = new Tarif();
                        //Hardcoded ID because they don't have IDs yet
                        chosenTarif.Delete(2);
                    }
                    break;
                case "ESP":
                    {
                        ESP chosenESP = new ESP();
                        //Hardcoded ID because they don't have IDs yet
                        chosenESP.Delete(2);
                    }
                    break;
                case "Resource":
                    {
                        Resource chosenResource = new Resource();
                        chosenResource.DeleteResource(SelectedTemp.ChosenR.ResourceID);
                    }
                    break;
                case "Resource type":
                    {
                        ResourceType chosenType = new ResourceType();
                        //Hardcoded ID because they don't have IDs yet
                        chosenType.Delete(2);
                    }
                    break;
                default:
                    break;
            }
            Show returnWindow = new Show();
            returnWindow.Show();
            this.Close();
        }
    }
}
