using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class CaseWorkflowCountTest
    {
        private ICaseWorkflowCountRepository _caseWorkflowCountRepository;
                
        [TestInitialize]
        public void Initialize()
        {
            _caseWorkflowCountRepository = new CaseWorkflowCountRepository(
                    new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void BL_RetrievingCaseWorkflowCount_Test()
        {
            ICaseWorkflowCount service = new CaseWorkflowCountImpl(_caseWorkflowCountRepository);
            var ret = service.GetCaseCounts();
            Assert.IsTrue(ret.Any());
        }

        [TestMethod]
        public void BL_GetCaseCountByTreatmentCategoryID_Test()
        {
            ICaseWorkflowCount service = new CaseWorkflowCountImpl(_caseWorkflowCountRepository);
            var ret = service.GetCaseCountByTreatmentCategoryID(2);
            Assert.IsTrue(ret.Any());
          
        }


    }
}
