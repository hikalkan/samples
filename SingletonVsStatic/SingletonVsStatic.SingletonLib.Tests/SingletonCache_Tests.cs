using System;
using Xunit;

namespace SingletonVsStatic.SingletonLib.Tests
{
    public class SingletonCache_Tests
    {
        private readonly SingletonCache _singletonCache;

        public SingletonCache_Tests()
        {
            _singletonCache = new SingletonCache();

            _singletonCache.Add("TestKey1", "TestValue1");
            _singletonCache.Add("TestKey2", "TestValue2");
        }

        [Fact]
        public void Should_Contain_Initial_Values()
        {
            Assert.Equal(2, _singletonCache.GetCount());

            Assert.Equal("TestValue1", _singletonCache.GetOrNull("TestKey1"));
            Assert.Equal("TestValue2", _singletonCache.GetOrNull("TestKey2"));
        }

        [Fact]
        public void Should_Add_And_Get_Values()
        {
            _singletonCache.Add("MyNumber", 42);

            Assert.Equal(42, _singletonCache.GetOrNull("MyNumber"));
        }

        [Fact]
        public void Should_Increase_Count_When_A_New_Item_Added()
        {
            Assert.Equal(2, _singletonCache.GetCount());

            _singletonCache.Add("TestKeyX", "X");

            Assert.Equal(3, _singletonCache.GetCount());
        }

        [Fact]
        public void Clear_Should_Delete_All_Values()
        {
            _singletonCache.Clear();

            Assert.Equal(0, _singletonCache.GetCount());
            Assert.Null(_singletonCache.GetOrNull("TestKey1"));
        }

        [Fact]
        public void Should_Remove_Values()
        {
            _singletonCache.Remove("TestKey1");

            Assert.Null(_singletonCache.GetOrNull("TestKey1"));
        }

        [Fact]
        public void Should_Use_Factory_Only_If_The_Value_Was_Not_Present()
        {
            //The key is already present, so it doesn't use the factory to create a new one
            Assert.Equal("TestValue1", _singletonCache.GetOrAdd("TestKey1", () => "TestValue1_Changed"));

            _singletonCache.Remove("TestKey1");

            //The key is not present, so it uses the factory to create a new one
            Assert.Equal("TestValue1_Changed", _singletonCache.GetOrAdd("TestKey1", () => "TestValue1_Changed"));
        }

        [Fact]
        public void GetOrThrowException_Should_Throw_Exception_For_Unknown_Keys()
        {
            Assert.Throws<ApplicationException>(() =>
            {
                _singletonCache.GetOrThrowException("UnknownKey");
            });
        }
    }
}