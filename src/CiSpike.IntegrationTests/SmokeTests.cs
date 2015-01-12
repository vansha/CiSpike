using System;
using System.Threading;
using NUnit.Framework;

namespace CiSpike.IntegrationTests
{
    [Category("Smoke")]
    public class SmokeTests
    {
        [Test]
        public void LongTest()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Assert.Pass();
        }
    }
}