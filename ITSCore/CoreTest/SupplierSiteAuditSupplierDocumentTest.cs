using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class SupplierSiteAuditSupplierDocumentTest
    {
        [TestMethod]
        public void GetSupplierSiteAuditSupplierDocumentBySupplierIDTest()
        {
            ISupplierSiteAuditSupplierDocument service = new SupplierSiteAuditSupplierDocumentImpl(new SupplierSiteAuditSupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()));
            int supplierID = 477;
            var siteAudits = service.GetSupplierSiteAuditSupplierDocumentBySupplierID(supplierID).ToList();
            Assert.IsTrue(siteAudits.Any());

        }
    }
}
