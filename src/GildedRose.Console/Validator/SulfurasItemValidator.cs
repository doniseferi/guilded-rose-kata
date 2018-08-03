using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class SulfurasItemValidator : IItemValidator
    {
        private readonly IEnumerable<string> _specialItemNames;
        private readonly int _specialItemQuality;

        public SulfurasItemValidator(IEnumerable<string> specialItemNames, int specialItemQuality)
        {
            _specialItemNames = specialItemNames;
            _specialItemQuality = specialItemQuality;
        }

        public bool IsValid(string itemName, int quality, int sellIn)
            => !string.IsNullOrWhiteSpace(itemName)
               && quality == _specialItemQuality
               && _specialItemNames.Contains(itemName);
    }
}