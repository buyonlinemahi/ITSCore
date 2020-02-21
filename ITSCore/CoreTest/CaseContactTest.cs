using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class CaseContactTest
    {
        private ICaseContactRepository _caseContactRepository;
                
        [TestInitialize]
        public void Initialize()
        {
            _caseContactRepository = new CaseContactRepository(
                    new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Repo_AddingCaseContact_Test()
        {
            CaseContact caseContact = new CaseContact()
                {
                    CaseID = 15,
                    UserID = 16
                };

            int ret =  _caseContactRepository.AddCaseContact(caseContact);
            Assert.IsTrue(ret > 0);
        }

        [TestMethod]
        public void Repo_RetrievingCaseContact_Test()
        {
            var ret = _caseContactRepository.GetCaseContactsByCaseID(15);
            Assert.IsTrue(ret.Any());
        }

        [TestMethod]
        public void BL_AddingCaseContact_Test()
        {
            CaseContact caseContact = new CaseContact()
            {
                CaseID = 15,
                UserID = 16
            };
            ICaseContact service = new CaseContactImpl(_caseContactRepository);
            int ret = service.AddCaseContact(caseContact);
            Assert.IsTrue(ret > 0);
        }

        [TestMethod]
        public void BL_RetrievingCaseContact_Test()
        {
            ICaseContact service = new CaseContactImpl(_caseContactRepository);
            var ret = service.GetCaseContactsByCaseID(15);
            Assert.IsTrue(ret.Any());
        }
    }
}
