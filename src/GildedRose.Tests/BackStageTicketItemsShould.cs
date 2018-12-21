using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using GildedRose.Console.Updater;
using Xunit;

namespace GildedRose.Tests
{
    public class BackStageTicketItemsShould
    {
        private readonly IItemUpdater _itemUpdater;
        private readonly IItemFactory _itemFactory;

        public BackStageTicketItemsShould()
        {
            _itemUpdater = ObjectGraph.UpdaterInstance;
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void IncreaseBy1WhenThereAreMoreThan10DaysLeft()
        {
            var quality = 10;
            var sellIn = 15;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };

            var items = new Items(itemCollection);

            for (int i = 0; i < 5; i++)
            {
                _itemUpdater.Update(items);
                quality++;
                Assert.Equal(quality, items.First().Quality);
            }
        }

        [Fact]
        public void IncreaseBy2WhenThereAreLessThan10DaysLeft()
        {
            var quality = 10;
            var sellIn = 10;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };
            var items = new Items(itemCollection);

            for (int i = 0; i < 5; i++)
            {
                _itemUpdater.Update(items);
                quality += 2;
                Assert.Equal(quality, items.First().Quality);
            }
        }

        [Fact]
        public void IncreaseBy3WhenThereAreLessThan5DaysLeft()
        {
            var quality = 10;
            var sellIn = 5;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };

            var items = new Items(itemCollection);

            for (int i = 0; i < 5; i++)
            {
                _itemUpdater.Update(items);
                quality += 3;
                Assert.Equal(quality, items.First().Quality);
            }
        }

        [Fact]
        public void LoseAllValueWhenTheEventIsExpired()
        {
            var quality = 10;
            var sellIn = 5;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };

            var items = new Items(itemCollection);

            var expectedQuality = 0;

            new zAssert().After(() => _itemUpdater.Update(items))
                .Executes(6)
                .That(items.First().Quality)
                .IsEqualTo(expectedQuality)
                .Assert();
        }

        [Fact]
        public void NeverHaveAQualityValueOfMoreThan50()
        {
            var quality = 45;
            var sellIn = 20;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };

            var items = new Items(itemCollection);

            var expectedQuality = 50;

            new zAssert()
                .After(() => _itemUpdater.Update(items))
                .Executes(15)
                .That(items.First().Quality)
                .IsEqualTo(expectedQuality)
                .Assert();
        }

        [Fact]
        public void NeverHaveAQualityValueOfLessThan0()
        {
            var quality = 5;
            var sellIn = 20;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };

            var items = new Items(itemCollection);

            var expectedQuality = 0;

            new zAssert()
                .After(() => _itemUpdater.Update(items))
                .Executes(30)
                .That(items.First().Quality)
                .IsEqualTo(expectedQuality)
                .Assert();

        }

        [Fact]
        public void HaveAValueOnDay0OfTheEvent()
        {
            var quality = 5;
            var sellIn = 1;

            var itemCollection = new List<Item>
            {
                _itemFactory.Create("Backstage passes to a TAFKAL80ETC concert", quality, sellIn)
            };

            var items = new Items(itemCollection);

            _itemUpdater.Update(items);

            var expectedSellIn = 0;
            var expectedQuality = 8;

            new zAssert()
                .That(items.First().SellIn)
                .IsEqualTo(expectedSellIn)
                .And()
                .That(items.First().Quality)
                .IsEqualTo(expectedQuality)
                .After(() => _itemUpdater.Update(items))
                .Executes(30)
                .Assert();
        }
    }
}