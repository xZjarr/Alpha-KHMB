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
    public partial class Job : Window
    {
        int ResourceID, CreatedUserID, JobID, Priority;
        string JobName;
        bool Succes;
        public Job()
        {
            InitializeComponent();
            DateTime Created = DateTime.Today;
        }

        private void btn_AddJob_Click(object sender, RoutedEventArgs e)
        {
            CreateJob(JobID, "Userguy", Priority, dtpick_Deadline);
        }

        public static void CreateJob(int JobID, String User, int Priority, DatePicker dtpick_Deadline)
        {
             DateTime Deadline = Convert.ToDateTime(dtpick_Deadline.Text);           
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
