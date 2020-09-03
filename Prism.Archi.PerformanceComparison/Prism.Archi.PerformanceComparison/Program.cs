// -----------------------------------------------------------------------
//  <copyright file="Program.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Prism.Archi.PerformanceComparison.Tests.Collections;
    using Prism.Archi.PerformanceComparison.Tests.Thread;

    internal class Program
    {
        public static void Main(string[] args)
        {
            // CompareFindInCollections();
            CompareAwaitWhenAll();
        }

        private static void CompareAwaitWhenAll()
        {
            var comparison = new PerformanceComparer(10, new Dictionary<string, object> { { "tasksCount", 1000 } });
            comparison.PerformanceTests.Add(new AwaitMultipleTask());
            comparison.PerformanceTests.Add(new WaitAllMultipleTasks());
            comparison.Run();
        }

        private static void CompareFindInCollections()
        {
            var comparison = new PerformanceComparer(100, new Dictionary<string, object> { { "hits", 100 }, { "itemsCount", 1000 } });
            comparison.PerformanceTests.Add(new FindInList());
            comparison.PerformanceTests.Add(new FindInDictionary());
            comparison.PerformanceTests.Add(new FindInDictionaryWithDistinct());
            comparison.Run();
        }
    }
}