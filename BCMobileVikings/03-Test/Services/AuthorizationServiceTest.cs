using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Services;
using MobileVikings.BackEnd.Schema.Services;

namespace MobileVikings.BackEnd.Test.Services
{
    /// <remarks/>
    [TestClass]
    public class AuthorizationServiceTest
    {

        private IAuthorizationService _authorizationService;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
            _authorizationService = new AuthorizationService();
        }

        /// <remarks/>
        [TestMethod]
        public async Task SignIn_WhenCalledWithCorrectCredentials_ReturnsTrue()
        {
           var signedIn = await _authorizationService.SignIn(Properties.UserName, Properties.Password);

            Assert.IsTrue(signedIn);
        }

        /// <remarks/>
        [TestMethod]
        public async Task SignIn_WhenCalledWithWrongCredentials_ReturnsFalse()
        {
            var signedIn = await _authorizationService.SignIn(" ", " ");

            Assert.IsFalse(signedIn);
        }

    }
}
