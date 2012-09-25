using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class RssTest
    {
        private IRss _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new Rss();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetLatestNews_WhenCalled_ReturnsLatestNews()
        {
            var result = await _repository.GetLatestNews();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}
