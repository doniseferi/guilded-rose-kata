using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class ItemValidators : IItemValidator
    {
        private readonly IReadOnlyCollection<IItemValidator> _itemValidators;

        public ItemValidators(IEnumerable<IItemValidator> itemValidators)
        {
            if (itemValidators == null)
                throw new ArgumentNullException();

            _itemValidators = itemValidators.ToList();
        }

        public bool IsValid(string itemName, int quality, int sellIn)
            => _itemValidators.Any(x => x.IsValid(itemName, quality, sellIn));
    }
}