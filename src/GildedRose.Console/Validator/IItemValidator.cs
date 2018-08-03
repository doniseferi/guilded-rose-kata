namespace GildedRose.Console.Validator
{
    public interface IItemValidator
    {
        bool IsValid(string itemName, int quality, int sellIn);
    }
}