using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    static class Scheduler
    {
        static Random rnd = new Random();
        //By Klaus
        public static bool FindPlaceInQueue(JobO JobToBeScheduled)
        {
            Queue queue = GetJobs(JobToBeScheduled.ResourceID);
            JobToBeScheduled.ExeTime = CalculateBestSpot(queue);

            JobToBeScheduled.JobName = GenerateJobName(JobToBeScheduled);
            bool isSucces = DB.InsertJob(JobToBeScheduled);
            return isSucces;
        }

        private static string GenerateJobName(JobO jobToBeScheduled)
        {
            UserO jobCreatedBy = DB.GetUser(jobToBeScheduled.CreatedUserID);
            RO jobResource = DB.GetResource(jobToBeScheduled.ResourceID);
            string resName;
            if ( jobResource.Name.Length < 8)
            {
                resName = jobResource.Name;
            }
            else
            {
                resName = jobResource.Name.Substring(0,8);
            }
            string jobname = jobCreatedBy.FirstName + resName + jobToBeScheduled.ExeTime.ToShortDateString() + rnd.Next(1000,9999).ToString();
            return jobname;
        }

        //By Klaus
        private static DateTime CalculateBestSpot(Queue queue)
        {
            //Is supposed to calculate the best spot in queue. For now, just give it any spot available
            DateTime tempTime = new DateTime();
            int hour = 00;
            tempTime = Convert.ToDateTime($"{hour}:00:00");
            int index = queue.jobsInQueue.FindIndex(item => item.ExeTime == tempTime);
            if (index < 0)
            {
                return tempTime;    
            }
            else
            {
                hour++;
                tempTime = Convert.ToDateTime($"{hour}:00:00");
                return tempTime;
            }
        }

        // This will only be relevant in the case of us being able to select a resource-type instead of a specific resource when creating a job
        /*public static void GetResources(int resourceTypeId)
        {
            List<RO> resources = DB.SelectAllResource(resourceTypeId);


        }*/

        //Klaus
        public static Queue GetJobs(int  resource)
        {
            //Make a queue and fill it with jobs from database with the corresponding resource
            Queue queue = new Queue(resource);
            return queue;
        }
        public static void GetESPs()
        {

        }
        public static void GetTarif()
        {

        }
    }
}
