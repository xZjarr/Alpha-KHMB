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
        RO ResourceID;
        string JobName;
        bool Succes;
        DateTime Deadline;
        DateTime Created;

        public Job()
        {
            InitializeComponent();
            FillResourceList();
            Created = DateTime.Today;
        }

        private void FillResourceList()
        {
            List<RO> resources = new List<RO>();
            //Get a list from the database. For now, manually add an item.
            //Resource temp = new Resource();
            resources = DB.SelectAllResource();
            lbx_Resources.ItemsSource = resources;
        }

        private void btn_AddJob_Click(object sender, RoutedEventArgs e)
        {
            Deadline = Deadline.Date + DeadlineTimeConverter(cbx_Deadline).TimeOfDay;
            Priority = Convert.ToInt32(cbx_Priority.Text);
            CreateJob(ResourceID.ResourceID, CreatedUserID, Priority, Deadline);
            this.Close();
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
            //Hardcoded user ID fix when UserLogin is created
            jobToBeScheduled.CreatedUserID = 3;
            jobToBeScheduled.Created = DateTime.Now;
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

        public void EditJob(int JobID, string User)
        {

        }

        public bool DeleteJob(int JobID, string User)
        {
            
            return Succes;
        }
    }
}
