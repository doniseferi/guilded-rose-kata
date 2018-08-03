using System;
using GildedRose.Console.Models;
using GildedRose.Console.SpecialRulesHandler;

namespace GildedRose.Console.Rules
{
    class ConjuredItemRule : BaseItemRuleTemplate
    {
        private readonly IQualityHandler _qualityHandler;

        public ConjuredItemRule(IQualityHandler qualityHandler)
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
