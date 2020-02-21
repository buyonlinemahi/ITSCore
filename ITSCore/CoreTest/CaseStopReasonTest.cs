using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;



namespace CoreTest
{
    [TestClass]
   public class CaseStopReasonTest
    {

         ICaseStopReasonRepository _caseStopReasonRepository;
         public CaseStopReasonTest()
        {
        }

        [TestInitialize()]
         public void CaseStopReasonRepositoryTestInit()
        {
            _caseStopReasonRepository = new CaseStopReasonRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetCaseStopReasonService_Method()
        {
            ICaseStopReason casePatientSupplierPractitionerTestRepository = new CaseStopReasonImpl(_caseStopReasonRepository);
            IEnumerable<CaseStopReason> CaseStopReasonRepository = casePatientSupplierPractitionerTestRepository.GetAllCaseStopReason();
            Assert.IsTrue(CaseStopReasonRepository.Any());
        }
    }
}
