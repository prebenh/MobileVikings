using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class TopUpHistoryTest : RepositoryTest
    {

        private ITopUpHistory _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new TopUpHistory();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetHistory_WhenCalled_ReturnsHistory()
        {
            var result = await _repository.GetHistory(Properties.MobileNumber);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());

            var latestTopUp = result.First();

            Assert.IsTrue(latestTopUp.Amount > 0);
            Assert.IsFalse(string.IsNullOrEmpty(latestTopUp.Method));
            Assert.IsTrue(latestTopUp.Received > DateTime.MinValue);
            Assert.IsFalse(string.IsNullOrEmpty(latestTopUp.Status));
        }
    }
}
