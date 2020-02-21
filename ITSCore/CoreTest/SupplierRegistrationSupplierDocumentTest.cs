using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class SupplierRegistrationSupplierDocumentTest
    {
        [TestMethod]
        public void GetSupplierRegistrationSupplierDocumentBySupplierIDTest()
        {
            ISupplierRegistrationSupplierDocument service = new SupplierRegistrationSupplierDocumentImpl(new SupplierRegistrationSupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()));
            int supplierID = 476;
            var supplierRegistration = service.GetSupplierRegistrationSupplierDocumentBySupplierID(supplierID).ToList();
            Assert.IsTrue(supplierRegistration.Any());

        }
    }
}
