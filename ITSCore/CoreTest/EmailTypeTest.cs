using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{

    [TestClass]
    public class EmailTypeTest
    {

        IEmailTypeRepository _emailTypeRepository;
        public EmailTypeTest()
        {
        }

        [TestInitialize()]
        public void EmailTypeInit()
        {
            _emailTypeRepository = new EmailTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAllEmailType()
        {
            IEnumerable<EmailType> emailType = _emailTypeRepository.GetAll();
            Assert.IsTrue(emailType.Any());
        }

    }

}