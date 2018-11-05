using System;
using GildedRose.Console.Models;

namespace GildedRose.Console.Rules
{
    class SpecialItemItemRule : BaseItemRuleTemplate
    {
        protected override void UpdateQuality(Item item) => DoNothing();
 
        protected override void UpdateSellIn(Item item) => DoNothing();

        private Action DoNothing = () => { };
    }
}