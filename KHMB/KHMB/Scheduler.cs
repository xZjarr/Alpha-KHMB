using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    static class Scheduler
    {
        //By Klaus
        public static bool FindPlaceInQueue(JobO JobToBeScheduled)
        {
            Queue queue = GetJobs(JobToBeScheduled.ResourceID);
            JobToBeScheduled.ExeTime = CalculateBestSpot(queue);
            //Generate name. HardCoded for now
            JobToBeScheduled.JobName = "TestName";
            bool isSucces = DB.InsertJob(JobToBeScheduled);
            return isSucces;
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

        public static void GetResources()
        {

        }

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
