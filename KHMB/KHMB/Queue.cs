﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class Queue
    {
        public List<JobO> jobsInQueue = new List<JobO>();

        public Queue(int resource)
        {
            jobsInQueue = DB.FillQueue(resource);
        }

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
