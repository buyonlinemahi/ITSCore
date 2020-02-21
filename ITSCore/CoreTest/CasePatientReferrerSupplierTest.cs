using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class CasePatientReferrerSupplierTest
    {
        ICasePatientReferrerSupplierRepository _casePatientReferrerSupplierRepository;

        [TestInitialize]
        public void CasePatientReferrerSupplierInit()
        {
            _casePatientReferrerSupplierRepository = new CasePatientReferrerSupplierRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITSDBContext>());
        }

        [TestMethod]
        public void GetCasePatientReferrerSupplierByCaseID()
        {
            ICasePatientReferrerSupplier casePatientReferrerSupplierobj = new CasePatientReferrerSupplierImpl(_casePatientReferrerSupplierRepository);
            CasePatientReferrerSupplier casePatientReferrerSupplier = casePatientReferrerSupplierobj.GetCasePatientReferrerSupplierByCaseID(12);
            Assert.IsTrue(casePatientReferrerSupplier != null, "unable to get CasePatientReferrerSupplier");
        }
    }
}
