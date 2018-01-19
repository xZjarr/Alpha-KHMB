using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHMB_ServerSide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer_ExecuteJobs_Tick(object sender, EventArgs e)
        {
            List<JobO> jobsToExecute = DB_Server.SelectJobsToBeExecuted();
            foreach(JobO executingJob in jobsToExecute)
            {
                RO jobResource = DB_Server.GetResource(executingJob.ResourceID);
                ExecuteDummyScript(jobResource.ExecuteScript, executingJob);
            }

        }

        private void ExecuteDummyScript(string ResourceScript, JobO jobToExecute)
        {
            lbl_output.Text = lbl_output.Text + jobToExecute.JobName + " is executed\n";
        }

    }
}
