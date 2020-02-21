using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreTest
{
    [TestClass]
    public class CasePatientTreatmentWorkflowTest
    {

        private ICasePatientTreatmentWorkflowRepository DL;
        private ICasePatientTreatmentWorkflow BL;


        [TestInitialize()]
        public void CaseAssessmentDetailInit()
        {
            DL = new CasePatientTreatmentWorkflowRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            BL = new CasePatientTreatmentWorkflowImpl(DL);
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikePostCode()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikePostCode("Active","AB10 1AB", 0, 4);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikePostCodeCount()
        {
           int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikePostCodeCount("Active","AB10 1AB");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeCaseNumber()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeCaseNumber("Active", "76A31231-9741-4676-9159-9D5ACE9584DE", 0, 4);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeCaseNumberCount()
        {
            int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeCaseNumberCount("Active", "76A31231-9741-4676-9159-9D5ACE9584DE");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }


        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikePatientName()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikePatientName("Active", "p", 0, 4);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikePatientNameCount()
        {
            int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikePatientNameCount("Active", "p");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }


        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeReferrerName()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeReferrerName("Active", "p", 0, 3);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeReferrerNameCount()
        {
            int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeReferrerNameCount("Active", "p");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }


        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber("Active", "REF1002", 0, 3);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount()
        {
            int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount("Active", "REF1002");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName("Active", "p", 0, 3);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount()
        {
            int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount("Active", "p");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeTreatmentTypeName()
        {
            IEnumerable<CasePatientTreatmentWorkflow> casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeTreatmentTypeName("Active", "p", 0, 3);
            Assert.IsTrue(casePatientTreatmentWorkflowobj != null, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount()
        {
            int casePatientTreatmentWorkflowobj = BL.GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount("Active", "p");
            Assert.IsTrue(casePatientTreatmentWorkflowobj != 0, "No data Available");
        }

        [TestMethod]
        public void Test_GetCasePatientReferrerSupplierWorkflowByCaseID()
        {
            var CasePatientReferrerSupplierWorkflowBy = BL.GetCasePatientReferrerSupplierWorkflowByCaseID(1036);
            Assert.IsTrue(CasePatientReferrerSupplierWorkflowBy != null, "NO data Available");
        }
    }
}