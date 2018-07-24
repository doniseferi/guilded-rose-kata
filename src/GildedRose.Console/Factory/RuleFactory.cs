using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Models;
using GildedRose.Console.Rules;

namespace GildedRose.Console.Factory
{
    class RuleFactory : IRuleFactory
    {
        private readonly Dictionary<string, IItemRule> _rules;

        public RuleFactory(ISpecialRulesHandlerFactory specialRulesHandlerFactory)
        {
            _rules = new Dictionary<string, IItemRule>
            {
                ["NULL_ITEM"] = Create<NullItemItemRule>(),
                ["Sulfuras"] = Create<SpecialItemItemRule>(),
                ["Brie"] = Create<CheeseItemRule>(),
                ["Backstage"] = Create<BackstagePassItemRule>(specialRulesHandlerFactory.CreateFor<BackstagePassItemRule>()),
                ["Conjured"] = Create<ConjuredItemRule>(specialRulesHandlerFactory.CreateFor<ConjuredItemRule>()),
                ["Default"] = Create<RegularItemItemRule>(specialRulesHandlerFactory.CreateFor<RegularItemItemRule>()),
            };
        }
        
        private T Create<T>(params object[] parameters) => (T)Activator.CreateInstance(typeof(T), parameters);

        public IItemRule GetRule(Item item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var rule = _rules.Keys.FirstOrDefault(x => item.Name.Contains(x));

            return rule != null 
                ? _rules[rule] 
                : _rules["Default"];
        }
    }
}