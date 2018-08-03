using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Validator
{
    class ItemValidators : ICollection<IItemValidator>
    {
        private readonly List<IItemValidator> _itemValidators;

        public ItemValidators(IEnumerable<IItemValidator> itemValidators)
        {
            if (itemValidators == null)
                throw new ArgumentNullException();

            _itemValidators = itemValidators.ToList();
        }

        public IEnumerator<IItemValidator> GetEnumerator() => _itemValidators.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(IItemValidator item) => _itemValidators.Add(item);
        public void Clear() => _itemValidators.Clear();
        public bool Contains(IItemValidator item) => _itemValidators.Contains(item);
        public void CopyTo(IItemValidator[] array, int arrayIndex) => _itemValidators.CopyTo(array, arrayIndex);
        public bool Remove(IItemValidator item) => _itemValidators.Remove(item);
        public int Count => _itemValidators.Count;
        public bool IsReadOnly => false;
    }
}
