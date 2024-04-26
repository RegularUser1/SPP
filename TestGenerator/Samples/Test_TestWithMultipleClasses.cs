using System.Security;
using Xunit;
using Moq;
using SampleProject;

namespace Tests
{
    public class Test_TestWithMultipleClasses
    {
        private TestWithMultipleClasses testwithmultipleclasses;
        private Mock<IEnumerable<int>> a;
        public Test_TestWithMultipleClasses()
        {
            a = new Mock<IEnumerable<int>>();
            var integer = default(int);
            testwithmultipleclasses = new TestWithMultipleClasses(a.Object, integer);
        }

        [Fact]
        public void Test_DoSomething()
        {
            var testParam = default(int);
            var a = default(object);
            var actual = testwithmultipleclasses.DoSomething(testParam, a);
            var expected = default(int);
            Assert.Equal(expected, actual);
            Assert.Fail("autogenerated");
        }

        [Fact]
        public void Test_DoAnother()
        {
            Assert.Fail("autogenerated");
        }
    }
}