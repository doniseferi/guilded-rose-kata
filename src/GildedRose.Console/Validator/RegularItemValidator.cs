using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class RegularItemValidator : ItemValidator
    {
        private readonly int _minimumQuality;
        private readonly int _maximumQuality;
        private readonly int _minimumSellIn;
        private readonly IEnumerable<string> _specialNameItems;

        public RegularItemValidator(int minimumQuality, int maximumQuality, int minimumSellIn, IEnumerable<string> specialNameItems)
        {
            _minimumQuality = minimumQuality;
            _minimumSellIn = minimumSellIn;
            _specialNameItems = specialNameItems;
            _maximumQuality = maximumQuality;
        }

        public bool IsValid(string itemName, int quality, int sellIn)
            => !string.IsNullOrWhiteSpace(itemName)
               && quality >= _minimumQuality
               && quality <= _maximumQuality
               && sellIn >= _minimumSellIn
               && !_specialNameItems.Contains(itemName);
    }
}