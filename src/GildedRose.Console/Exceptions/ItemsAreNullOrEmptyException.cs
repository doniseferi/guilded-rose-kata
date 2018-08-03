using System;

namespace GildedRose.Console.Models
{
    public class ItemsAreNullOrEmpty : Exception
    {
        private const string ErrorMessage = "The Items collection is either null or has no entries " +
                                            "Please provide a collection with a minimum of 1 entries.";
        public ItemsAreNullOrEmpty() 
            : base(ErrorMessage)
        {
        }
    }
}