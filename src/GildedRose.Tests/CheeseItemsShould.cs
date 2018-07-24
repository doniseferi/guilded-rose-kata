using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    public class CheeseItemsShould
    {
        private readonly ItemFactory _itemFactory;

        public CheeseItemsShould()
        {
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void IncreaseInValueAsItGetsOlder()
        {
            var quality = 5;
            var sellIn = 0;

            var itemCollection = new List<Item> { _itemFactory.Create("Aged Brie", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnEachDayCycle(5, () =>
            {
                quality++;
                Assert.Equal(quality, items.First().Quality);
            });
        }

        [Fact]
        public void NeverIncreaseQualityToMoreThan50()
        {
            var quality = 5;
            var sellIn = 0;

            var itemCollection = new List<Item> { _itemFactory.Create("Aged Brie", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnCompletionOfAllCycles(60, () =>
            {
                Assert.Equal(50, items.First().Quality);
            });
        }
    }
}