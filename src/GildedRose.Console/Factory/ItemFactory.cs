using System;
using System.Linq;
using GildedRose.Console.Models;
using GildedRose.Console.Validator;

namespace GildedRose.Console.Factory
{
    class ItemFactory : IItemFactory
    {
        private readonly ItemValidators _validators;

        public ItemFactory(ItemValidators validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public Item Create(string itemName, int quality, int sellIn)
        {
            var availableValidator = 
                _validators.FirstOrDefault(x 
                    => x.IsValid(itemName, quality, sellIn));

            return availableValidator != null
                ? new Item
                {
                    Name = itemName,
                    Quality = quality,
                    SellIn = sellIn
                }
                : new NullItem();
        }
    }
}