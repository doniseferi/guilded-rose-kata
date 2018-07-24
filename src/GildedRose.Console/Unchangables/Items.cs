using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Item
{
    public class Items : ICollection<IItem>
    {
        private ICollection<IItem> _items;

        public Items(IEnumerable<IItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _items = items.ToList();
        }

        public IEnumerator<IItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(IItem item) => _items.Add(item);

        public void Clear() => _items.Clear();

        public bool Contains(IItem item) => _items.Contains(item);

        public void CopyTo(IItem[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        public bool Remove(IItem item) => _items.Remove(item);

        public int Count => _items.Count;

        public bool IsReadOnly => false;
    }
}
