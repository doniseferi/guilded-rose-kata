using GildedRose.Console.Rules;
using GildedRose.Console.SpecialRulesHandler;

namespace GildedRose.Console.Factory
{
    public interface ISpecialRulesHandlerFactory
    {
        IQualityHandler CreateFor<T>() where T : IItemRule;
    }
}