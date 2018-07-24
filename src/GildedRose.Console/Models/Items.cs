using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Models
{
    public class Items : IEnumerable<Item>
    {
        private IReadOnlyCollection<Item> _items;

        public Items(IEnumerable<Item> items)
        {
            _items = items.ToList();
        }

        public IEnumerator<Item> GetEnumerator() 
            => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
