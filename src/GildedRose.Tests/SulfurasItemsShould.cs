using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Factory;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasItemsShould
    {
        private readonly IItemFactory _itemFactory;

        public SulfurasItemsShould()
        {
            _itemFactory = ObjectGraph.ItemFactoryInstance;
        }

        [Fact]
        public void NeverHaveToBeSold()
        {
            var sulfuras = new List<Item> {_itemFactory.Create("Sulfuras", 80, 0)};

            var items = new Items(sulfuras);

            items.InvokeOnEachDayCycle(10, () =>
            {
                Assert.Equal(0, items.First().SellIn);
            });

        }

        [Fact]
        public void NeverLoseValue()
        {
            var sulfuras = new List<Item> { _itemFactory.Create("Sulfuras", 80, 0) };

            var items = new Items(sulfuras);

            items.InvokeOnEachDayCycle(10, () =>
            {
                Assert.Equal(80, items.First().Quality);
            });
        }
    }
}
