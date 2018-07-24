using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemsShould
    {
        private readonly ItemFactory _itemFactory;

        public ConjuredItemsShould()
        {
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void DegradeTwiceAsFastAsNormalItems()
        {
            var quality = 8;
            var sellIn = 4;

            var conjuredItems = new List<Item>
            {
                _itemFactory.Create("Conjured Mana Cake", quality, sellIn),
            };

            var items = new Items(conjuredItems);

            items.InvokeOnEachDayCycle(4, () =>
            {
                quality -= 2;
                Assert.Equal(quality, items.First().Quality);
            });
        }

        [Fact]
        public void DegradeTwiceAsFastAsNormalItemsWhenSellInExpired()
        {
            var quality = 12;
            var sellIn = 0;

            var conjuredItems = new List<Item>
            {
                _itemFactory.Create("Conjured Mana Cake", quality, sellIn),
            };

            var items = new Items(conjuredItems);

            items.InvokeOnEachDayCycle(3, () =>
            {
                quality -= 4;
                Assert.Equal(quality, items.First().Quality);
            });
        }


        [Fact]
        public void NeverIncreaseInQuality()
        {
            var quality = 8;
            var sellIn = 4;

            var conjuredItems = new List<Item>
            {
                _itemFactory.Create("Conjured Mana Cake", quality, sellIn),
            };

            var items = new Items(conjuredItems);

            items.InvokeOnEachDayCycle(4, () =>
            {
                Assert.True(items.First().Quality < quality);
                quality--;
            });
        }

        [Fact]
        public void NeverHaveQualityLessThan0()
        {
            var quality = 5;
            var sellIn = 7;

            var regularItems = new List<Item>
            {
                _itemFactory.Create("Conjured Mana Cake", quality, sellIn),
            };

            var items = new Items(regularItems);

            items.InvokeOnCompletionOfAllCycles(10, () =>
            {
                Assert.Equal(0, items.First().Quality); 
            });
        }
    }
}
