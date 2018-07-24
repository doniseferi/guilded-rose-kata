namespace GildedRose.Console.Validator
{
    public interface ItemValidator
    {
        bool IsValid(string itemName, int quality, int sellIn);
    }
}