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
    public class CasePatientTest
    {
        private ICasePatientRepository _CasePatientRepository;

        public CasePatientTest()
        {
        }

        [TestInitialize()]
        public void CasePatientRepositoryTestInit()
        {
            _CasePatientRepository = new CasePatientRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetBookIACasePatientByCaseIDAndWorkFlowID_Method()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            CasePatient _casePatientResult = _CasePatientBL.GetBookIACasePatientByCaseID(15);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetPatientAndCaseByCaseID()
        
        
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            CasePatientTreatment _casePatientResult = _CasePatientBL.GetPatientAndCaseByCaseID(598);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetPatientAndCaseByCaseID_To_GetTreatmentCategoryID()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            CasePatientTreatment _casePatientResult = _CasePatientBL.GetPatientAndCaseByCaseID(12);
            Assert.IsNotNull(_casePatientResult.TreatmentCategoryID);
        }

        [TestMethod]
        public void GetCaseSearchLikePatientName()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);
            IEnumerable<ReferrerSupplierCases> _casePatientResult = _CasePatientBL.GetCaseSearchLikePatientName("sing");
            Assert.IsTrue(_casePatientResult.Any());
        }

        [TestMethod]
        public void GetCaseSearchLikeReferrerReferenceNumber()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);
            IEnumerable<ReferrerSupplierCases> _casePatientResult = _CasePatientBL.GetCaseSearchLikeReferrerReferenceNumber("r");
            Assert.IsTrue(_casePatientResult.Any());
        }

        [TestMethod]
        public void Get_CasePatientLikeCaseNumber()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);
            IEnumerable<CasePatientSearch> _casePatientResult = _CasePatientBL.GetCasePatientLikeCaseNumber("76");
            Assert.IsTrue(_casePatientResult.Any());
        }

        [TestMethod]
        public void GetCasePatientReferrerByCaseID()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            CasePatientReferrer _casePatientResult = _CasePatientBL.GetCasePatientReferrerByCaseID(51);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        [TestMethod]
        public void GetCaseSearchLikePatientNameAndReferrerID()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikePatientNameAndReferrerID("AllCases","rohit", 566,498, 0, 10);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikePatientNameAndSupplierID()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikePatientNameAndSupplierID("sd", 379, 0, 1,498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikePatientNameAndSupplierIDNumberCount()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount("sd", 379, 498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikePatientNameAndReferrerIDNumberCount()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount("Active", "tree", 3, 498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikeReferrerReferenceNumberAndReferrerID()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID("Active", "ref", 488, 0, 10, 498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikeReferrerReferenceNumberAndReferrerIDNumberCount()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);
            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount("Active", "REF", 488, 498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikeCaseNumberAndSupplierID()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikeCaseNumberAndSupplierID("76", 379, 0, 10, 498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseSearchLikeCaseNumberAndSupplierIDNumberCount()
        {
            ICasePatient _CasePatientBL = new CasePatientImpl(_CasePatientRepository);

            var _casePatientResult = _CasePatientBL.GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount("76", 379, 498);
            Assert.IsTrue(_casePatientResult != null, "Error in Getting result !!!");
        }
    }
}