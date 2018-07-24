using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.Expired
{
    class ExpiredRegularItemsQualityHandler : QualityHandlerBase
    {
        private const int MaximumSellInCanHandle = 0;
        protected virtual int DecrementAmount => 2;

        protected override void DeferResponsibility(Item item)
        {
        }

        protected override void UpdateQuality(Item item)
        {
            item.Quality -= DecrementAmount;

            if (item.Quality < MinimumQuality)
                base.SetToQualityToMinimum(item);
        }

        protected override bool CanHandle(Item item) => item.SellIn <= MaximumSellInCanHandle;
    }
}