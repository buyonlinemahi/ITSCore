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
    public class CaseTreatmentPricingTest
    {

        ICaseTreatmentPricingRepository _CaseTreatmentPricingRepository;

        private ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;
        private ISupplierTreatmentRepository _supplierTreatmentRepository;
        private IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;
        private IReferrerProjectTreatmentRepository _referrerProjectTreatmentRepository;

        public CaseTreatmentPricingTest()
        {
        }

        [TestInitialize()]
        public void CaseTreatmentPricingRepositoryTestInit()
        {
            _CaseTreatmentPricingRepository = new CaseTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            _supplierTreatmentPricingRepository = new SupplierTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _supplierTreatmentRepository = new SupplierTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentPricingRepository = new ReferrerProjectTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentRepository = new ReferrerProjectTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddCaseTreatmentPricing()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            CaseTreatmentPricing obj = new CaseTreatmentPricing();

            List<CaseTreatmentPricing> objs = new List<CaseTreatmentPricing>();

            objs.Add(new CaseTreatmentPricing
            {
                CaseID = 51,
                ReferrerPricingID = 1518,
                ReferrerPrice = 55,
                DateOfService = DateTime.Now,
                PatientDidNotAttend = true,
                WasAbandoned = false,
                SupplierPrice = 10,
                SupplierPriceID = 2585,
                Quantity=2,
                PatientDidNotAttendDate=DateTime.Now

            });


            var result = objBL.AddCaseTreatmentPricing(objs);
            Assert.IsTrue(result > 0);
        }

         [TestMethod]
        public void UpdateCaseTreatmentPricing()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            CaseTreatmentPricing obj = new CaseTreatmentPricing();

            List<CaseTreatmentPricing> objs = new List<CaseTreatmentPricing>();

            objs.Add(new CaseTreatmentPricing
            {
                CaseTreatmentPricingID = 0,
                CaseID = 839,
                ReferrerPricingID = 5267,
                ReferrerPrice = 50,
                DateOfService = DateTime.Now,
                PatientDidNotAttend = true,
                WasAbandoned = false,
                SupplierPrice = 10,
                SupplierPriceID = 7917,
                IsChanged = 1,
                 PatientDidNotAttendDate=DateTime.Now
            });


            var result = objBL.UpdateCaseTreatmentPricing(objs);
            Assert.IsTrue(result > 0);
        }

        

        [TestMethod]
        public void GetCaseTreatmentPricingByCaseID()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            IEnumerable<CaseTreatmentPricing> result = objBL.GetCaseTreatmentPricingByCaseID(44);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCheckCaseTreatmentPricingByCaseID()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            var result = objBL.GetCheckCaseTreatmentPricingByCaseID(806,1);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetCaseTreatmentPricingByCaseIDAndComplete()
        {

            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            IEnumerable<CaseTreatmentPricingType> result = objBL.GetCaseTreatmentPricingByCaseIDCaseSearch(819);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCaseTreatmentPricingByCaseIDAndInComplete()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            IEnumerable<CaseTreatmentPricingType> result = objBL.GetCaseTreatmentPricingByCaseIDAndInComplete(51);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCaseTreatmentPricingsForInvoice()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            IEnumerable<CaseTreatmentPricingType> result = objBL.GetCaseTreatmentPricingsForInvoice(51);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void Update_CaseTreatmentPricingByCaseTreatmentPricingID() 
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            CaseTreatmentPricing obj = new CaseTreatmentPricing()
            {
                CaseID =4345,
                CaseTreatmentPricingID = 5938,
                DateOfService = null,
                PatientDidNotAttend = false,
                WasAbandoned = null,
                SupplierPriceID = 7965,
                ReferrerPricingID = 5214,
                ReferrerPrice = 1,
                SupplierPrice = 1,
                IsComplete= false,
            };


            var result = objBL.UpdateCaseTreatmentPricingByCaseTreatmentPricingID(obj);
            Assert.IsTrue(result > 0);
        }


        [TestMethod]
        public void Update_CaseTreatmentPricingPriceByReferrerPricingID() 
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            CaseTreatmentPricingCaseSearch obj = new CaseTreatmentPricingCaseSearch()
            {
                CaseID =879,
                CaseTreatmentPricingID = 1016,
                DateOfService = null,
                PatientDidNotAttend = true,
                WasAbandoned = null,
                SupplierPriceID = 7918,
                ReferrerPricingID = 5268,
                ReferrerPrice = 1,
                SupplierPrice = 1,
                IsComplete= false,
                PricingTypeName = "Final Assessment"
            };

            var result = objBL.UpdateCaseTreatmentPricingPriceByReferrerPricingID(obj);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);

            var result = objBL.UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID(388, 5,4708,DateTime.Now);
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void Update_CaseTreatmentPricingPriceByCaseTreatmentPricingID()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            CaseTreatmentPricing obj = new CaseTreatmentPricing()
            {
                CaseTreatmentPricingID = 5938,
                WasAbandoned = false,
                PatientDidNotAttend = true,
                DateOfService = null,
                ReferrerPricingID = 5214,
                ReferrerPrice = 12,
                SupplierPrice = 32,
                SupplierPriceID = 7965,                                
                AuthorizationStatus = null,
                PatientDidNotAttendDate = DateTime.Now
            };


            var result = objBL.UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(obj);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetTreatmentReferrerSupplierPricing()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            int supplierID = 379;
            int referrerProjectTreatmentID = 8361;
            int treatmentCategoryID = 1;
            IEnumerable<TreatmentReferrerSupplierPricing> result = objBL.GetTreatmentReferrerSupplierPricing(supplierID, referrerProjectTreatmentID, treatmentCategoryID);

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID()
        {
            int supplierID = 379;
            int referrerProjectTreatmentID = 8361;
            int treatmentCategoryID = 1;
            int pricingTypeID = 1;
            TreatmentReferrerSupplierPricing result = _CaseTreatmentPricingRepository.GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID(supplierID, referrerProjectTreatmentID, treatmentCategoryID, pricingTypeID);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Delete_CaseTreatmentPricingByCaseTreatmentPricingID()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);

            var result = objBL.DeleteCaseTreatmentPricingByCaseTreatmentPricingID(15);
            Assert.IsTrue(result > 0);
        }


        [TestMethod]
        public void GetCheckCaseTreatmentPricingByCaseIDUnit()
        {
            ICaseTreatmentPricing objBL = new CaseTreatmentPricingImpl(_CaseTreatmentPricingRepository, _supplierTreatmentPricingRepository, _supplierTreatmentRepository, _referrerProjectTreatmentPricingRepository, _referrerProjectTreatmentRepository);
            var result = objBL.GetTreatmentReferrerSupplierPricingQA(634,10075,9);
            
        }


    }

}