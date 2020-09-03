// -----------------------------------------------------------------------
//  <copyright file="AwaitMultipleTask.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Thread
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AwaitMultipleTask : BaseTaskTest
    {
        public override string Name => "Run async task with AWAIT";

        public override void Execute()
        {
            var run = Task.Run(async () => { await this.ExecuteAsync(); });
            Task.WaitAll(run);
        }

        private async Task ExecuteAsync()
        {
            var tasks = new List<Task<TimeSpan>>();
            for (var i = 0; i < this.tasksCount; i++)
            {
                var task = WaitSpecificTime(1000);
                tasks.Add(task);
            }

            foreach (var task in tasks)
            {
                var elapsed = await task;
            }
        }
    }
}