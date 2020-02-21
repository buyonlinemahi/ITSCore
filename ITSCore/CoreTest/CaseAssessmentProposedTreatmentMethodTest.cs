using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class CaseAssessmentProposedTreatmentMethodTest
    {
        private ICaseAssessmentProposedTreatmentMethodRepository DL;
        // protected ICaseAssessmentProposedTreatmentMethod BL;

        [TestInitialize()]
        public void CaseAssessmentProposedTreatmentMethodInit()
        {
            DL = new CaseAssessmentProposedTreatmentMethodRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //    BL = new CaseAssessmentProposedTreatmentMethodImpl(DL);
        }

        [TestMethod]
        public void AddCaseAssessmentProposedTreatmentMethod()
        {
            int result = DL.AddCaseAssessmentProposedTreatmentMethod(117, 7);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteCaseAssessmentProposedTreatmentMethodByCaseID()
        {
            int result = DL.DeleteCaseAssessmentProposedTreatmentMethodByCaseID(117);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID()
        {
            int result = DL.UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID(870,1,System.DateTime.Now);
            Assert.IsTrue(result > 0);
        }
    }
}