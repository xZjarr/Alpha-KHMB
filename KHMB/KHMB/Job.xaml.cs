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
    //Class made by Klaus
    public partial class Job : Window
    {
        public int CreatedUserID, JobID, Priority;
        public static int EditingJobID,EditingJobUserID;
        RO ResourceID;
        string JobName;
        bool Succes;
        DateTime Deadline;
        DateTime Created;
        public static bool Editing=false;

        public Job()
        {
            InitializeComponent();
            FillResourceList();
            Created = DateTime.Today;
            if (Editing == true)
            {
                btn_AddJob.Content = "Save Changes";
            }
        }

        private void FillResourceList()
        {
            List<RO> resources = new List<RO>();
            //Get a list from the database.
            resources = DB.SelectAllResource();
            lbx_Resources.ItemsSource = resources;
        }

        private void btn_AddJob_Click(object sender, RoutedEventArgs e)
        {
            if (Editing == false)
            {
                Deadline = Deadline.Date + DeadlineTimeConverter(cbx_Deadline).TimeOfDay;
                Priority = Convert.ToInt32(cbx_Priority.Text);
                CreateJob(ResourceID.ResourceID, CreatedUserID, Priority, Deadline);
                this.Close();
            }
            else if (Editing == true)
            {
                Deadline = Deadline.Date + DeadlineTimeConverter(cbx_Deadline).TimeOfDay;
                Priority = Convert.ToInt32(cbx_Priority.Text);
                EditJob(ResourceID.ResourceID, Priority, Deadline);
                this.Close();
            }
        }

        private DateTime DeadlineTimeConverter(ComboBox cbx_time)
        {
            string temp = $"{cbx_time.Text}:00:00";
            DateTime time = Convert.ToDateTime(temp);
            return time;
        }


        private void dtpick_Deadline_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Deadline = Convert.ToDateTime(dtpick_Deadline.Text);
            cbx_Deadline.IsEnabled = true;
        }

        private void lbx_Resources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResourceID = (RO)lbx_Resources.SelectedItem;
        }


        public static void CreateJob(int Resource, int User, int Priority, DateTime Deadline)
        {
            JobO jobToBeScheduled = new JobO();
            jobToBeScheduled.ResourceID = Resource;
            jobToBeScheduled.CreatedUserID = User;
            jobToBeScheduled.Priority = Priority;
            jobToBeScheduled.Deadline = Deadline;
            jobToBeScheduled.CreatedUserID = CurrentUser.ID;
            jobToBeScheduled.Created = DateTime.Now;
            jobToBeScheduled.DurationHours = 4;
            bool isSucces = Scheduler.FindPlaceInQueue(jobToBeScheduled);
            if (isSucces)
            {
                MessageBox.Show("Job succesfully added to Queue");
            }
            else
            {
                MessageBox.Show("Job could not be added to queue");
            }
        }
        public void EditJobShow(int JobID, int UserID)
        {
            Job nw = new Job();
                nw.Show();
        }
        public void EditJob(int PrioEdit, DateTime DeadLineEdit)
        {
            
        }

        public void DeleteJob(int JobID)
        {
            DB.Delete("Job",SelectedTemp.ChosenJob.JobID);
        }
    }
}
