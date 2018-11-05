using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    class RegularItemsShould
    {
        private readonly IItemFactory _itemFactory;

        public RegularItemsShould()
        {
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

            items.InvokeOnEachDayCycle(40, () =>
            {
                quality--;
                Assert.Equal(quality, items.First().Quality);
            });
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

            items.InvokeOnEachDayCycle(5, () =>
            {
                quality -= 2;
                Assert.Equal(quality, items.First().Quality);
            });

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

            items.InvokeOnEachDayCycle(40, () =>
            {
                Assert.True(items.First().Quality < quality);
                quality--;
            });
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


            items.InvokeOnCompletionOfAllCycles(50, () =>
            {
                items.ToList()
                    .ForEach(item => Assert.Equal(0, item.Quality));
            });
        }
    }
}