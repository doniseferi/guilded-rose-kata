using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.NotExpired
{
    public class BackstageSellIn10DaysOrLessHandler : QualityHandlerBase
    {
        private const int IncrementationValue = 2;
        private const int MaximumSellInCanHandle = 10;
        private const int MinimumSellInCanHandle = 6;
        private readonly IQualityHandler _successor;

        public BackstageSellIn10DaysOrLessHandler(IQualityHandler successor)
        {
            _successor = successor;
        }
        
        protected override void DeferResponsibility(Item item) 
            => _successor.Handle(item);

        protected override void UpdateQuality(Item item)
        {
            item.Quality += IncrementationValue;

            if (item.Quality > MaximumQuality)
                base.SetToQualityToMaximum(item);
        }

        protected override bool CanHandle(Item item) 
            => item.SellIn <= MaximumSellInCanHandle && 
               item.SellIn >= MinimumSellInCanHandle;
    }
}