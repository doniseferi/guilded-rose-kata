using System;
using GildedRose.Console.Models;
using GildedRose.Console.SpecialRulesHandler;

namespace GildedRose.Console.Rules
{
    class BackstagePassItemRule : BaseItemRuleTemplate
    {
        private readonly IQualityHandler _qualityHandler;

        public BackstagePassItemRule(IQualityHandler qualityHandler)
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