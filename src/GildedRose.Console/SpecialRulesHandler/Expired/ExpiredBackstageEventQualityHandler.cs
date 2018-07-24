using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.Expired
{
    class ExpiredBackstageEventQualityHandler : QualityHandlerBase
    {
        private const int MaximumSellInCanHandle = 0;
        private readonly IQualityHandler _successor;
        public ExpiredBackstageEventQualityHandler(IQualityHandler successor)
        {
            _successor = successor;
        }

        protected override void DeferResponsibility(Item item) => _successor.Handle(item);

        protected override void UpdateQuality(Item item) => base.SetToQualityToMinimum(item);

        protected override bool CanHandle(Item item) => item.SellIn <= MaximumSellInCanHandle;
    }
}
