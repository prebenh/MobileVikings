using System;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class RepositoryTest
    {
        /// <remarks/>
        [TestInitialize]
        public void RepositoryInitialize()
        {
            ApplicationData.Current.RoamingSettings.Values["AuthorizationInfo"] =
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture,"{0}:{1}", Properties.UserName, Properties.Password)));
        }
    }
}
