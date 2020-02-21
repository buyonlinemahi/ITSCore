using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class CaseAssessmentProposedTreatmentMethodHistoryTest
    {

        private ICaseAssessmentProposedTreatmentMethodHistoryRepository DL;
        //protected ICaseAssessmentProposedTreatmentMethodHistory BL;

        [TestInitialize()]
        public void CaseAssessmentProposedTreatmentMethodHistoryInit()
        {
            DL = new CaseAssessmentProposedTreatmentMethodHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
           // BL = new CaseAssessmentProposedTreatmentMethodHistoryImpl(DL);

        }



        [TestMethod]
        public void AddCaseAssessmentProposedTreatmentMethodHistory()
        {
            CaseAssessmentProposedTreatmentMethodHistory _CaseAssessmentProposedTreatmentMethodHistoryObj = new CaseAssessmentProposedTreatmentMethodHistory();
            _CaseAssessmentProposedTreatmentMethodHistoryObj.CaseAssessmentHistoryID = 85;
            _CaseAssessmentProposedTreatmentMethodHistoryObj.ProposedTreatmentMethodID = 7;
            _CaseAssessmentProposedTreatmentMethodHistoryObj.CaseID = 117;

            int result = DL.AddCaseAssessmentProposedTreatmentMethodHistory(_CaseAssessmentProposedTreatmentMethodHistoryObj);
              Assert.IsTrue(result > 0);
        }


    }
}