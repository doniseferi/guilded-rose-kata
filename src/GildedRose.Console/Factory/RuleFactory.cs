using System;
using GildedRose.Console.Models;
using GildedRose.Console.Rules;
using _Rules = GildedRose.Console.Rules.Rules;

namespace GildedRose.Console.Factory
{
    class RuleFactory : IRuleFactory
    {
        private readonly _Rules _rules;

        public RuleFactory(_Rules rules)
        {
            _rules = rules;
        }
        
        public IItemRule GetRule(Item item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return _rules.Get(item.Name);
        }
    }
}