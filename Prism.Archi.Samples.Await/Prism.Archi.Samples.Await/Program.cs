// <copyright file="Program.cs" company="Prism">
// Copyright (c) Prism. All rights reserved.
// </copyright>

namespace Prism.Archi.Samples.Await
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    internal class Program
    {
        private static readonly Random Dice = new Random();

        public static async Task Main(string[] args)
        {
            await ThisDoesNotWorkInParallel();
            await ThisWorkInParallel();
            await ThisWorkInParallelAndKeepExceptions();
        }

        public static async Task<TimeSpan> WaitRandomTime()
        {
            var waitTime = Dice.Next(1000, 2000);
            await Task.Delay(waitTime);
            return TimeSpan.FromMilliseconds(waitTime);
        }

        private static void Log(Stopwatch timer, string content)
        {
            Console.WriteLine($"{timer.Elapsed} - {content}");
        }

        private static async Task ThisDoesNotWorkInParallel()
        {
            Console.WriteLine("===> This code does NOT work in //");
            var timer = new Stopwatch();
            timer.Start();

            var response1 = await WaitRandomTime();
            Log(timer, "Call 1 started");
            var response2 = await WaitRandomTime();
            Log(timer, "Call 2 started");
            var response3 = await WaitRandomTime();
            Log(timer, "Call 3 started");
            var response4 = await WaitRandomTime();
            Log(timer, "Call 4 started");
            var response5 = await WaitRandomTime();
            Log(timer, "Call 5 started");

            var elapsed1 = response1.TotalMilliseconds;
            Log(timer, $"Call 1 done : {elapsed1}");
            var elapsed2 = response2.TotalMilliseconds;
            Log(timer, $"Call 2 done : {elapsed2}");
            var elapsed3 = response3.TotalMilliseconds;
            Log(timer, $"Call 3 done : {elapsed3}");
            var elapsed4 = response4.TotalMilliseconds;
            Log(timer, $"Call 4 done : {elapsed4}");
            var elapsed5 = response5.TotalMilliseconds;
            Log(timer, $"Call 5 done : {elapsed5}");
        }

        private static async Task ThisWorkInParallel()
        {
            Console.WriteLine("===> This code does work //");
            var timer = new Stopwatch();
            timer.Start();

            var task1 = WaitRandomTime();
            Log(timer, "Call 1 started");
            var task2 = WaitRandomTime();
            Log(timer, "Call 2 started");
            var task3 = WaitRandomTime();
            Log(timer, "Call 3 started");
            var task4 = WaitRandomTime();
            Log(timer, "Call 4 started");
            var task5 = WaitRandomTime();
            Log(timer, "Call 5 started");

            var elapsed1 = await task1;
            Log(timer, $"Call 1 done : {elapsed1.TotalMilliseconds}");
            var elapsed2 = await task2;
            Log(timer, $"Call 2 done : {elapsed2.TotalMilliseconds}");
            var elapsed3 = await task3;
            Log(timer, $"Call 3 done : {elapsed3.TotalMilliseconds}");
            var elapsed4 = await task4;
            Log(timer, $"Call 4 done : {elapsed4.TotalMilliseconds}");
            var elapsed5 = await task5;
            Log(timer, $"Call 5 done : {elapsed5.TotalMilliseconds}");
        }

        private static async Task ThisWorkInParallelAndKeepExceptions()
        {
            Console.WriteLine("===> This code does work // and keep all exceptions (optimal)");
            var timer = new Stopwatch();
            timer.Start();

            var task1 = WaitRandomTime();
            Log(timer, "Call 1 started");
            var task2 = WaitRandomTime();
            Log(timer, "Call 2 started");
            var task3 = WaitRandomTime();
            Log(timer, "Call 3 started");
            var task4 = WaitRandomTime();
            Log(timer, "Call 4 started");
            var task5 = WaitRandomTime();
            Log(timer, "Call 5 started");

            var elapseds = await Task.WhenAll(task1, task2, task3, task4, task5);
            for (int i = 0, c = elapseds.Length; i < c; i++)
            {
                Log(timer, $"Call {i + 1} done : {elapseds[i].TotalMilliseconds}");
            }
        }
    }
}