using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;



#region Comments

/*
 * Latest Version : 1.0
 * 
 * Author         : Pardeep Kumar
 * Date           : 24-Dec-2012
 * Version        : 1.0
 * Description    : Added methods to Test AddSupplierInsurance,UpdateSupplierInsurance and GetSupplierInsuranceBySupplierID of Data Layer
 * 
 */

#endregion


namespace CoreTest
{
    [TestClass]
    public class SupplierInsuranceTest
    {
        ISupplierInsuranceRepository _supplierInsuranceRepository;
        ISupplierDocumentRepository _supplierDocumentRepository;
        public SupplierInsuranceTest()
        {

        }

        [TestInitialize()]
        public void SupplierInsuranceRepositoryInit()
        {
            _supplierInsuranceRepository = new SupplierInsuranceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _supplierDocumentRepository = new SupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetSupplierInsuranceBySupplierID()
        {
            
            ISupplierInsurance supplierInsurance = new SupplierInsuranceImpl(_supplierInsuranceRepository, _supplierDocumentRepository);
            IEnumerable<SupplierInsurance> SupplierInsurance = supplierInsurance.GetSupplierInsuranceBySupplierID(359);
            Assert.IsTrue(SupplierInsurance.Any());
        }

        [TestMethod]
        public void UpdateSupplierInsurance()
        {
            ISupplierInsurance supplierInsurance = new SupplierInsuranceImpl(_supplierInsuranceRepository, _supplierDocumentRepository);
            SupplierInsurance _supplierInsuranceObj = new SupplierInsurance();
            _supplierInsuranceObj.SupplierInsuredID = 1;
            _supplierInsuranceObj.LevelOfCover = "lmn";
            _supplierInsuranceObj.RenewalDate = DateTime.Now.Date;
            _supplierInsuranceObj.SupplierDocumentID = 1;
            _supplierInsuranceObj.SupplierID = 91;
            int TestResult = supplierInsurance.UpdateSupplierInsurance(_supplierInsuranceObj);
            Assert.IsTrue(TestResult == 1, "Sucessfully Updated SupplierInsurance");
        }

        [TestMethod]
        public void AddSupplierInsurance()
        {
            ISupplierInsurance supplierInsurance = new SupplierInsuranceImpl(_supplierInsuranceRepository, _supplierDocumentRepository);
            SupplierInsurance _supplierInsuranceObj = new SupplierInsurance();
            _supplierInsuranceObj.SupplierInsuredID = 1;
            _supplierInsuranceObj.LevelOfCover = "lmn";
            _supplierInsuranceObj.RenewalDate = DateTime.Now.Date;
            _supplierInsuranceObj.SupplierID = 91;

            int TestResult = supplierInsurance.AddSupplierInsurance(_supplierInsuranceObj);
            Assert.IsTrue(TestResult > 0, "Unable Inserted New Supplier Insurance");
        }


        [TestMethod]
        public void AddSupplierInsuranceAndDocument()
        {
            ISupplierInsurance supplierInsurance = new SupplierInsuranceImpl(_supplierInsuranceRepository, _supplierDocumentRepository);
            SupplierInsurance _supplierInsuranceObj = new SupplierInsurance();
            _supplierInsuranceObj.SupplierInsuredID = 1;
            _supplierInsuranceObj.LevelOfCover = "lmn";
            _supplierInsuranceObj.RenewalDate = DateTime.Now.Date;
            _supplierInsuranceObj.SupplierID = 91;

            SupplierDocument _supplierDocumentObj = new SupplierDocument();
            _supplierDocumentObj.DocumentTypeID = 1;
            _supplierDocumentObj.SupplierID = 90;
            _supplierDocumentObj.UserID = 21;
            _supplierDocumentObj.UploadDate = DateTime.Now.Date;
            _supplierDocumentObj.DocumentName = "Add_Supplier_Test_Name";
            _supplierDocumentObj.UploadPath = "Add_Supplier_Test_upload_Path";

            int TestResult = supplierInsurance.AddSupplierInsuranceAndDocument(_supplierInsuranceObj, _supplierDocumentObj);
            Assert.IsTrue(TestResult > 0, "Unable Inserted New Supplier Insurance");
        }

        [TestMethod]
        public void DeleteSupplierInsuranceBySupplierInsuredID()
        {
            int SupplierInsuredID = 7;
            ISupplierInsurance supplierInsurance = new SupplierInsuranceImpl(_supplierInsuranceRepository, _supplierDocumentRepository);
            int SupplierInsurance = supplierInsurance.DeleteSupplierInsuranceBySupplierInsuredID(SupplierInsuredID);
            Assert.IsTrue(SupplierInsurance != 0, "unable to Delete Supplier Insurance");
        }
    }
}
