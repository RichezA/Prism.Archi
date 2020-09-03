// -----------------------------------------------------------------------
//  <copyright file="FindInList.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Collections
{
    using System;
    using System.Linq;

    public class FindInList : BaseFindInList
    {
        public override string Name => "Find items in list with where";

        public override void Execute()
        {
            for (var i = 0; i < this.hits; i++)
            {
                var id = this.dice.Next(0, this.itemsCount).ToString();
                var found = this.items.First(x => x.Id == id);
            }
        }
    }
}