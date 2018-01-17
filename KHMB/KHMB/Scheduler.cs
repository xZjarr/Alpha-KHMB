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
        //By BKP
        public static bool FindPlaceInQueue(JobO JobToBeScheduled)
        {
            Queue queue = GetJobs(JobToBeScheduled.ResourceID);
            JobToBeScheduled.ExeTime = CalculateBestSpot(queue, JobToBeScheduled);

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

        //By BKP
        private static DateTime CalculateBestSpot(Queue queue, JobO currentJob)
        {
            DateTime now = DateTime.Now;
            DateTime tempTime = new DateTime();
            List<ESPO> avaibleESPs = DB.GetESPs(now, currentJob.ExeTime);
            List<TO> avaibleTarifs = DB.SelectAllTarifs();

            for (int i=0; i<avaibleESPs.Count; i++)
            {
                ESPO currentESP = avaibleESPs[i];
                FindSpotInEsp(currentESP, currentJob, now);
            }

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

        private static void FindSpotInEsp(ESPO currentESP, JobO currentJob, DateTime now)
        {
            DateTime soonestStart = DateTime.Today + currentESP.StartTime;
            DateTime soonestEnd;
            if (currentESP.EndTime < currentESP.StartTime)
            {
                soonestEnd = DateTime.Today.AddDays(1) + currentESP.EndTime;
            }
            else
            {
                soonestEnd = DateTime.Today + currentESP.EndTime;
            }
            if (currentJob.ExeTime > soonestEnd)
            {
                int jobMinutes = currentJob.DurationHours;
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
