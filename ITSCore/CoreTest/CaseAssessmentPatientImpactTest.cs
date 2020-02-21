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
    public class CaseAssessmentPatientImpactTest
    {
        private ICaseAssessmentPatientImpactRepository repo;

        [TestInitialize()]
        public void CaseInit()
        {
            repo = new CaseAssessmentPatientImpactRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }



        [TestMethod]
        public void AddCaseAssessmentPatientImpact()
        {
            ICaseAssessmentPatientImpact objBL = new CaseAssessmentPatientImpactImpl(repo);

            CaseAssessmentPatientImpact obj = new CaseAssessmentPatientImpact();
            obj.CaseAssessmentDetailID = 12;
            obj.Comment = "TestCase";
            obj.PatientImpactID = 3;
            obj.PatientImpactValueID = 2;
            
            var result = objBL.AddCaseAssessmentPatientImpact(obj);
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID()
        {
            ICaseAssessmentPatientImpact objBL = new CaseAssessmentPatientImpactImpl(repo);

            CaseAssessmentPatientImpact obj= objBL.GetAllCaseAssessmentPatientImpacts().Last();
           
            obj.CaseAssessmentDetailID =12;
            obj.Comment = "Update";
            obj.PatientImpactID = 3;
            obj.PatientImpactValueID = 2;
            var result = objBL.UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(obj);
            Assert.IsTrue(result > 0);
        }

       

        [TestMethod]
        public void GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID()
        {
            ICaseAssessmentPatientImpact objBL = new CaseAssessmentPatientImpactImpl(repo);
            IEnumerable<CaseAssessmentPatientImpact> result = objBL.GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(12);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCaseAssessmentPatientImpactsByPatientImpactID()
        {
            ICaseAssessmentPatientImpact objBL = new CaseAssessmentPatientImpactImpl(repo);
            IEnumerable<CaseAssessmentPatientImpact> result = objBL.GetCaseAssessmentPatientImpactsByPatientImpactID(3);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCaseAssessmentPatientImpactsByPatientImpactValueID()
        {
            ICaseAssessmentPatientImpact objBL = new CaseAssessmentPatientImpactImpl(repo);
            IEnumerable<CaseAssessmentPatientImpact> result = objBL.GetCaseAssessmentPatientImpactsByPatientImpactValueID(2);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetAllCaseAssessmentPatientImpacts()
        {
            ICaseAssessmentPatientImpact objBL = new CaseAssessmentPatientImpactImpl(repo);
            IEnumerable<CaseAssessmentPatientImpact> result = objBL.GetAllCaseAssessmentPatientImpacts().ToList();
            Assert.IsTrue(result.Any());
        }










    }

}
