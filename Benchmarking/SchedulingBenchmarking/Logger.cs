using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SchedulingBenchmarking
{
    public class Logger
    {

        /// <summary>
        /// Method invoked by any state change in BenchMarkSystem. Publishes a running commentary 
        /// when any job is submitted, cancelled, run, failed or terminated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnStateChanged(object sender, StateChangedEventArgs e)
        {
            using (var dbContext = new Model1Container())
            {
                dbContext.Database.Connection.Open();
                DbLog logEntry = new DbLog();
                if(logEntry.timeStamp == null)
                    logEntry.timeStamp = DateTime.Now;

                logEntry.jobState = e.State.ToString();

                logEntry.user = e.Job.Owner.Name;

                logEntry.jobId = e.Job.jobId;

                dbContext.DbLogs.Add(logEntry);

                //dbContext.SaveChanges();

                Console.WriteLine("Job state {0}", e.State);
            } 
        }
    }
}