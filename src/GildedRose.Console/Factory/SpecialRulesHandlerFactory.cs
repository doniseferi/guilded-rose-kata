using System;
using System.Collections.Generic;
using GildedRose.Console.Rules;
using GildedRose.Console.SpecialRulesHandler;
using GildedRose.Console.SpecialRulesHandler.Expired;
using GildedRose.Console.SpecialRulesHandler.NotExpired;

namespace GildedRose.Console.Factory
{
    //todo create factory to do rules
    //and the child factories will take care of what types
    //where this is a subtype
    class SpecialRulesHandlerFactory : ISpecialRulesHandlerFactory
    {
        //todo create a special rules class
        private readonly IDictionary<Type, IQualityHandler> _specialRules;

        public SpecialRulesHandlerFactory()
        {
            _specialRules = new Dictionary<Type, IQualityHandler>
            {
                [typeof(BackstagePassItemRule)] = CreateBackstagePassHandler(),
                [typeof(RegularItemItemRule)] = CreateRegularItemsHandler(),
                [typeof(ConjuredItemRule)] = CreateConjuredItemsHandler(),
            };
        }

        public IQualityHandler CreateFor<T>() where T : IItemRule
        {
            _specialRules.TryGetValue(typeof(T), out var handler);

            return handler ?? throw new KeyNotFoundException();
        }

        private static IQualityHandler CreateBackstagePassHandler()
            => new ExpiredBackstageEventQualityHandler(
                new BackstageSellIn5DaysOrLessHandler(
                        new BackstageSellIn10DaysOrLessHandler(
                            new BackstageSellIn11DaysOrMoreHandler())));

        private static IQualityHandler CreateRegularItemsHandler()
            => new NotExpiredRegularItemsQualityHandler(
                new ExpiredRegularItemsQualityHandler());

        private IQualityHandler CreateConjuredItemsHandler()
            => new NotExpiredConjuredItemsQualityHandler(
                new ExpiredConjuredItemsQualityHandler());
    }
}