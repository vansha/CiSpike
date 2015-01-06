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
        public void Failing_Test()
        {
            Assert.Fail("Oops. Developer is high. Don't let him touch a keyboard.");
        }
    }
}