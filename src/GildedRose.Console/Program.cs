using System.Collections.Generic;
using GildedRose.Console.IOC;
using GildedRose.Console.Models;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            IList<Item> initItems = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var items = new Items(initItems);

            UpdateQuality(items);
        }

        public static void UpdateQuality(Items items)
        {
            ObjectGraph.UpdaterInstance.Update(items);
        }
    }
}