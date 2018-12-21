using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using GildedRose.Console.Updater;
using Xunit;

namespace GildedRose.Tests
{
    public class CheeseItemsShould
    {
        private readonly IItemUpdater _itemUpdater;
        private readonly IItemFactory _itemFactory;

        public CheeseItemsShould()
        {
            _itemUpdater = ObjectGraph.UpdaterInstance;
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void IncreaseInValueAsItGetsOlder()
        {
            var quality = 5;
            var sellIn = 0;

            var itemCollection = new List<Item> { _itemFactory.Create("Aged Brie", quality, sellIn) };

            var items = new Items(itemCollection);

            for (int i = 0; i < 5; i++)
            {
                _itemUpdater.Update(items);
                quality++;
                Assert.Equal(quality, items.First().Quality);
            }

            var assert = new zAssert();

            //assert.OnEachCycle().That(20).IsEqualTo(20).For(20).Assert();

            //assert.That(items.First().Quality).IsEqualTo(quality++).While(() => _itemUpdater.Update(items)).Runs().Times(50);

        }

        [Fact]
        public void NeverIncreaseQualityToMoreThan50()
        {
            var quality = 5;
            var sellIn = 0;

            var itemCollection = new List<Item> { _itemFactory.Create("Aged Brie", quality, sellIn) };

            var items = new Items(itemCollection);

            new zAssert().After(() => _itemUpdater.Update(items))
                .Executes(60)
                .That(items.First().Quality)
                .IsEqualTo(50)
                .Assert();
        }
    }
}