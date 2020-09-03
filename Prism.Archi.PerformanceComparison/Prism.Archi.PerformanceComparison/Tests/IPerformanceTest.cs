// -----------------------------------------------------------------------
//  <copyright file="IPerformanceTest.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPerformanceTest
    {
        string Name { get; }

        void Execute();

        void Init(Dictionary<string, object> configuration);
    }
}