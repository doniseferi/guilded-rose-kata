using System;
using System.Collections.Generic;
using GildedRose.Console.Rules;
using GildedRose.Console.SpecialRulesHandler;
using GildedRose.Console.SpecialRulesHandler.Expired;
using GildedRose.Console.SpecialRulesHandler.NotExpired;

namespace GildedRose.Console.Factory
{
    class SpecialRulesHandlerFactory : ISpecialRulesHandlerFactory
    {
        //todo create a special rules class
        private readonly IDictionary<Type, IQualityHandler> _specialRules;

        public SpecialRulesHandlerFactory()
        {
            _specialRules = new Dictionary<Type, IQualityHandler>
            {
                [typeof(BackstagePassItemRule)] = CreateForBackstagePass(),
                [typeof(RegularItemItemRule)] = CreateForRegularItems(),
                [typeof(ConjuredItemRule)] = CreateForConjuredItems(),
            };
        }

        public IQualityHandler CreateFor<T>() where T : IItemRule
        {
            _specialRules.TryGetValue(typeof(T), out var handler);

            return handler ?? throw new KeyNotFoundException();
        }

        private static IQualityHandler CreateForBackstagePass()
            => new ExpiredBackstageEventQualityHandler(
                new BackstageSellIn5DaysOrLessHandler(
                        new BackstageSellIn10DaysOrLessHandler(
                            new BackstageSellIn11DaysOrMoreHandler())));

        private static IQualityHandler CreateForRegularItems()
            => new NotExpiredRegularItemsQualityHandler(
                new ExpiredRegularItemsQualityHandler());

        private IQualityHandler CreateForConjuredItems()
            => new NotExpiredConjuredItemsQualityHandler(
                new ExpiredConjuredItemsQualityHandler());
    }
}