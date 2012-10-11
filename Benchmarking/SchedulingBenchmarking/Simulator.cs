using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulingBenchmarking
{
    class Simulator: Task
    {
        private Scheduler scheduler;

        public Simulator(Scheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        /// <summary>
        /// Method to simply create a job and return it
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="cpus"></param>
        /// <param name="runtime"></param>
        /// <returns></returns>
        private Job createJob(Owner owner, int cpus, int runtime)
        {
            Job job = new Job(
                (string[] arg) => { 
                    foreach (string s in arg) { 
                        Console.Out.WriteLine(s); 
                    } Thread.Sleep(runtime); 
                    return ""; }, 
                owner, 
                cpus, // Cpus needed 
                runtime); // Runtime (in milliseconds)
            
            return job;
        }

        /// <summary>
        /// Function to get a random amount of owners in an array
        /// </summary>
        /// <returns></returns>
        private Owner[] getRandomOwners(){
            Random random = new Random();
            
            int amountOfOwners = random.Next(5, 11); // Make somewhere between 5 and 10
            
            Owner[] owners = new Owner[amountOfOwners];
            for (int i = 0; i < amountOfOwners; i++)
            {
                owners[i] = new Owner("user " + i);
            }
            return owners;
        }

        /// <summary>
        /// Method to run a simulation till the end of time
        /// </summary>
        public void runForEver()
        {
            while (true)
            {
                    
            }
        }

    }
}
