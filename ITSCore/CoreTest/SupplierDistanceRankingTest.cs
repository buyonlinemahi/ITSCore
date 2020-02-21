using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class SupplierDistanceRankingTest
    {
        ISupplierDistanceRankingRepository _supplierDistanceRepository;
        [TestInitialize()]
        public void SupplierSearchInit()
        {
            _supplierDistanceRepository = new SupplierDistanceRankingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void get_supplier_within_area()
        {
            //test radianslatitude and radianslongitude
            //0.932171993363054
            //-0.0377708797819195
            var suppliers = _supplierDistanceRepository.GetSupplierWithinArea(0.997424862453462, -0.0365934108553541, 100, 1);
            Assert.IsTrue(suppliers.Count() != 0, "no suppliers found within the given coordinates");
        }




    }
}
