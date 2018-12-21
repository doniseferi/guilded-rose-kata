using System.Collections.Generic;
using GildedRose.Console.Factory;
using GildedRose.Console.Updater;
using GildedRose.Console.Validator;

namespace GildedRose.Console.IOC
{
    /// <summary>
    /// This class exists solely because this refactoring exercise was complete
    /// without any packages. This class is responsible for creating an object graph
    /// which would be done by a ioc container. This is here only so that there are no
    /// dependencies on packages.
    /// </summary>
    public class ObjectGraph
    {
        private static ItemUpdater _itemUpdater;
        private static ItemFactory _itemFactory;
        private static IItemValidator _validators;
        private static readonly object ItemFactoryLock = new object();
        private static readonly object ItemUpdaterLock = new object();
        private static readonly object ItemValidatorLock = new object();

        public static IItemUpdater UpdaterInstance
        {
            get
            {
                if (_itemUpdater == null)
                {
                    lock (ItemUpdaterLock)
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

        public static IItemFactory ItemFactoryInstance
        {
            get
            {
                if (_itemFactory == null)
                {
                    lock (ItemFactoryLock)
                    {
                        if (_itemFactory == null)
                        {
                            _itemFactory = new ItemFactory(Valdators);
                        }
                    }
                }

                return _itemFactory;
            }
        }

        public static IItemValidator Valdators
        {
            get
            {
                if (_validators == null)
                {
                    lock (ItemValidatorLock)
                    {
                        if (_validators == null)
                        {
                            var specialItemName = new List<string> {"Sulfuras"};
                            var increaseInValueNames = new List<string> {"Tickets"};

                            var regularItemValidator = new RegularItemValidator(0, 50, 0, specialItemName);
                            var specialItemValidator = new SulfurasItemValidator(specialItemName, 80);
                            var increaseInQualityValidator =
                                new IncreaseInQualityItemValidator(increaseInValueNames, regularItemValidator);

                            _validators = new ItemValidators(new List<IItemValidator>
                            {
                                regularItemValidator,
                                specialItemValidator,
                                increaseInQualityValidator,
                            });
                        }
                    }
                }

                return _validators;
            }
        }
    }
}