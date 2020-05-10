using Xunit;

namespace SingletonVsStatic.StaticLib.Tests
{
    public class StaticCache_Tests
    {
        static StaticCache_Tests()
        {
            StaticCache.Add("TestKey1", "TestValue1");
            StaticCache.Add("TestKey2", "TestValue2");
        }

        [Fact]
        public void Should_Contain_Initial_Values()
        {
            Assert.Equal(2, StaticCache.GetCount());

            Assert.Equal("TestValue1", StaticCache.GetOrNull("TestKey1"));
            Assert.Equal("TestValue2", StaticCache.GetOrNull("TestKey2"));
        }

        [Fact]
        public void Should_Add_And_Get_Values()
        {
            StaticCache.Add("MyNumber", 42);

            Assert.Equal(42, StaticCache.GetOrNull("MyNumber"));
        }

        [Fact]
        public void Should_Increase_Count_When_A_New_Item_Added()
        {
            Assert.Equal(2, StaticCache.GetCount());

            StaticCache.Add("TestKeyX", "X");

            Assert.Equal(3, StaticCache.GetCount());
        }

        [Fact]
        public void Clear_Should_Delete_All_Values()
        {
            StaticCache.Clear();

            Assert.Equal(0, StaticCache.GetCount());
            Assert.Null(StaticCache.GetOrNull("TestKey1"));
        }

        [Fact]
        public void Should_Remove_Values()
        {
            StaticCache.Remove("TestKey1");

            Assert.Null(StaticCache.GetOrNull("TestKey1"));
        }

        [Fact]
        public void Should_Use_Factory_Only_If_The_Value_Was_Not_Present()
        {
            //The key is already present, so it doesn't use the factory to create a new one
            Assert.Equal("TestValue1", StaticCache.GetOrAdd("TestKey1", () => "TestValue1_Changed"));

            StaticCache.Remove("TestKey1");

            //The key is not present, so it uses the factory to create a new one
            Assert.Equal("TestValue1_Changed", StaticCache.GetOrAdd("TestKey1", () => "TestValue1_Changed"));
        }
    }
}