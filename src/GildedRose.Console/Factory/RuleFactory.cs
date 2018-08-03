using System;
using System.Linq;
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

            var rule = _rules.FirstOrDefault(x => item.Name.Contains(x.Key));

            return rule.Value ?? _rules.First(x => x.Key.Contains("Default")).Value;
        }
    }
}