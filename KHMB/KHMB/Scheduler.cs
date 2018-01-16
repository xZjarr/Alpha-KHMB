using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    static class Scheduler
    {
        public static void FindPlaceInQueue(Job JobToBeScheduled)
        {
            Queue queue = GetJobs(JobToBeScheduled.ResourceID);
            queue.jobsInQueue.Add(JobToBeScheduled);
        }
        public static void GetResources()
        {

        }
        public static Queue GetJobs(int  resource)
        {
            //Make a queue and fill it with jobs from database with the corresponding resource(Replace new Queue() with a databse command)
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
