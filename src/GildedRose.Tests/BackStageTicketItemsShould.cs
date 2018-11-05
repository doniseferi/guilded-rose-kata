using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    class BackStageTicketItemsShould
    {
        private readonly IItemFactory _itemFactory;

        public BackStageTicketItemsShould()
        {
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void IncreaseBy1WhenThereAreMoreThan10DaysLeft()
        {
            var quality = 10;
            var sellIn = 15;

            var itemCollection = new List<Item> {_itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)};

            var items = new Items(itemCollection);

            items.InvokeOnEachDayCycle(5, () =>
            {
                quality++;
                Assert.Equal(quality, items.First().Quality);
            });
        }

        [Fact]
        public void IncreaseBy2WhenThereAreLessThan10DaysLeft()
        {
            var quality = 10;
            var sellIn = 10;

            var itemCollection = new List<Item> { _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) };
            var items = new Items(itemCollection);

            items.InvokeOnEachDayCycle(5, () =>
            {
                quality += 2;
                Assert.Equal(quality, items.First().Quality);
            });
        }

        [Fact]
        public void IncreaseBy3WhenThereAreLessThan5DaysLeft()
        {
            var quality = 10;
            var sellIn = 5;

            var itemCollection = new List<Item> { _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnEachDayCycle(5, () =>
            {
                quality += 3;
                Assert.Equal(quality, items.First().Quality);
            });
        }

        [Fact]
        public void LoseAllValueWhenTheEventIsExpired()
        {
            var quality = 10;
            var sellIn = 5;

            var itemCollection = new List<Item> { _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnCompletionOfAllCycles(6, () =>
            {
                Assert.Equal(0, items.First().Quality);
            });
        }

        [Fact]
        public void NeverHaveAQualityValueOfMoreThan50()
        {
            var quality = 45;
            var sellIn = 20;

            var itemCollection = new List<Item> { _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnCompletionOfAllCycles(15, () =>
            {
                Assert.Equal(50, items.First().Quality);
            });
        }

        [Fact]
        public void NeverHaveAQualityValueOfLessThan0()
        {
            var quality = 5;
            var sellIn = 20;

            var itemCollection = new List<Item> { _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnCompletionOfAllCycles(30, () =>
            {
                Assert.Equal(0, items.First().Quality);
            });
        }

        [Fact]
        public void HaveAValueOnDay0OfTheEvent()
        {
            var quality = 5;
            var sellIn = 1;

            var itemCollection = new List<Item> { _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) };

            var items = new Items(itemCollection);

            items.InvokeOnCompletionOfAllCycles(1, () =>
            {
                Assert.Equal(0, items.First().SellIn);
                Assert.Equal(8, items.First().Quality);
            });
        }
    }
}