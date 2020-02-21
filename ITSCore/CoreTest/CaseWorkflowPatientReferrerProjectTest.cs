using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


#region Comment
/*
 Page Name:  CaseWorkflowPatientReferrerProjectTest.cs                   
 Latest Version:  1.0
 Author : Robin Singh
 
*/
#endregion


namespace CoreTest
{


    [TestClass]
    public class CaseWorkflowPatientReferrerProjectTest
    {

        ICaseWorkflowPatientReferrerProjectRepository _caseWorkflowPatientReferrerProjectRepository;

        public CaseWorkflowPatientReferrerProjectTest()
        {
        }

        [TestInitialize()]
        public void CaseWorkflowPatientReferrerProjectInit()
        {
            _caseWorkflowPatientReferrerProjectRepository = new CaseWorkflowPatientReferrerProjectRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }
        [TestMethod]

        public void GetReferralCases()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetReferralCases(0, 10);
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }

        [TestMethod]

        public void GetReferralCasesByTreatmentCategoryID()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetReferralCasesByTreatmentCategoryID(3, 0, 1);
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }

        [TestMethod]

        public void GetInitialAssessmentQACaseWorkflowPatientProjects()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetInitialAssessmentQACaseWorkflowPatientProjects(0, 10).ToList();
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }
        [TestMethod]

        public void GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(3, 0, 1);
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }
        [TestMethod]

        public void GetAuthorisationCaseWorkflowPatientProjects()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetAuthorisationCaseWorkflowPatientProjects(0, 10).ToList();
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }
        [TestMethod]

        public void GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryID()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryID(3, 0, 1);
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }

        [TestMethod]

        public void GetReviewAssessmentQACaseWorkflowPatientProjects()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetReviewAssessmentQACaseWorkflowPatientProjects(1, 1);
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }

        [TestMethod]

        public void GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(3, 0, 1);
            Assert.IsTrue(_caseWorkflowPatientReferrerProject.Any());
        }

        [TestMethod]
        public void GetAuthorisationCaseWorkflowPatientProjects_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetAuthorisationCaseWorkflowPatientProjects(1, 2);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate));

        }

        [TestMethod]
        public void GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryID_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            int treatmentCategoryID = 1;
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryID(
                    treatmentCategoryID, 2, 1);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate));
        }

        [TestMethod]
        public void GetReviewAssessmentQACaseWorkflowPatientProjects_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetReviewAssessmentQACaseWorkflowPatientProjects(2, 1);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate));
        }

        [TestMethod]
        public void GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            int treatmentCategoryID = 1;
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(
                    treatmentCategoryID, 1, 1);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate));
        }


        [TestMethod]
        public void GetCaseStoppedCaseWorkflowPatientProjects_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetCaseStoppedCaseWorkflowPatientProjects(2, 1);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseStopped));
        }

        [TestMethod]
        public void GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryID_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            int treatmentCategoryID = 1;
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryID(
                    treatmentCategoryID, 2, 1);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseStopped));
        }

        [TestMethod]
        public void GetFinalAssessmentCaseWorkflowPatientProjects_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetFinalAssessmentCaseWorkflowPatientProjects(0, 10).ToList();

           /* var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate));*/
        }

        [TestMethod]
        public void GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryID_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);

            int treatmentCategoryID = 1;
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject =
                caseWorkflowPatientReferrerProject.GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryID(
                    treatmentCategoryID, 2, 1);

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate));
        }

        [TestMethod]
        public void GetCaseReferralWorkflowPatientReferrerProjectsCount_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            int _CountscaseWorkflowPatientReferrerProjectResult = caseWorkflowPatientReferrerProject.GetCaseReferralWorkflowPatientReferrerProjectsCount();
            Assert.IsTrue(_CountscaseWorkflowPatientReferrerProjectResult != 0, "Error in Count !!!");
        }

        [TestMethod]
        public void GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            int _CountscaseWorkflowPatientReferrerProjectResult = caseWorkflowPatientReferrerProject.GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount(1);
            Assert.IsTrue(_CountscaseWorkflowPatientReferrerProjectResult != 0, "Error in Count !!!");
        }

        [TestMethod]
        public void GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            //int inalAssessmentCaseWorkflowPatientProjectCount = caseWorkflowPatientReferrerProject.GetInitialAssessmentQACaseWorkflowPatientProjectsCount();
            //int inalAssessmentCaseWorkflowPatientProjectCountbyTreatmentCategoryID = caseWorkflowPatientReferrerProject.GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(1);
            // int AuthorisationCaseWorkflowPatientProjectcount= caseWorkflowPatientReferrerProject.GetAuthorisationCaseWorkflowPatientProjectsCount();
            //int AuthorisationCaseWorkflowPatientProjectcountByTreatmentCategoryID = caseWorkflowPatientReferrerProject.GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(1);
            //int ReviewAssessmentQACaseWorkflowPatientProjectCount= caseWorkflowPatientReferrerProject.GetReviewAssessmentQACaseWorkflowPatientProjectsCount(); 
            //int ReviewAssessmentQACaseWorkflowPatientProjectCountByTreatmentCategoryID= caseWorkflowPatientReferrerProject.GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(1 );
            //int CaseStoppedCaseWorkflowPatientProjectCount= caseWorkflowPatientReferrerProject.GetCaseStoppedCaseWorkflowPatientProjectsCount();
            //int CaseStoppedCaseWorkflowPatientProjectCountByTreatmentCategoryID = caseWorkflowPatientReferrerProject.GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(1);
          //  int FinalAssessmentCaseWorkflowPatientProjectCount = caseWorkflowPatientReferrerProject.GetFinalAssessmentCaseWorkflowPatientProjectsCount();
           // int FinalAssessmentCaseWorkflowPatientProjectCountByTreatmentCategoryID = caseWorkflowPatientReferrerProject.GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(1);
            int TriageAssessmentCaseWorkflowPatientProjectCount= caseWorkflowPatientReferrerProject.GetTriageAssessmentQACaseWorkflowPatientProjectsCount();
            int TriageAssessmentCaseWorkflowPatientProjectCountByTreatmentCategoryID = caseWorkflowPatientReferrerProject.GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(2);
          
            Assert.IsTrue(TriageAssessmentCaseWorkflowPatientProjectCount >= 0, "Error in Count !!!");
        }

        [TestMethod]

        public void GetTriageAssessmentQACaseWorkflowPatientProjects_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetTriageAssessmentQACaseWorkflowPatientProjects(1, 1);
           

            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate));
        }
        [TestMethod]

        public void GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID_BL_Test()
        {
            ICaseWorkflowPatientReferrerProject caseWorkflowPatientReferrerProject = new CaseWorkflowPatientReferrerProjectImpl(_caseWorkflowPatientReferrerProjectRepository);
            IEnumerable<CaseWorkflowPatientReferrerProject> _caseWorkflowPatientReferrerProject = caseWorkflowPatientReferrerProject.GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(3, 0, 3);
            var cases = _caseWorkflowPatientReferrerProject.ToList();

            Assert.IsTrue(cases.Any());
            Assert.IsFalse(
                cases.Any(
                    c =>
                    c.WorkflowID != ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate));
        }

    }
}
