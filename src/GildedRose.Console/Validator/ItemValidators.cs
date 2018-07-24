using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class ItemValidators : ICollection<ItemValidator>
    {
        private readonly List<ItemValidator> _itemValidators;

        public ItemValidators(IEnumerable<ItemValidator> itemValidators)
        {
            if (itemValidators == null)
                throw new ArgumentNullException();

            _itemValidators = itemValidators.ToList();
        }

        public IEnumerator<ItemValidator> GetEnumerator() => _itemValidators.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(ItemValidator item) => _itemValidators.Add(item);
        public void Clear() => _itemValidators.Clear();
        public bool Contains(ItemValidator item) => _itemValidators.Contains(item);
        public void CopyTo(ItemValidator[] array, int arrayIndex) => _itemValidators.CopyTo(array, arrayIndex);
        public bool Remove(ItemValidator item) => _itemValidators.Remove(item);
        public int Count => _itemValidators.Count;
        public bool IsReadOnly => false;
    }
}
