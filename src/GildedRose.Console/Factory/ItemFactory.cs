using System;
using System.Linq;
using GildedRose.Console.Models;
using GildedRose.Console.Validator;

namespace GildedRose.Console.Factory
{
    class ItemFactory : IItemFactory
    {
        private readonly IItemValidator _validator;

        public ItemFactory(IItemValidator validators)
        {
            _validator = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public Item Create(string itemName, int quality, int sellIn) =>
            _validator.IsValid(itemName, quality, sellIn)
                ? new Item
                {
                    Name = itemName,
                    Quality = quality,
                    SellIn = sellIn
                }
                : new NullItem();
    }
}