using System;
using GildedRose.Console.Models;

namespace GildedRose.Console.Rules
{
    class CheeseItemRule : BaseItemRuleTemplate
    {
        private const int MaximumQuality = 50;

        protected override void UpdateQuality(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            item.Quality++;

            if (item.Quality > MaximumQuality)
                item.Quality = MaximumQuality;
        }
    }
}