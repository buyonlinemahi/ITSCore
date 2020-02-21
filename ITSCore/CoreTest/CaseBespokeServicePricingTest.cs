using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class CaseBespokeServicePricingTest
    {

        private ICaseBespokeServicePricingRepository _caseBespokeServicePricingRepository;

        [TestInitialize]
        public void Initialize()
        {
            _caseBespokeServicePricingRepository = new CaseBespokeServicePricingRepository(
                    new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddCaseBespokeServicePricingTest()
        {
            List<CaseBespokeServicePricing> caseBespokeServicePricings = new List<CaseBespokeServicePricing>();

            caseBespokeServicePricings.Add(new CaseBespokeServicePricing
            {
                CaseID = 51,
                TreatmentCategoryBespokeServiceID = 1,
                ReferrerPrice = 12344,
                SupplierPrice = 1034,
                DateOfService = null,
                PatientDidNotAttend = null,
                WasAbandoned = null,
            });

            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
            int ret = service.AddCaseBespokeServicePricing(caseBespokeServicePricings.AsEnumerable());
            Assert.IsTrue(ret > 0);
        }



        [TestMethod]
        public void GetCaseBespokeServicePricingByCaseIDTest()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
            IEnumerable<CaseBespokeServicePricing> result = service.GetCaseBespokeServicePricingByCaseID(44);
            Assert.IsTrue(result.Any());

        }

        [TestMethod]
        public void Update_CaseBespokeServicePricingByCaseTreatmentPricingID()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
            CaseBespokeServicePricing obj = new CaseBespokeServicePricing()
            {

                CaseBespokeServiceID = 7,
                DateOfService = DateTime.Now,
                //PatientDidNotAttend = true,
                WasAbandoned = false,
            };


            var result = service.UpdateCaseBespokeServicePricingByCaseBespokeServiceID(obj);
            Assert.IsTrue(result > 0);
        }


        [TestMethod]
        public void UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);  
            var result = service.UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID(17,54);
            Assert.IsTrue(result > 0);
        }




        [TestMethod]
        public void Delete_CaseBespokeServiceByCaseBespokeServiceID()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
           
            var result = service.DeleteCaseBespokeServiceByCaseBespokeServiceID(7);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GeBespokeTreatmentPricingsForInvoice()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
            IEnumerable<CaseBespokeServicePricingType> result = service.GetCaseBespokeServicePricingForInvoice(186);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCaseBespokeServicePricingByCaseIDAndComplete()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
            IEnumerable<CaseBespokeServicePricingType> result = service.GetCaseBespokeServicePricingByCaseIDAndComplete(186);
            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void GetCaseBespokeServicePricingByCaseIDAndInComplete()
        {
            ICaseBespokeServicePricing service = new CaseBespokeServicePricingImpl(_caseBespokeServicePricingRepository);
            IEnumerable<CaseBespokeServicePricingType> result = service.GetCaseBespokeServicePricingByCaseIDAndInComplete(186);
            Assert.IsTrue(result.Any());
        }
    }
}
