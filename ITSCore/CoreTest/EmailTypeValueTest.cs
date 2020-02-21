using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class EmailTypeValueTest
    {
        

        IEmailTypeValueRepository _emailTypeValueRepository;


        public EmailTypeValueTest()
        {

        }

        [TestInitialize()]
        public void EmailTypeValueInit()
        {
            _emailTypeValueRepository = new EmailTypeValueRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            
        }

        [TestMethod]
        public void GetAllEmailTypeValues()
        {
            var result = _emailTypeValueRepository.GetAllEmailTypeValue();
            Assert.IsTrue(result.Any(), "Error in getting Data");
        }
    }
}
