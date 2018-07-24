using System;
using GildedRose.Console.Models;

namespace GildedRose.Console.Rules
{
    abstract class BaseItemRuleTemplate : IItemRule
    {
        public void Update(Item item)
        {
            if (item == null)
                throw new ArgumentNullException();

            UpdateQuality(item);
            UpdateSellIn(item);
        }

        protected virtual void UpdateSellIn(Item item) => item.SellIn--;
        protected abstract void UpdateQuality(Item item);
    }
}