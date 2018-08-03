using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using GildedRose.Console.Rules;
using Xunit;

namespace GildedRose.Tests
{
    public class RuleFactoryShould
    {
        private readonly IRuleFactory _ruleFactory;

        public RuleFactoryShould()
        {
            _ruleFactory = new RuleFactory(new Rules());
        }

        [Fact]
        public void ReturnCheeseItemRule()
        {

            var item = new Item
            {
                Name = "Brie Cheese",
                Quality = 10,
                SellIn = 10
            };

            var rule = _ruleFactory.GetRule(item);

            Assert.IsType<CheeseItemRule>(rule);
        }

        [Fact]
        public void ReturnNullItemRule()
        {
            var item = new Item
            {
                Name = "NULL_ITEM",
                Quality = 10,
                SellIn = 10
            };

            var rule = _ruleFactory.GetRule(item);

            Assert.IsType<NullItemItemRule>(rule);
        }

        [Fact]
        public void ReturnSpecialItemRule()
        {
            var item = new Item
            {
                Name = "Sulfuras type item",
                Quality = 10,
                SellIn = 10
            };

            var rule = _ruleFactory.GetRule(item);

            Assert.IsType<SpecialItemItemRule>(rule);
        }

        [Fact]
        public void ReturnBackstagePassRule()
        {
            var item = new Item
            {
                Name = "Backstage pass for X",
                Quality = 10,
                SellIn = 10
            };

            var rule = _ruleFactory.GetRule(item);

            Assert.IsType<BackstagePassItemRule>(rule);
        }

        [Fact]
        public void ReturnRegularRule()
        {
            var item = new Item
            {
                Name = "Regular item for X",
                Quality = 10,
                SellIn = 10
            };

            var rule = _ruleFactory.GetRule(item);

            Assert.IsType<RegularItemItemRule>(rule);
        }
    }
}
