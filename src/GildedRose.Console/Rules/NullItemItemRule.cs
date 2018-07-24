using System;
using GildedRose.Console.Models;

namespace GildedRose.Console.Rules
{
    class NullItemItemRule : IItemRule
    {
        public void Update(Item item)
        {
            if (item == null)
                throw new ArgumentNullException();

            if (!(item is NullItem))
                throw new ArgumentException();
        }
    }
}