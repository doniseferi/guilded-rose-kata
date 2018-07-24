namespace GildedRose.Console.Item
{
    public class NullItem : IItem
    {
        public string Name
        {
            get => "NULL_ITEM";
            set { }
        }

        public int SellIn
        {
            get => 0;
            set { }
        }

        public int Quality
        {
            get => 0;
            set { }
        }
    }
}