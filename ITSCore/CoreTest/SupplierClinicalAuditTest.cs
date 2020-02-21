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
 * Latest Version : 1.2
 * 
 * Author         : Vishal
 * Date           : 29-Dec-2012
 * Version        : 1.0
 * Description    : Added Test Mehtods for SupplierClinicalAudit
 * 
 * 
 * Modified by    : Pardeep Kumar
 * Date           : 25-Jan-2013
 * Latest version : 1.1
 * Description    : Updated the data type of SupplierClinicalAuditStatus from String to Boolean
 * 
 * Modified by    : Pardeep Kumar
 * Date           : 11-Feb-2013
 * Latest version : 1.2
 * Description    : Updated the parameters of method AddSupplierClinicalAudit as ReferrerID is removed from the table SupplierClinicalAudit
 *                : Updated the parameters of method UpdateSupplierClinicalAudit as ReferrerID is removed from the table SupplierClinicalAudit
 */

#endregion

namespace CoreTest
{
    [TestClass]
    public class SupplierClinicalAuditTest
    {
        ISupplierClinicalAuditRepository _supplierClinicalAuditRepository;
        ISupplierDocumentRepository _supplierDocumentRepository;
        ICaseRepository _caseRepository;
        public SupplierClinicalAuditTest()
        {

        }

        [TestInitialize()]
        public void SupplierClinicalAuditRepositoryInit()
        {
            _supplierClinicalAuditRepository = new SupplierClinicalAuditRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _supplierDocumentRepository = new SupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseRepository = new CaseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetSupplierClinicalAuditBySupplierID()
        {
            int supplierID = 477;
            ISupplierClinicalAudit supplierClinicalAudit = new SupplierClinicalAuditImpl(_supplierClinicalAuditRepository, _supplierDocumentRepository);
            IEnumerable<SupplierClinicalAudit> SupplierClinicalAudit = supplierClinicalAudit.GetSupplierClinicalAuditBySupplierID(supplierID);
            Assert.IsTrue(SupplierClinicalAudit.Any());
        }

        [TestMethod]
        public void GetSupplierClinicalAuditByUserID()
        {
            int UserID = 254;
            ISupplierClinicalAudit supplierClinicalAudit = new SupplierClinicalAuditImpl(_supplierClinicalAuditRepository,_supplierDocumentRepository);
            IEnumerable<SupplierClinicalAudit> SupplierClinicalAudit = supplierClinicalAudit.GetSupplierClinicalAuditByUserID(UserID);
            Assert.IsTrue(SupplierClinicalAudit.Any());
        }


        [TestMethod]
        public void AddSupplierClinicalAudit()
        {
            ISupplierClinicalAudit supplierClinicalAudit = new SupplierClinicalAuditImpl(_supplierClinicalAuditRepository, _supplierDocumentRepository);
            SupplierClinicalAudit _supplierClinicalAuditObj = new SupplierClinicalAudit();
            _supplierClinicalAuditObj.SupplierID = 240;
            _supplierClinicalAuditObj.AuditPass = true;
            _supplierClinicalAuditObj.UserID = 20;
            _supplierClinicalAuditObj.AuditDate = DateTime.Now.Date;
            _supplierClinicalAuditObj.CaseID = 1;
            _supplierClinicalAuditObj.SupplierDocumentID = 468;

            int TestResult = supplierClinicalAudit.AddSupplierClinicalAudit(_supplierClinicalAuditObj);
            Assert.IsTrue(TestResult > 0, "Unable Inserted New supplier Clinical Audit");
        }


        [TestMethod]
        public void AddSupplierClinicalAuditAndDocument()
        {
            ISupplierClinicalAudit supplierClinicalAudit = new SupplierClinicalAuditImpl(_supplierClinicalAuditRepository, _supplierDocumentRepository);
            SupplierClinicalAudit _supplierClinicalAuditObj = new SupplierClinicalAudit();
            _supplierClinicalAuditObj.SupplierID = 240;
            _supplierClinicalAuditObj.AuditPass = true;
            _supplierClinicalAuditObj.UserID = 20;
            _supplierClinicalAuditObj.AuditDate = DateTime.Now.Date;
            _supplierClinicalAuditObj.CaseID = 1;
            _supplierClinicalAuditObj.SupplierDocumentID = 468;
            SupplierDocument _supplierDocumentObj = new SupplierDocument();
            _supplierDocumentObj.DocumentTypeID = 4;
            _supplierDocumentObj.SupplierID = 240;
            _supplierDocumentObj.UserID = 21;
            _supplierDocumentObj.UploadDate = DateTime.Now.Date;
            _supplierDocumentObj.DocumentName = "Add_Supplier_Test_Name";
            _supplierDocumentObj.UploadPath = "Add_Supplier_Test_upload_Path";

            int TestResult = supplierClinicalAudit.AddSupplierClinicalAuditAndDocument(_supplierClinicalAuditObj, _supplierDocumentObj);
            Assert.IsTrue(TestResult > 0, "Unable Inserted New  Add SupplierClinicalAudit And Document");
        }


        [TestMethod]
        public void UpdateSupplierClinicalAudit()
        {
            ISupplierClinicalAudit supplierClinicalAudit = new SupplierClinicalAuditImpl(_supplierClinicalAuditRepository, _supplierDocumentRepository);
            SupplierClinicalAudit _supplierClinicalAuditObj = new SupplierClinicalAudit();

            _supplierClinicalAuditObj.SupplierClinicalAuditID = 189;
            _supplierClinicalAuditObj.SupplierID = 404;
            _supplierClinicalAuditObj.AuditPass = false;
            _supplierClinicalAuditObj.UserID = 254;
            _supplierClinicalAuditObj.AuditDate = DateTime.Now.Date;
            _supplierClinicalAuditObj.CaseID = 1;
            _supplierClinicalAuditObj.SupplierDocumentID = 1422;

            int TestResult = supplierClinicalAudit.UpdateSupplierClinicalAuditBySupplierClinicalAuditID(_supplierClinicalAuditObj);
            Assert.IsTrue(TestResult > 0, "Unable Update supplier Clinical Audit");
        }

        [TestMethod]
        public void DeleteSupplierClinicalAuditBySupplierClinicalAuditID()
        {
            int SupplierClinicalAuditID = 18;
            ISupplierClinicalAudit supplierClinicalAudit = new SupplierClinicalAuditImpl(_supplierClinicalAuditRepository, _supplierDocumentRepository);
            int SupplierClinicalAudit = supplierClinicalAudit.DeleteSupplierClinicalAuditBySupplierClinicalAuditID(SupplierClinicalAuditID);
            Assert.IsTrue(SupplierClinicalAudit < 0, "unable to Delete Supplier Clinical Audit");
        }

        [TestMethod]
        public void GetSupplierClinicalAuditBySupplierClinicalAuditIDRepo_Test()
        {
            Assert.IsTrue(_supplierClinicalAuditRepository.GetSupplierClinicalAuditBySupplierClinicalAuditID(43).SupplierDocumentID != 0);
        }
    }
}
