using GildedRose.Console.Models;
using GildedRose.Console.Rules;

namespace GildedRose.Console.Factory
{
    public interface IRuleFactory
    {
        IItemRule GetRule(Item item);
    }
}