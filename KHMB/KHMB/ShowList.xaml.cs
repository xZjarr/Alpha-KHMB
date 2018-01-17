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
            string chosenO = chosenObject;
            InitializeComponent();
            lbl_Title.Content = chosenObject;
            if (chosenObject == "ResourceTypes")
            {
                ShowResourceType();
            }
            else if (chosenObject == "Resources")
            {
                ShowResource();
                //ShowResourceType();
            }
            else if (chosenObject == "Jobs")
            {
                ShowJob();
            }
            else if (chosenObject == "Users")
            {
                ShowUsers();
            }
            else if (chosenObject == "Tarif")
            {
                ShowTarif();
            }
            else if (chosenObject == "ESPs")
            {
                ShowESPs();
            }
        }

        private void listbox_Show_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)lbl_Title.Content == "Jobs")
            {
                JobO chosenJob = (JobO)listbox_Show.SelectedItem;
                SelectedTemp.ChosenJob = chosenJob;
                ShowDetails sdJ = new ShowDetails((string)lbl_Title.Content);
                sdJ.Show();
                this.Close();
            }
            else if ((string)lbl_Title.Content == "Users")
            {
                UserO chosenUser = (UserO)listbox_Show.SelectedItem;
                SelectedTemp.ChosenUser = chosenUser;
                ShowDetails sdU = new ShowDetails((string)lbl_Title.Content);
                sdU.Show();
                this.Close();
            }
            else if ((string)lbl_Title.Content == "Tarif")
            {
                TO chosenTarif = (TO)listbox_Show.SelectedItem;
                SelectedTemp.ChosenTarif = chosenTarif;
                ShowDetails sdT = new ShowDetails((string)lbl_Title.Content);
                sdT.Show();
                this.Close();
            }
            else if ((string)lbl_Title.Content == "ESPs")
            {
                ESPO chosenESP = (ESPO)listbox_Show.SelectedItem;
                SelectedTemp.ChosenESP = chosenESP;
                ShowDetails sdESP = new ShowDetails((string)lbl_Title.Content);
                sdESP.Show();
                this.Close();
            }
            else if ((string)lbl_Title.Content == "Resources")
            {
                RO chosenR = (RO)listbox_Show.SelectedItem;
                SelectedTemp.ChosenR = chosenR;
                ShowDetails sdR = new ShowDetails((string)lbl_Title.Content);
                sdR.Show();
                this.Close();
            }
            else if ((string)lbl_Title.Content == "ResourceTypes")
            {
                RTO chosenRT = (RTO)listbox_Show.SelectedItem;
                SelectedTemp.ChosenRT = chosenRT;
                ShowDetails sdRT = new ShowDetails((string)lbl_Title.Content);
                sdRT.Show();
                this.Close();
            }
        }
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Show returnWindow = new Show();
            returnWindow.Show();
            this.Close();
        }
        private void ShowResourceType()
        {
            List<RTO> rt = DB.SelectAllResourceTypes();
            listbox_Show.ItemsSource = rt;
        }
        private void ShowResource()
        {
            List<RO> r = DB.SelectAllResource();
            listbox_Show.ItemsSource = r;
        }
        private void ShowJob()
        {
            List<JobO> job = DB.SelectAllJobs();
            listbox_Show.ItemsSource = job;
        }
        private void ShowUsers()
        {
            List<UserO> users = DB.SelectAllUsers();
            listbox_Show.ItemsSource = users;
        }
        private void ShowTarif()
        {
            List<TO> tarif = DB.SelectAllTarifs();
            listbox_Show.ItemsSource = tarif;
        }
        private void ShowESPs()
        {
            List<ESPO> esps = DB.SelectAllESP();
            listbox_Show.ItemsSource = esps;
        }

    }
}
