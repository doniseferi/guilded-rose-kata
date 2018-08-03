using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Models
{
    public class Items : IEnumerable<Item>
    {
        private readonly IReadOnlyCollection<Item> _items;

        public Items(IEnumerable<Item> items)
        {
            var enumerable = items.ToList();

            if (items == null || !enumerable.Any())
                throw new ItemsAreNullOrEmpty();

            _items = enumerable;
        }

        public IEnumerator<Item> GetEnumerator() 
            => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
