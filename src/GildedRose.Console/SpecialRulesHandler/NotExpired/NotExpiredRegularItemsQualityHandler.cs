using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.NotExpired
{
    class NotExpiredRegularItemsQualityHandler : QualityHandlerBase
    {
        private const int MinimumSellInCanHandle = 1;
        protected virtual int DecrementAmount => 1;
        private readonly IQualityHandler _successor;

        public NotExpiredRegularItemsQualityHandler(IQualityHandler successor)
        {
            _successor = successor;
        }

        protected override void DeferResponsibility(Item item) => _successor.Handle(item);

        protected override void UpdateQuality(Item item)
        {
            item.Quality-= DecrementAmount;

            if (item.Quality < MinimumQuality)
                base.SetToQualityToMinimum(item);
        }


        protected override bool CanHandle(Item item) => item.SellIn >= MinimumSellInCanHandle;
    }
}