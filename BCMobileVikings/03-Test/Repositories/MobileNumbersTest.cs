using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Schema.Repositories;
using DTO = MobileVikings.BackEnd.Schema.DTO;
using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Test.Repositories
{
    /// <remarks/>
    [TestClass]
    public class MobileNumbersTest : RepositoryTest
    {
        private IMobileNumbers _repository;

        /// <remarks/>
        [TestInitialize]
        public void Initialize()
        {
              _repository = new MobileNumbers();
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetAll_WhenCalled_ReturnsListOfMobileNumbers()
        {
            IEnumerable<DTO.MobileNumber> mobileNumbers = await _repository.GetAll();

            Assert.IsNotNull(mobileNumbers);
            Assert.IsTrue(mobileNumbers.Any());
        }

        /// <remarks/>
        [TestMethod]
        public async Task GetAll_WhenCalled_ReturnsCorrectNumbers()
        {
            var mobileNumbers = await _repository.GetAll();

            DTO.MobileNumber mobileNumber = mobileNumbers.First();

            Assert.AreEqual(Properties.MobileNumber, mobileNumber.Number);
        }

        /// <remarks/>
        [TestMethod]
        public async Task IsMobileViking_WhenCalledWithMV_ReturnsTrue()
        {
            var result = await _repository.IsMobileViking(Properties.LocalMobileNumber);
            Assert.IsTrue(result);
        }

        /// <remarks/>
        [TestMethod]
        public async Task IsMobileViking_WhenCalledWithIncorrectMV_ReturnsFalse()
        {
            var result = await _repository.IsMobileViking("0491221212");
            Assert.IsFalse(result);
        }

        /// <remarks/>
        [TestMethod]
        public async Task IsMobileViking_WhenCalledWithWrongNumber_ReturnsFalse()
        {
            var result = await _repository.IsMobileViking("13256");
            Assert.IsFalse(result);
        }

        /// <remarks/>
        [TestMethod]
        public void EmptyJsonArray_Deserialized_ReturnsEmptyList()
        {
            const string json = "[]";
            var deserializedResult = JsonConvert.DeserializeObject<List<DTO.MobileNumber>>(json);


            Assert.IsNotNull(deserializedResult);
            Assert.IsFalse(deserializedResult.Any());
        }
    }
}