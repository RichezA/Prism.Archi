// -----------------------------------------------------------------------
//  <copyright file="FindInDictionaryWithDistinct.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Prism.Archi.PerformanceComparison.Models;

    public class FindInDictionaryWithDistinct : BaseFindInList
    {
        public override string Name => "Find items in list with distinct dictionary";

        public override void Execute()
        {
            var dictionary = new Dictionary<string, Foo>();

            foreach (var item in this.items)
            {
                if (dictionary.ContainsKey(item.Id))
                {
                    continue;
                }

                dictionary.Add(item.Id, item);
            }

            for (var i = 0; i < this.hits; i++)
            {
                var id = this.dice.Next(0, this.itemsCount).ToString();
                var found = dictionary[id];
            }
        }
    }
}