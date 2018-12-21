using System;
using System.Windows.Input;

namespace GildedRose.Tests
{
    public class zAssert
    {
        private object _actual;
        private Action _action;
        private Action _assert;
        public zAssert After(Action action)
        {
            _action = action;
            return this;
        }

        public zAssert Executes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _action();
            }

            return this;
        }

        public zAssert That<T>(T actual)
        {
            _actual = actual;
            return this;
        }

        public zAssert IsEqualTo<T>(T expected)
        {
            object _expected = expected;
            _assert = () => Xunit.Assert.Equal(_expected, _actual);
            return this;
        }


        public zAssert Assert()
        {
            _assert();
            return this;
        }

        public zCompositeAssert And()
        {
            return new zCompositeAssert(this);
        }
    }

    public class zCompositeAssert : zAssert
    {
        private object _actual;
        private zAssert _zAssert;
        private Action _assert;

        public zCompositeAssert(zAssert assert)
        {
            _zAssert = assert;
        }

        public zAssert That<T>(T actual)
        {
            _actual = actual;
            return this;
        }

        public zAssert IsEqualTo<T>(T expected)
        {
            object _expected = expected;
            _assert = () => Xunit.Assert.Equal(_expected, _actual);
            return this;
        }

        public zAssert Assert()
        {
            base.Assert();
            this._assert();
            return this;
        }

    }
}