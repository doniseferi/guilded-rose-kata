using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using GildedRose.Console.Updater;
using Xunit;

namespace GildedRose.Tests
{
    class RegularItemsShould
    {
        private readonly IItemUpdater _itemUpdater;
        private readonly IItemFactory _itemFactory;

        public RegularItemsShould()
        {
            _itemUpdater = ObjectGraph.UpdaterInstance;
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void DecreaseBy1WhenQualityIsGreaterThan0()
        {
            var quality = 40;
            var sellIn = 40;

            var regularItems = new List<Item>
            {
                _itemFactory.Create("Elixir of the Mongoose", quality, sellIn),
            };

            var items = new Items(regularItems);

            for (int i = 0; i < 40; i++)
            {
                _itemUpdater.Update(items);
                quality--;
                Assert.Equal(quality, items.First().Quality);
            }
        }

        [Fact]
        public void DegradeTwiceAsFastWhenSellByDatePasses()
        {
            var quality = 10;
            var sellIn = 0;

            var regularItems = new List<Item>
            {
                _itemFactory.Create("Elixir of the Mongoose", quality, sellIn),
            };

            var items = new Items(regularItems);

            for (int i = 0; i < 5; i++)
            {
                _itemUpdater.Update(items);
                quality -= 2;
                Assert.Equal(quality, items.First().Quality);
            }

            Assert.Equal(0, items.First().Quality);
        }

        [Fact]
        public void NeverIncreaseInQuality()
        {
            var quality = 40;
            var sellIn = 40;

            var regularItems = new List<Item>
            {
                _itemFactory.Create("Elixir of the Mongoose", quality, sellIn),
            };

            var items = new Items(regularItems);

            for (int i = 0; i < 40; i++)
            {
                _itemUpdater.Update(items);
                Assert.True(items.First().Quality < quality);
                quality--;
            }
        }

        [Fact]
        public void NeverHaveQualityLessThan0()
        {
            var regularItems = new List<Item>
            {
                _itemFactory.Create("+5 Dexterity Vest", sellIn: 20, quality: 10),
                _itemFactory.Create("Elixir of the Mongoose", sellIn: 7, quality: 5),
            };

            var items = new Items(regularItems);

            for (int i = 0; i < 50; i++)
            {
                _itemUpdater.Update(items);
            }

            items.ToList()
                .ForEach(item => Assert.Equal(0, item.Quality));
        }
    }
}