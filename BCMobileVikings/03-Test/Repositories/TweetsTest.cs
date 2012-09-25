using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class TweetsTest
    {
        private ITweets _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _repository = new Tweets();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetLatestTweets_WhenCalled_ReturnsLatestTweets()
        {
            if (await _repository.Initialize())
            {
                var result = await _repository.GetLatestTweets();

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Any());
            }
        }
    }
}
