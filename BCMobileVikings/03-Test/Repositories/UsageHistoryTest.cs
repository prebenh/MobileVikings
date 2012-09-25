using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class UsageHistoryTest : RepositoryTest
    {
        private IUsageHistory _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new UsageHistory();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetUsage_WhenCalled_ReturnsUsage()
        {
            var usage = await _repository.GetUsage(Properties.MobileNumber);

            Assert.IsNotNull(usage);
            if (usage.Any())
            {
                var firstUsage = usage.First();

                Assert.IsFalse(string.IsNullOrEmpty(firstUsage.Duration));
                Assert.IsTrue(firstUsage.DurationInSeconds > 0);
                Assert.IsNotNull(firstUsage.Start);
                Assert.IsNotNull(firstUsage.End);
                Assert.IsFalse(string.IsNullOrEmpty(firstUsage.To));
            }
        }
    }
}
