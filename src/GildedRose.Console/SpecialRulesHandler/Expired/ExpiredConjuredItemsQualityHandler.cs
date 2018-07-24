using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler.Expired
{
    class ExpiredConjuredItemsQualityHandler : ExpiredRegularItemsQualityHandler
    {
        protected override int DecrementAmount => base.DecrementAmount * 2;

        protected override void DeferResponsibility(Item item)
        {
        }
    }
}