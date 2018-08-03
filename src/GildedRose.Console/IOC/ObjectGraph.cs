using System.Collections.Generic;
using GildedRose.Console.Factory;
using GildedRose.Console.Updater;
using GildedRose.Console.Validator;

namespace GildedRose.Console.IOC
{
    class ObjectGraph
    {
        private static ItemUpdater _itemUpdater;
        private static ItemFactory _itemFactory;
        private static readonly object Lock = new object();

        public static ItemUpdater UpdaterInstance
        {
            get
            {
                if (_itemUpdater == null)
                {
                    lock (Lock)
                    {
                        if (_itemUpdater == null)
                        {
                            _itemUpdater = new ItemUpdater(new RuleFactory(new Rules.Rules()));
                        }
                    }
                }

                return _itemUpdater;
            }
        }

        public static ItemFactory ItemFactoryInstance
        {
            get
            {
                if (_itemFactory == null)
                {
                    lock (Lock)
                    {
                        if (_itemFactory == null)
                        {
                            var specialItemName = new List<string> { "Sulfuras" };
                            var increaseInValueNames = new List<string> { "Tickets" };

                            var regularItemValidator = new RegularItemValidator(0, 50, 0, specialItemName);
                            var specialItemValidator = new SulfurasItemValidator(specialItemName, 80);
                            var increaseInQualityValidator = new IncreaseInQualityItemValidator(increaseInValueNames, regularItemValidator);

                            var itemValidators = new List<IItemValidator>
                            {
                                regularItemValidator,
                                specialItemValidator,
                                increaseInQualityValidator,
                            };

                            _itemFactory = new ItemFactory(new ItemValidators(itemValidators));
                        }
                    }
                }
                return _itemFactory;
            }
        }
    }
}