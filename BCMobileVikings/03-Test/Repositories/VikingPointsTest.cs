using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class VikingPointsTest : RepositoryTest
    {

        private IVikingPoints _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new VikingPoints();
        }

        /// <remarks/>
        [TestMethod]
        public async Task Get_WhenCalled_ReturnsVikingPoint ()
        {
            var vikingPoint = await _repository.GetVikingPoints();

            Assert.IsNotNull(vikingPoint);
            Assert.IsTrue(vikingPoint.EarnedPoints >= 0);
            Assert.IsTrue(vikingPoint.TopUpsUsed >= 0);

        }

    }
}
