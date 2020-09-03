// -----------------------------------------------------------------------
//  <copyright file="BaseTaskTest.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Thread
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class BaseTaskTest : IPerformanceTest
    {
        private static readonly Random Dice = new Random();
        protected int tasksCount;

        public abstract string Name { get; }

        public abstract void Execute();

        /// <inheritdoc />
        public void Init(Dictionary<string, object> configuration)
        {
            this.tasksCount = (int)configuration["tasksCount"];
        }

        protected static async Task<TimeSpan> WaitSpecificTime(int waitTime)
        {
            await Task.Delay(waitTime);
            return TimeSpan.FromMilliseconds(waitTime);
        }

        protected static async Task<TimeSpan> WaitRandomTime()
        {
            var waitTime = Dice.Next(1000, 2000);
            await Task.Delay(waitTime);
            return TimeSpan.FromMilliseconds(waitTime);
        }
    }
}