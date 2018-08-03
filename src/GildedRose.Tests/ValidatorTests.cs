using System.Collections.Generic;
using GildedRose.Console.Validator;
using Xunit;

namespace GildedRose.Tests
{
    public class ValidatorTests
    {
        private IItemValidator _validator;
        private readonly IEnumerable<string> _increaseInQualityNames = new List<string> { "cheese" };
        private readonly IEnumerable<string> _specialNames = new List<string> { "special" };

        public void SetValidator(IItemValidator validator) => _validator = validator;

        [Fact]
        public void IncreaseInQualityItemValidatorSuccessPath()
        {
            SetValidator(new IncreaseInQualityItemValidator(_increaseInQualityNames,
                new RegularItemValidator(0, 50, 0, _specialNames)));

            var result = _validator.IsValid("cheese", 10, 10);

            Assert.True(result);
        }

        [Fact]
        public void IncreaseInQualityItemValidatorFailedPath()
        {
            SetValidator(new IncreaseInQualityItemValidator(_increaseInQualityNames,
                new RegularItemValidator(0, 50, 0, _specialNames)));

            var result = _validator.IsValid("cheese", 60, 10);

            Assert.False(result);
        }

    }
}
