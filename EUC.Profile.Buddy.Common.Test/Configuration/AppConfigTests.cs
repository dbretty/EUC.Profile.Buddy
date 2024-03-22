using EUC.Profile.Buddy.Common;
using EUC.Profile.Buddy.Common.Configuration;

namespace EUC.Profile.Buddy.Common.Test.Configuration
{
    [TestClass]
    public class AppConfigTests
    {
        AppConfig appConfig = new AppConfig();

        [TestMethod]
        public void AppConfig_Instantiate_IsNotNull()
        {
            Assert.IsNotNull(appConfig);
        }

        [TestMethod]
        public void AppConfig_ClearTempAtStart_IsNotNull()
        {
            Assert.IsNotNull(appConfig.ClearTempAtStart);
        }
    }
}
