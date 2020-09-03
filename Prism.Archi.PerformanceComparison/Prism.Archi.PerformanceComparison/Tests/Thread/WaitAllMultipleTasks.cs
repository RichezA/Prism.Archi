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

    public class WaitAllMultipleTasks : BaseTaskTest
    {
        public override string Name => "Run async task with WAITALL";

        public override void Execute()
        {
            var run = Task.Run(() => { this.ExecuteAsync(); });
            Task.WaitAll(run);
        }

        private void ExecuteAsync()
        {
            var tasks = new List<Task<TimeSpan>>();
            for (var i = 0; i < this.tasksCount; i++)
            {
                var task = WaitSpecificTime(1000);
                tasks.Add(task);
            }

            var taskArray = tasks.ToArray();

            Task.WaitAll(taskArray);

            foreach (var task in taskArray)
            {
                var elapsed = task.Result;
            }
        }
    }
}