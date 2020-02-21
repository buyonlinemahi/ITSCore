using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class SupplierInsuranceSupplierDocumentTest
    {
        [TestMethod]
        public void GetSupplierInsuranceSupplierDocumentBySupplierIDTest()
        {
            ISupplierInsuranceSupplierDocument service = new SupplierInsuranceSupplierDocumentImpl(new SupplierInsuranceSupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()));
            int supplierID = 477;
            var supplierInsurance = service.GetSupplierInsuranceSupplierDocumentBySupplierID(supplierID).ToList();
            Assert.IsTrue(supplierInsurance.Any());

        }
    }
}
