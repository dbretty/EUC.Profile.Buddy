using EUC.Profile.Buddy.Common.Logging;
using Moq;
using Xunit;

namespace EUC.Profile.Buddy.Common.Test.Configuration
{
    [TestClass]
    public class LoggingTests
    {
        [TestMethod]
        public void test()
        {
            ILogger mockLogger = Mock.Of<ILogger>();
            var result = mockLogger.LogAsync("Testing the logging");
            Assert.IsNotNull(result);
        }
    }
}
