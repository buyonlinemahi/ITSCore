using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{

    [TestClass]
    public class EmailSendingOptionTest
    {

        IEmailSendingOptionRepository _emailSendingOptionRepository;
        public EmailSendingOptionTest()
        {
        }

        [TestInitialize()]
        public void EmailSendingOptionInit()
        {
            _emailSendingOptionRepository = new EmailSendingOptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAllEmailSendingOption()
        {
            IEnumerable<EmailSendingOption> _emailSendingOption = _emailSendingOptionRepository.GetAll();
            Assert.IsTrue(_emailSendingOption.Any());
        }

    }

}