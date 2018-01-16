using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class Queue
    {
        public Queue(int resource)
        {
            DB.FillQueue(resource);
        }

        List<Job> jobsInQueue = new List<Job>();
        static void AddJobToQueue()
        {

        }
        static void GetCurrentlyStartingJob()
        {

        }
        static void CurrentlyAvailable()
        {

        }
        static void ReEvaluateJob()
        {

        }
        static void ReEvaluateQueue()
        {

        }
    }
}
