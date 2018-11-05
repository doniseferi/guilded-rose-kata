using GildedRose.Console.IOC;
using GildedRose.Console.Validator;
using Xunit;

namespace GildedRose.Tests
{
    public class ValidatorTests
    {
        private readonly IItemValidator _validators = ObjectGraph.Valdators;

        [Fact]
        public void IncreaseInQualityItemValidatorSuccessPath()
        {
            var result = _validators.IsValid("cheese", 10, 10);

            Assert.True(result);
        }

        [Fact]
        public void IncreaseInQualityItemValidatorFailedPath()
        {
            var result = _validators.IsValid("cheese", 60, 10);

            Assert.False(result);
        }
    }
}