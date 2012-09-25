using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class PricePlansTest : RepositoryTest
    {
        private IPricePlans _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new PricePlans();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetAll_WhenCalled_ReturnsPricePlanDetails()
        {
            var pricePlans = await _repository.GetPricePlan();
            Assert.IsNotNull(pricePlans);
        }
    }
}
