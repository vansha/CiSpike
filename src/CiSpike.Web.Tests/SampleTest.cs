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
        public void Test_That_Our_Universe_Is_Good_Enough_Place_To_Live()
        {
            Assert.Fail("Oops. You didn't expect that, did you?");
        }
    }
}