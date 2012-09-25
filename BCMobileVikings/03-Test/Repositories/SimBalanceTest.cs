using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class SimBalanceTest : RepositoryTest
    {

        private ISimBalance _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new SimBalance();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetBalance_WhenCalled_ReturnsSimBalance()
        {
            var result = await _repository.GetBalance(Properties.MobileNumber);

            Assert.IsNotNull(result);

            if (result.IsExpired)
            {
                Assert.IsTrue(result.ValidUntil <= DateTime.Now);
                Assert.AreEqual(0, result.SmsCount);
                Assert.AreEqual(0, result.MobileVikingsSmsCount);
            }
            else
            {
                Assert.IsTrue(result.Data > decimal.MinValue);
                Assert.IsTrue(result.Credit > 0);
                Assert.IsTrue(result.SmsCount > int.MinValue);
            }
        }

    }
}
