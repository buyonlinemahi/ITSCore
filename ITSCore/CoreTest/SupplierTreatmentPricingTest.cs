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
    public class SupplierTreatmentPricingTest
    {

        ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;
        public SupplierTreatmentPricingTest()
        {
        }

        [TestInitialize()]
        public void SupplierTreatmentPricingInit()
        {
            _supplierTreatmentPricingRepository = new SupplierTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void Add_SupplierTreatmentPricing()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            SupplierTreatmentPricing _SupplierTreatmentPricingObj = new SupplierTreatmentPricing();
            _SupplierTreatmentPricingObj.PricingTypeID = 1;
            _SupplierTreatmentPricingObj.Price = 22.23m;
            _SupplierTreatmentPricingObj.SupplierTreatmentID = 44;

            int _SupplierPricingResult = supplierTreatmentPricingService.AddSupplierTreatmentPricing(_SupplierTreatmentPricingObj);
            Assert.IsTrue(_SupplierPricingResult != 0, "Error in inserting SupplierTreatment Pricing!!!");
        }

        [TestMethod]
        public void Update_SupplierTreatmentPricingByPricingID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            SupplierTreatmentPricing _SupplierTreatmentPricingObj = new SupplierTreatmentPricing();
            _SupplierTreatmentPricingObj.PricingTypeID = 3;
            _SupplierTreatmentPricingObj.Price = 999.3m;
            _SupplierTreatmentPricingObj.PricingID = 2586;

            int _SupplierPricingResult = supplierTreatmentPricingService.UpdateSupplierTreatmentPricingByPricingID(_SupplierTreatmentPricingObj);
            Assert.IsTrue(_SupplierPricingResult != 0, "Error in Updating the SupplierTreatment Pricing !!!");
        }

        [TestMethod]
        public void Get_SupplierTreatmentPricingByPricing()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierTreatmentPricing> _SupplierPricingResult = supplierTreatmentPricingService.GetSupplierTreatmentPricingBySupplierTreatmentId(1261);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }

        [TestMethod]
        public void Get_TriageSuppliersTreamentPricingByTreatmentCategoryID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> _SupplierPricingResult = supplierTreatmentPricingService.GetTriageSuppliersTreamentPricingByTreatmentCategoryID(1);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }

        [TestMethod]
        public void Get_SuppliersTreamentPricingByTreatmentCategoryID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricingResult> _SupplierPricingResult = supplierTreatmentPricingService.GetSuppliersTreamentPricingByTreatmentCategoryID(1);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }

        [TestMethod]
        public void Get_TriageTopSuppliersTreamentPricingByTreatmentCategoryID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> _SupplierPricingResult = supplierTreatmentPricingService.GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID(1);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }


        [TestMethod]
        public void Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierTreatmentPricing> _SupplierPricingResult = supplierTreatmentPricingService.GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID(1, 320);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }

        [TestMethod]
        public void Get_SupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierPricingValue> _SupplierPricingResult = supplierTreatmentPricingService.GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(81, 1);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }
        [TestMethod]
        public void Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID()
        {
            ISupplierTreatmentPricing supplierTreatmentPricingService = new SupplierTreatmentPricingImpl(_supplierTreatmentPricingRepository);
            IEnumerable<SupplierPricingValue> _SupplierPricingResult = supplierTreatmentPricingService.GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID(320, 1, 3);
            Assert.IsTrue(_SupplierPricingResult.Any());
        }
    }
}
