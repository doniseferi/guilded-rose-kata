using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemFactoryShould
    {
        private ItemFactory _itemFactory;
        public ItemFactoryShould()
        {
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void CreateValidItem()
        {
            var itemName = "magic beans";
            var quality = 10;
            var sellIn = 10;


            var item = _itemFactory.Create(itemName, quality, sellIn);

            Assert.Equal(itemName, item.Name);
            Assert.Equal(quality, item.Quality);
            Assert.Equal(sellIn, item.SellIn);
        }


        [Fact]
        public void ReturnNullObjectWhenNullNamePassedIn()
        {
            var nullItemDefaultName = "NULL_ITEM";

            var item = _itemFactory.Create(null, 10, 10);

            Assert.IsType<NullItem>(item);

            Assert.Equal(nullItemDefaultName, item.Name);
        }

        [Fact]
        public void ReturnNullObjectWhenEmptyNamePassedIn()
        {
            var nullItemDefaultName = "NULL_ITEM";

            var item = _itemFactory.Create("", 10, 10);

            Assert.IsType<NullItem>(item);

            Assert.Equal(nullItemDefaultName, item.Name);
        }

        [Fact]
        public void ReturnNullObjectWhenNegativeQualityPassedIn()
        {
            var negativeQuality = -1;
            var nullItemDefaultQuality = 0;

            var item = _itemFactory.Create("item name", negativeQuality, 10);

            Assert.IsType<NullItem>(item);

            Assert.Equal(nullItemDefaultQuality, item.Quality);
        }

        [Fact]
        public void ReturnNullObjectWhenNegativeSellInPassedIn()
        {
            var negativeSellIn = -1;
            var nullItemDefaultSellIn = 0;

            var item = _itemFactory.Create("item name", negativeSellIn, 10);

            Assert.IsType<NullItem>(item);

            Assert.Equal(nullItemDefaultSellIn, item.SellIn);
        }

        [Fact]
        public void ReturnNullObjectWhenSulfurasQualityOver50()
        {
            var attemptedQuality = 51;
            var nullItemDefaultSellIn = 0;

            var item = _itemFactory.Create("item name", attemptedQuality, 10);

            Assert.IsType<NullItem>(item);

            Assert.Equal(nullItemDefaultSellIn, item.SellIn);
        }
    }
}
