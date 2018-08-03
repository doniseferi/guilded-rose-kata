using System;
using System.Collections;
using System.Collections.Generic;
using GildedRose.Console.Factory;

namespace GildedRose.Console.Rules
{
    class Rules : IReadOnlyCollection<KeyValuePair<string, IItemRule>>
    {
        private readonly IDictionary<string, IItemRule> _items;
        private T Create<T>(params object[] parameters) => (T)Activator.CreateInstance(typeof(T), parameters);

        public Rules()
        {
            //todo this needs to move out of here and be passed in :-) refactor time
            var specialRulesHandlerFactory = new SpecialRulesHandlerFactory();

            _items = new Dictionary<string, IItemRule>
            {
                ["NULL_ITEM"] = Create<NullItemItemRule>(),
                ["Sulfuras"] = Create<SpecialItemItemRule>(),
                ["Brie"] = Create<CheeseItemRule>(),
                ["Backstage"] = Create<BackstagePassItemRule>(specialRulesHandlerFactory.CreateFor<BackstagePassItemRule>()),
                ["Conjured"] = Create<ConjuredItemRule>(specialRulesHandlerFactory.CreateFor<ConjuredItemRule>()),
                ["Default"] = Create<RegularItemItemRule>(specialRulesHandlerFactory.CreateFor<RegularItemItemRule>()),
            };
        }

        public IEnumerator<KeyValuePair<string, IItemRule>> GetEnumerator() 
            => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _items.Count;
    }
}