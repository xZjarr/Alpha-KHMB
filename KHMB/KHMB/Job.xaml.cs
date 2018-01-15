﻿using System;
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
    public partial class Job : Window
    {
        int ResourceID, CreatedUserID, JobID, Priority;
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
            List<int> resources = new List<int>();
            //Get a list from the database. For now, manually add an item.
            resources.Add(42);
            lbx_Resources.ItemsSource = resources;
        }

        private void btn_AddJob_Click(object sender, RoutedEventArgs e)
        {
            Deadline = Deadline.Date + DeadlineTimeConverter(cbx_Deadline).TimeOfDay;
            Priority = Convert.ToInt32(cbx_Priority.Text);
            CreateJob(ResourceID, CreatedUserID, Priority, Deadline);
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
            ResourceID = (int)lbx_Resources.SelectedItem;
        }


        public static void CreateJob(int Resource, int User, int Priority, DateTime Deadline)
        {
            //Send info to the scheduler, let it handle putting the job in the queue
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
