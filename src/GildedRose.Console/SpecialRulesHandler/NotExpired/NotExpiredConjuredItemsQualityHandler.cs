namespace GildedRose.Console.SpecialRulesHandler.NotExpired
{
    class NotExpiredConjuredItemsQualityHandler : NotExpiredRegularItemsQualityHandler
    {
        protected override int DecrementAmount => base.DecrementAmount * 2;

        public NotExpiredConjuredItemsQualityHandler(IQualityHandler successor) : base(successor)
        {
        }
    }
}