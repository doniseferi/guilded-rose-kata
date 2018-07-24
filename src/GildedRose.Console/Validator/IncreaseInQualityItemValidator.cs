using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class IncreaseInQualityItemValidator : ItemValidator
    {
        private readonly IEnumerable<string> _increaseInQualityItemNames;
        private readonly ItemValidator _regularItemValidator;

        public IncreaseInQualityItemValidator(
            IEnumerable<string> increaseInQualityItemNames, 
            ItemValidator regularItemValidator)
        {
            _increaseInQualityItemNames = increaseInQualityItemNames;
            _regularItemValidator = regularItemValidator;
        }

        public bool IsValid(string itemName, int quality, int sellIn)
            => _regularItemValidator.IsValid(itemName, quality, sellIn)
               && _increaseInQualityItemNames.Contains(itemName);
    }
}