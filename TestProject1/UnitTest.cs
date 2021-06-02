using Unidom;
using Xunit;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void Generate_Random_By_Fixed_Length_Test()
        {
            var c = Uuid.Random(10);
            var d = Uuid.Random(10);

            Assert.NotEqual(c, d);
        }

        [Fact]
        public void Generate_Random_Between_Length_Test()
        {
            var a = Uuid.Random(4, 8);
            var b = Uuid.Random(4, 8);

            Assert.NotEqual(a, b);
        }
    }
}