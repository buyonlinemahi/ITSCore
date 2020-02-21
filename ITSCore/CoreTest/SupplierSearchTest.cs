using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace CoreTest
{
    [TestClass]
    public class SupplierSearchTest
    {

        ISupplierSearchRepository _supplierSearchRepository;


        public SupplierSearchTest()
        {
        }

        [TestInitialize()]
        public void SupplierSearchInit()
        {
            _supplierSearchRepository = new SupplierSearchRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }



        [TestMethod]
        public void GetSuppliersLikeSupplierName()
        {
            ISupplierSearch supplierSearchService = new SupplierSearchImpl(_supplierSearchRepository);
            var _supplierSearchService = supplierSearchService.GetSuppliersLikeSupplierName("32",0,2);
            Assert.IsTrue(_supplierSearchService.Any());

        }


        [TestMethod]
        public void Get_SuppliersLikeSupplierNameCount()
        {
            ISupplierSearch supplierSearchService = new SupplierSearchImpl(_supplierSearchRepository);
            var _supplierSearchService = supplierSearchService.GetSuppliersLikeSupplierNameCount("2");
            Assert.IsTrue(_supplierSearchService!=0);

        }


        [TestMethod]
        public void GetSuppliersLikePostCode()
        {
            ISupplierSearch supplierSearchService = new SupplierSearchImpl(_supplierSearchRepository);
            var _supplierSearchService = supplierSearchService.GetSuppliersLikePostCode("AB",2,10);
            Assert.IsTrue(_supplierSearchService.Any());
        }

        [TestMethod]
        public void Get_SuppliersLikePostCodeCount()
        {
            ISupplierSearch supplierSearchService = new SupplierSearchImpl(_supplierSearchRepository);
            int _supplierSearchService = supplierSearchService.GetSuppliersLikePostCodeCount("AB");
            Assert.IsTrue(_supplierSearchService!=0);
        }

        [TestMethod]
        public void Get_SupplierLikeTreatmentCategoryType()
        {
            ISupplierSearch supplierSearchService = new SupplierSearchImpl(_supplierSearchRepository);
            var _supplierSearchService = supplierSearchService.GetSupplierLikeTreatmentCategoryType("phy", 0, 2);
            Assert.IsTrue(_supplierSearchService.Any());
        }

        [TestMethod]
        public void Get_SupplierLikeTreatmentCategoryTypeCount()
        {
            ISupplierSearch supplierSearchService = new SupplierSearchImpl(_supplierSearchRepository);
            int _supplierSearchService = supplierSearchService.GetSupplierLikeTreatmentCategoryTypeCount("phy");
            Assert.IsTrue(_supplierSearchService != 0);
        }

    }
}
