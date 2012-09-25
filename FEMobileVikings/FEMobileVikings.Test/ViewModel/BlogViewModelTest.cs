using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace FEMobileVikings.Test.ViewModel
{
    [TestClass]
    public class BlogViewModelTest
    {

        [TestMethod]
        public void Constructor_WhenCalled_RetrievesRssItems()
        {

        }

        [TestMethod]
        public void Constructor_WhenCalledWithNullIRss_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>{});
        }

    }
}
