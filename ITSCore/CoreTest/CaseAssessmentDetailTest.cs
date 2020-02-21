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
    public class CaseAssessmentDetailTest
    {
        private ICaseAssessmentDetailRepository DL;
        private ICaseAssessmentDetailHistoryRepository HistoryDL;
        protected ICaseAssessmentDetail BL;
        protected ICaseRepository CaseDL;

        [TestInitialize()]
        public void CaseAssessmentDetailInit()
        {
            DL = new CaseAssessmentDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            HistoryDL = new CaseAssessmentDetailHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            CaseDL = new CaseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            BL = new CaseAssessmentDetailImpl(DL, HistoryDL, CaseDL);
        }

        [TestMethod]
        public void GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID()
        {
            IEnumerable<CaseAssessmentDetail> CaseAssessmentDetailobj = DL.GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID(816, 1);
            Assert.IsTrue(CaseAssessmentDetailobj != null, "No data Available");
        }






        [TestMethod]
        public void GetCaseAssessmentDetailByCaseAssessmentDetailID()
        {
            CaseAssessmentDetail CaseAssessmentDetailobj = DL.GetCaseAssessmentDetailByCaseAssessmentDetailID(77);
            Assert.IsTrue(CaseAssessmentDetailobj != null, "No data Available");
        }

        [TestMethod]
        public void GetCaseAssessmentDetailsByCaseID()
        {
            IEnumerable<CaseAssessmentDetail> CaseAssessmentDetailobj = BL.GetAllCaseAssessmentDetailByCaseID(2180);
            Assert.IsTrue(CaseAssessmentDetailobj != null, "No data Available");
        }

        [TestMethod]
        public void GetQASubmitedCaseAssessmentDetailsByCaseID()
        {
            IEnumerable<CaseAssessmentDetail> CaseAssessmentDetailobj = BL.GetQASubmitedCaseAssessmentDetailsByCaseID(345);
            Assert.IsTrue(CaseAssessmentDetailobj != null, "No data Available");
        }



        [TestMethod]
        public void AddCaseAssessmentDetailRepository()
        {
            CaseAssessmentDetail caseAssessmentDetail = new CaseAssessmentDetail();
            caseAssessmentDetail.AssessmentServiceID = 1;
            caseAssessmentDetail.CaseID = 613;
            caseAssessmentDetail.HasThePatientHadTimeOff = true;
            caseAssessmentDetail.AbsentDetail = "New";
            caseAssessmentDetail.HasThePatientReturnedToWork = true;
            caseAssessmentDetail.PatientImpactOnWorkID = 1;
            caseAssessmentDetail.PatientWorkstatusID = 1;
            caseAssessmentDetail.PatientRecommendedTreatmentSessions = 1;
            caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail = "New";
            caseAssessmentDetail.PatientTreatmentPeriod = 0;
            caseAssessmentDetail.IsFurtherTreatmentRecommended = true;
            caseAssessmentDetail.PatientLevelOfRecoveryID = 1;
            caseAssessmentDetail.SessionsPatientAttended = 1;
            caseAssessmentDetail.DatesOfSessionAttended = "Dates";
            caseAssessmentDetail.SessionsPatientFailedToAttend = 1;
            caseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID = 1;
            caseAssessmentDetail.AdditionalInformation = "test";
            caseAssessmentDetail.HasCompliedHomeExerciseProgramme = true;
            caseAssessmentDetail.EvidenceOfClinicalReasoning = "evidence";
            caseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired = false;
            caseAssessmentDetail.FurtherInvestigationOrOnwardReferral = "asdfsda";
            caseAssessmentDetail.EvidenceOfTreatmentRecommendations = "sadfdsaf";
            caseAssessmentDetail.TreatmentPeriodTypeID = 1;
            caseAssessmentDetail.PatientDateOfReturn = System.DateTime.Now;
            caseAssessmentDetail.PatientRecommendationReturn = "test recommendation text";
            caseAssessmentDetail.IsPatientReturnToPreInjuryDuties = true;
            caseAssessmentDetail.PatientPreInjuryDutiesDate = System.DateTime.Now;
            caseAssessmentDetail.MainFactors = "test main factor text";
            var result = BL.AddCaseAssessmentDetail(caseAssessmentDetail);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateCaseAssessmentDetailByCaseAssessmentDetailID()
        {
            CaseAssessmentDetail caseAssessmentDetail = new CaseAssessmentDetail();
            caseAssessmentDetail.CaseAssessmentDetailID = 2647;
            caseAssessmentDetail.AssessmentServiceID = 1; 
            caseAssessmentDetail.CaseID = 613; 
            caseAssessmentDetail.HasThePatientHadTimeOff = true;
            caseAssessmentDetail.AbsentDetail = "a";
            caseAssessmentDetail.HasThePatientReturnedToWork = false;
            caseAssessmentDetail.PatientImpactOnWorkID = 2;
            caseAssessmentDetail.PatientWorkstatusID = 2;
            caseAssessmentDetail.PatientRecommendedTreatmentSessions = 2;
            caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail = "2";
            caseAssessmentDetail.PatientTreatmentPeriod = 2;
            caseAssessmentDetail.IsFurtherTreatmentRecommended = false;
            caseAssessmentDetail.PatientLevelOfRecoveryID = 1;
            caseAssessmentDetail.SessionsPatientAttended = 0;
            caseAssessmentDetail.DatesOfSessionAttended = "a";
            caseAssessmentDetail.SessionsPatientFailedToAttend = 2;
            caseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID = 1;
            caseAssessmentDetail.AdditionalInformation = "as";
            caseAssessmentDetail.HasCompliedHomeExerciseProgramme = false;
            caseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired = false;
            caseAssessmentDetail.AbsentPeriod = 2;
            caseAssessmentDetail.AbsentPeriodDurationID = 2;
            caseAssessmentDetail.PatientTreatmentPeriodDetail = "2";
            caseAssessmentDetail.PatientTreatmentPeriodDurationID = 0;
            caseAssessmentDetail.PractitionerID = 276;
            caseAssessmentDetail.EvidenceOfClinicalReasoning = "evidence1";
            caseAssessmentDetail.TreatmentPeriodTypeID = 1;
            caseAssessmentDetail.PatientDateOfReturn = System.DateTime.Now;
            caseAssessmentDetail.PatientRecommendationReturn = "test recommendation text";
            caseAssessmentDetail.IsPatientReturnToPreInjuryDuties = true;
            caseAssessmentDetail.PatientPreInjuryDutiesDate = System.DateTime.Now;
            caseAssessmentDetail.MainFactors = "test main factor text";

            var result = DL.UpdateCaseAssessmentDetailByCaseAssessmentDetailID(caseAssessmentDetail);
            Assert.IsTrue(result > 0);

        }
    }
}