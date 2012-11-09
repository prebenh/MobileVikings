using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Implementation.Services;

namespace MobileVikings.BackEnd.Test.Services
{
    /// <remarks/>
    [TestClass]
    public class RssServiceTest
    {
        private RssService _rssService2;

        [TestInitialize]
        public void Initialize()
        {
            _rssService2 = new RssService();
        }

        [TestMethod]
        public async Task GetRssItems_WhenCalled_ReturnsRssItems()
        {
            var rssItems = await _rssService2.GetRssItems();
            Assert.IsNotNull(rssItems);
            Assert.IsTrue(rssItems.Any());

            var firstItem = rssItems.First();
            Assert.IsFalse(string.IsNullOrEmpty(firstItem.Description));
            Assert.IsFalse(string.IsNullOrEmpty(firstItem.Link));
            Assert.IsFalse(string.IsNullOrEmpty(firstItem.Title));
            Assert.IsFalse(string.IsNullOrEmpty(firstItem.ImageLink));
            Assert.IsNotNull(firstItem.Date);
        }
    }
}
