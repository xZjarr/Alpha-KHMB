﻿using System;
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
            DateTime? ESPtempTime = null;
            DateTime? TarifTempTime = null;
            DateTime tempTime = new DateTime();
            List<ESPO> avaibleESPs = DB.GetESPs(now, currentJob.Deadline);
            List<TO> avaibleTarifs = DB.SelectAllTarifs(true);

            for (int i=0; i<avaibleESPs.Count; i++)
            {
                ESPO currentESP = avaibleESPs[i];
                ESPtempTime = FindSpotInEsp(currentESP, currentJob, now);
                if (ESPtempTime != null)
                {
                    tempTime = (DateTime)ESPtempTime;
                    i = avaibleESPs.Count;
                }
            }
            if (ESPtempTime == null)
            {
                for (int t = 0; t < avaibleTarifs.Count; t++)
                {
                    TO currentTarif = avaibleTarifs[t];
                    TarifTempTime = FindSpotInTarif(currentTarif, currentJob, now);
                    if (TarifTempTime != null)
                    {
                        tempTime = (DateTime)TarifTempTime;
                        t = avaibleTarifs.Count;
                    }
                }
            }
            

            return tempTime;

            /*int hour = 00;
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
            }*/
        }

        private static DateTime? FindSpotInTarif(TO currentTarif, JobO currentJob, DateTime now)
        {
            DateTime tarifStart = DateTime.Today + currentTarif.StartTime;
            DateTime? startDateTime = null;
            DateTime tarifEnd = DateTime.Today + currentTarif.EndTime, possibleStart = now, possibleEnd, soonestStart = now;
            bool spotFound;
            bool needToResetToTarifStart = true;

            if (currentTarif.EndTime < currentTarif.StartTime)
            {
                tarifEnd = DateTime.Today.AddDays(1) + currentTarif.EndTime;
            }
            else
            {
                tarifEnd = DateTime.Today + currentTarif.EndTime;
            }

            if(tarifStart < now && tarifEnd < now)
            {
                tarifEnd = tarifEnd.AddDays(1);
                tarifStart = tarifStart.AddDays(1);

            }

            if (tarifStart > possibleStart)
            {
                soonestStart = tarifStart;
                needToResetToTarifStart = false;
            }
            DateTime testDeadline = currentJob.Deadline.AddDays(1);
            while (testDeadline >= tarifEnd) {
                possibleStart = soonestStart;

                int jobHours = currentJob.DurationHours;
                possibleEnd = possibleStart.AddHours(jobHours);
                while (possibleEnd <= tarifEnd && currentJob.Deadline>=possibleEnd)
                {
                    spotFound = DB.IsResourceAvailable(possibleStart, possibleEnd, currentJob);
                    if (spotFound == true)
                    {
                        startDateTime = possibleStart;
                        return startDateTime;
                    }
                    possibleStart = possibleStart.AddHours(1);
                    possibleEnd = possibleStart.AddHours(jobHours);
                }
                if (needToResetToTarifStart)
                {
                    soonestStart = tarifStart.AddDays(1);
                }
                else
                {
                    soonestStart = soonestStart.AddDays(1);
                    needToResetToTarifStart = false;
                }
                
                tarifEnd = tarifEnd.AddDays(1);
            }

            return startDateTime;
        }

        private static DateTime? FindSpotInEsp(ESPO currentESP, JobO currentJob, DateTime now)
        {
            DateTime soonestStart = DateTime.Today + currentESP.StartTime;
            DateTime ESPEnd, possibleStart, possibleEnd, ESPFinalEnd = currentESP.EndDate+currentESP.EndTime;
            DateTime? startDateTime = soonestStart;
            bool spotFound;

           
            if (currentESP.EndTime < currentESP.StartTime)
            {
                ESPEnd = DateTime.Today.AddDays(1) + currentESP.EndTime;
            }
            else
            {
                ESPEnd = DateTime.Today + currentESP.EndTime;
            }
            if (soonestStart < now && ESPEnd < now)
            {
                soonestStart = soonestStart.AddDays(1);
                ESPEnd = ESPEnd.AddDays(1);
            }

            while (soonestStart < currentESP.EndDate) {


                if (currentJob.Deadline > ESPEnd)
                {
                    possibleStart = soonestStart;

                    int jobHours = currentJob.DurationHours;
                    possibleEnd = possibleStart.AddHours(jobHours);
                    while (possibleEnd <= ESPEnd) {
                        spotFound = DB.IsResourceAvailable(possibleStart, possibleEnd, currentJob);
                        if (spotFound == true)
                        {
                            startDateTime = possibleStart;
                            return startDateTime;
                        }
                        possibleStart = possibleStart.AddHours(1);
                        possibleEnd = possibleStart.AddHours(jobHours);
                    }
                    startDateTime = null;
                }
                else
                {
                    startDateTime = null;
                }
                soonestStart = soonestStart.AddDays(1);
                ESPEnd = ESPEnd.AddDays(1);
            }

            return startDateTime;
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
