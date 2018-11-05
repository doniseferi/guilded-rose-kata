using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.NotExpired
{
    class BackstageSellIn11DaysOrMoreHandler : QualityHandlerBase
    {
        private const int MinimumSellInCanHandle = 11;
        
        protected override void DeferResponsibility(Item item)
        {
        }

        protected override bool CanHandle(Item item) 
            => item.SellIn >= MinimumSellInCanHandle;

        protected override void UpdateQuality(Item item)
        {
            item.Quality++;

            if (item.Quality > MaximumQuality)
                base.SetToQualityToMaximum(item);
        }
    }
}
