using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class SupplierClinicalAuditSupplierDocumentTest
    {
        [TestMethod]
        public void GetSupplierClinicalAuditSupplierDocumentBySupplierIDTest()
        {
            ISupplierClinicalAuditSupplierDocument service = new SupplierClinicalAuditSupplierDocumentImpl(new SupplierClinicalAuditSupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()));
            int supplierID = 21;
            var clinicalAudits = service.GetSupplierClinicalAuditSupplierDocumentBySupplierID(supplierID).ToList();
            Assert.IsTrue(clinicalAudits.Any());
            Assert.IsTrue(clinicalAudits.Single(c => c.SupplierID == 21).DocumentName == "DocumentNameTest");
            Assert.IsTrue(clinicalAudits.Single(c => c.SupplierID == 21).UploadPath == "UploadPathTest");

        }
    }
}
