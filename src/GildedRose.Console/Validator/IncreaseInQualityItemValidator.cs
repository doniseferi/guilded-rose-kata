using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class IncreaseInQualityItemValidator : IItemValidator
    {
        private readonly IEnumerable<string> _increaseInQualityItemNames;
        private readonly IItemValidator _regularItemValidator;

        public IncreaseInQualityItemValidator(
            IEnumerable<string> increaseInQualityItemNames, 
            IItemValidator regularItemValidator)
        {
            _increaseInQualityItemNames = increaseInQualityItemNames;
            _regularItemValidator = regularItemValidator;
        }

        public bool IsValid(string itemName, int quality, int sellIn)
            => _regularItemValidator.IsValid(itemName, quality, sellIn)
               && _increaseInQualityItemNames.Contains(itemName);
    }
}