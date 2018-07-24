using GildedRose.Console.Models;

namespace GildedRose.Console.Factory
{
    public interface IItemFactory
    {
        Item Create(string itemName, int quality, int sellIn);
    }
}