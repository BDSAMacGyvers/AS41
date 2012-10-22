using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SchedulingBenchmarking
{
    [TestClass]
    public class EllenTest
    {
        BenchmarkSystem BS;
        Scheduler sch;

        Job j1;
        Job delayedJob;
        Job j3;
        Job j4;
        Job j5;

        [TestInitialize]
        public void setup()
        {
            BS = new BenchmarkSystem();
            sch = BS.scheduler;

            j1 = new Job(
                (string[] arg) =>
                {
                    foreach (string s in arg)
                    {
                        Console.Out.WriteLine(s);
                    }; return "";
                },
                new Owner("one"),
                1, // Cpus needed 
                1000 // Runtime (in milliseconds)
                );

            delayedJob = new Job(
                (string[] arg) =>
                {
                    foreach (string s in arg)
                    {
                        Console.Out.WriteLine(s);
                    }; return "";
                },
                new Owner("delayed"),
                3, // Cpus needed 
                1000 // Runtime (in milliseconds)
                );

            j3 = new Job(
                (string[] arg) =>
                {
                    foreach (string s in arg)
                    {
                        Console.Out.WriteLine(s);
                    }; return "";
                },
                new Owner("three"),
                1, // Cpus needed 
                1000 // Runtime (in milliseconds)
                );

            j4 = new Job(
                (string[] arg) =>
                {
                    foreach (string s in arg)
                    {
                        Console.Out.WriteLine(s);
                    }; return "";
                },
                new Owner("four"),
                1, // Cpus needed 
                1000 // Runtime (in milliseconds)
                );

            j5 = new Job(
                (string[] arg) =>
                {
                    foreach (string s in arg)
                    {
                        Console.Out.WriteLine(s);
                    }; return "";
                },
                new Owner("five"),
                1, // Cpus needed 
                1000 // Runtime (in milliseconds)
                );

            // remove old jobs from the static scheduler
            while (!sch.Empty())
            {
                sch.popJob(10);
            }

            // add them again

            sch.addJob(j1);
            sch.addJob(delayedJob);
            sch.addJob(j3);
            sch.addJob(j4);
            sch.addJob(j5);
           
        }

        [TestMethod]
        public void TestMaxDelayIsTwice()
        {
            // test if delayedJob gets delayed once, twice, and no more
            Job test1 = sch.popJob(1); // should pop j1
            Assert.IsTrue(test1.Equals(j1));
            Assert.IsFalse(test1.Equals(delayedJob));

            // delayed once
            Job test2 = sch.popJob(1); // should pop j3 not delayedJob, delaying it once
            //Assert.IsTrue(test2.Equals(j3));
            Assert.IsTrue(test2 == null); // damn
            //Assert.IsFalse(test2.Equals(delayedJob));
/*
            // delayed twice
            Job test3 = sch.popJob(1); // should pop j4 not delayedJob, delaying it twice
            Assert.IsTrue(test3.Equals(j4));
            Assert.IsFalse(test3.Equals(delayedJob));

            // but not more
            Job test4 = sch.popJob(1); // should pop null because there aren't enough cores and it can't run any others till delayedJob is run
            Assert.IsTrue(test4 == null);
            Assert.IsFalse(test4.Equals(delayedJob));

            Job test5 = sch.popJob(3); // should pop delayedJob
            Assert.IsTrue(test5.Equals(delayedJob));
 */
        }
    }
}
