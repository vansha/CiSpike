using System;
using System.Threading;
using NUnit.Framework;

namespace CiSpike.IntegrationTests
{
    [Category("UI")]
    public class UiTests
    {
        [Test]
        public void LongTest()
        {
            Thread.Sleep(TimeSpan.FromSeconds(15));
            Assert.Pass();
        }
    }
}
