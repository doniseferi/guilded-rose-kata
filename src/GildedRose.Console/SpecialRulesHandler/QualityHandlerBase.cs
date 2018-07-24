using System;
using GildedRose.Console.Models;

namespace GildedRose.Console.SpecialRulesHandler
{
    public abstract class QualityHandlerBase : IQualityHandler
    {
        protected const int MaximumQuality = 50;
        protected const int MinimumQuality = 0;

        public void Handle(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (CanHandle(item))
                UpdateQuality(item);
            else
                DeferResponsibility(item);
        }

        protected abstract void DeferResponsibility(Item item);
        protected abstract void UpdateQuality(Item item);
        protected abstract bool CanHandle(Item item);
        protected void SetToQualityToMaximum(Item item) => item.Quality = MaximumQuality;
        protected void SetToQualityToMinimum(Item item) => item.Quality = MinimumQuality;
    }
}
