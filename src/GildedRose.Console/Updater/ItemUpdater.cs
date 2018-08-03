using System;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.Models;

namespace GildedRose.Console.Updater
{
    class ItemUpdater : IItemUpdater
    {
        private readonly IRuleFactory _ruleFactory;

        public ItemUpdater(IRuleFactory ruleFactory)
        {
            _ruleFactory = ruleFactory;
        }

        public void Update(Items items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            items.ToList()
                .ForEach(item 
                    =>_ruleFactory
                        .GetRule(item)
                        .Update(item));
        }
    }
}