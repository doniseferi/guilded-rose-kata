using System;
using GildedRose.Console.Models;
using GildedRose.Console.SpecialRulesHandler;

namespace GildedRose.Console.Rules
{
    class RegularItemItemRule : BaseItemRuleTemplate
    {
        private readonly IQualityHandler _qualityHandler;

        public RegularItemItemRule(IQualityHandler qualityHandler)
        {
            _qualityHandler = qualityHandler;
        }

        protected override void UpdateQuality(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _qualityHandler.Handle(item);
        }
    }
}
