// -----------------------------------------------------------------------
//  <copyright file="FindInDictionary.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Collections
{
    using System;
    using System.Linq;

    public class FindInDictionary : BaseFindInList
    {
        public override string Name => "Find items in list with dictionary";

        public override void Execute()
        {
            var dictionary = this.items.ToDictionary(x => x.Id);

            for (var i = 0; i < this.hits; i++)
            {
                var id = this.dice.Next(0, this.itemsCount).ToString();
                var success = dictionary.TryGetValue(id, out var found);
            }
        }
    }
}