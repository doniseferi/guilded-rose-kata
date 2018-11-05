using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.NotExpired
{
    class BackstageSellIn5DaysOrLessHandler : QualityHandlerBase
    {
        private const int MinimumSellInCanHandle = 5;
        private const int IncrementationValue = 3;
        private readonly IQualityHandler _successor;

        public BackstageSellIn5DaysOrLessHandler(IQualityHandler successor)
        {
            _successor = successor;
        }

        protected override void DeferResponsibility(Item item) 
            => _successor.Handle(item);

        protected override bool CanHandle(Item item) 
            => item.SellIn <= MinimumSellInCanHandle;

        protected override void UpdateQuality(Item item)
        {
            item.Quality += IncrementationValue;

            if (item.Quality > MaximumQuality)
                base.SetToQualityToMaximum(item);
        }
    }
}