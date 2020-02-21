using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{
    /// <summary>
    /// Summary description for ReferrerProjectTreatmentPricingTest
    /// </summary>
    ///
    /*
     * Latest Version:1.2
 History Revision
 ==============================================================================================
 * Edited By : Satya
 * Date : 09-Nov-2012
 * Version : 1.0
 * Description : Add Test Method For ReferrerProjectTreatmentPricingTest
     ==============================================================================================
 * Edited By : Vishal
 * Date : 10-Nov-2012
 * Version : 1.1
 * Description : Change Method Name Getall to GetAll_ReferrerProjectTreatmentPricing()

 * ==============================================================================================
 * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.2
  Description : Add Method For Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
  Description : Add Method For Add_ReferrerProjectTreatmentPricing()
  Description : Add Method For Update_ReferrerProjectTreatmentPricingByPricingID()
     *
 ==============================================================================================
 */

    [TestClass]
    public class ReferrerProjectTreatmentPricingTest
    {
        private IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;

        public ReferrerProjectTreatmentPricingTest()
        {
        }

        [TestInitialize()]
        public void ReferrerProjectTreatmentPricingTestInit()
        {
            _referrerProjectTreatmentPricingRepository = new ReferrerProjectTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAll_ReferrerProjectTreatmentPricing()
        {
            IEnumerable<ReferrerProjectTreatmentPricing> referrerProjectTreatmentPricingRepository = _referrerProjectTreatmentPricingRepository.GetAll();
            Assert.IsTrue(referrerProjectTreatmentPricingRepository.Any());
        }

        [TestMethod]
        public void Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
        {
            IEnumerable<ReferrerProjectTreatmentPricing> referrerProjectTreatmentPricing = _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(8361);
            Assert.IsTrue(referrerProjectTreatmentPricing.Any());
        }

        [TestMethod]
        public void Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID()
        {
            IEnumerable<ReferrerPricingValue> referrerProjectTreatmentPricing = _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID(8361, 1);
            Assert.IsTrue(referrerProjectTreatmentPricing.Any());
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID()
        {
            var referrerProjectTreatmentPricing = _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID(8361, 1);
            Assert.IsTrue(referrerProjectTreatmentPricing != null,"Unable to find");
        }

        [TestMethod]
        public void Add_ReferrerProjectTreatmentPricing()
        {
            ReferrerProjectTreatmentPricing _ReferrerProjectTreatmentPricingObj = new ReferrerProjectTreatmentPricing();
            _ReferrerProjectTreatmentPricingObj.PricingTypeID = 4;
            _ReferrerProjectTreatmentPricingObj.Price = 75;
            _ReferrerProjectTreatmentPricingObj.ReferrerProjectTreatmentID = 4;

            int _ReferrerProjectTreatmentEmailResult = _referrerProjectTreatmentPricingRepository.AddReferrerProjectTreatmentPricing(_ReferrerProjectTreatmentPricingObj);

            Assert.IsTrue(_ReferrerProjectTreatmentEmailResult != 0, "Error in inserting ReferrerProjectTreatmentPricing !!!");
        }

        [TestMethod]
        public void Update_ReferrerProjectTreatmentPricingByPricingID()
        {
            ReferrerProjectTreatmentPricing _ReferrerProjectTreatmentPricingObj = new ReferrerProjectTreatmentPricing();
            _ReferrerProjectTreatmentPricingObj.PricingID = 11;
            _ReferrerProjectTreatmentPricingObj.PricingTypeID = 4;
            _ReferrerProjectTreatmentPricingObj.Price = 896;
            _ReferrerProjectTreatmentPricingObj.ReferrerProjectTreatmentID = 6;
            int _ReferrerProjectTreatmentEmailResult = _referrerProjectTreatmentPricingRepository.UpdateReferrerProjectTreatmentPricingByPricingID(_ReferrerProjectTreatmentPricingObj);

            Assert.IsTrue(_ReferrerProjectTreatmentEmailResult != 0, "Error in updating ReferrerProjectTreatmentPricing !!!");
        }
    }
}