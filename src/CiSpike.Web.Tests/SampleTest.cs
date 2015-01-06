using NUnit.Framework;

namespace CiSpike.Web.Tests
{
    public class SampleTest
    {
        [Test]
        public void SuccessTest()
        {
            Assert.Pass("Dummy successful test");
        }

        [Test]
        public void AnotherSuccessfulTest()
        {
            Assert.Pass("Fixed test");
        }

        [Test]
        public void NotFailingTest()
        {
            Assert.Pass("Fixing build");
        }

        [Test]
        public void Test_That_3_plus_2_eq_5()
        {
            var result = 3 + 2;
            Assert.AreEqual(5, result);
        }
    }
}