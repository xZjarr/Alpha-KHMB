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
            DateTime Deadline = Convert.ToDateTime(dtpick_Deadline.Text);
            DateTime Created = DateTime.Today;
            InitializeComponent();
        }
        public static void CreateJob(int JobID, String User, int Priority)
        {
            
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
