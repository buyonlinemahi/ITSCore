using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CoreTest
{
    [TestClass]
    public class UKPostCodeTest
    {
        [TestMethod]
        public void get_postcode_info()
        {
            IUKPostCodeRepository postCodeRepository = new UKPostCodeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            UKPostCode postCode = postCodeRepository.GetPostCodeInfo("M1 2HY");
            Assert.IsTrue(!string.IsNullOrEmpty(postCode.PostCode));
            Assert.AreEqual("M1 2HY", postCode.PostCode, "post code repository didn't return the expected value");
        }
    }
}
