using Core.Base.Data.SqlServer.Factory;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

#region Comment
/*
 Page Name:  SupplierSiteAuditTest.cs                      
 Latest Version:  1.1
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 12-24-2012
  Version : 1.0
  Description : Add following test methods For SupplierSiteAudit
 
 * GetSupplierSiteAuditBySupplierDocumentID
 * GetSupplierSiteAuditBySupplierID
 * GetSupplierSiteAuditByUserID
 * GetSupplierSiteAuditBySupplierSiteAuditID
 * UpdateSupplierSiteAuditBySupplierSiteAuditID
 * AddSupplierSiteAudit
 * DeleteSupplierSiteAuditBySupplierSiteAuditID
===================================================================================
  Edited By : Vishal
  Date : 12-26-2012
  Version : 1.1
  Description : Modify All Test Method add new Parameter supplierDocument
 
===================================================================================
*/
#endregion
namespace CoreTest
{
    [TestClass]
    public class SupplierSiteAuditTest
    {

        ISupplierSiteAuditRepository _supplierSiteAudit;
        ISupplierDocumentRepository _supplierDocumentRepository;


        public SupplierSiteAuditTest()
        {

        }


        [TestInitialize()]
        public void SupplierSiteAuditRepositoryInit()
        {

            _supplierSiteAudit = new SupplierSiteAuditRepository(new BaseContextFactory<ITSDBContext>());
            _supplierDocumentRepository = new SupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetSupplierSiteAuditBySupplierDocumentID()
        {
         
            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);
            IEnumerable<SupplierSiteAudit> testResult = supplierSiteAudit.GetSupplierSiteAuditBySupplierDocumentID(1385);
            Assert.IsTrue(testResult.Any());
        }

        [TestMethod]
        public void GetSupplierSiteAuditBySupplierID()
        {
         
            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);
            IEnumerable<SupplierSiteAudit> testResult = supplierSiteAudit.GetSupplierSiteAuditBySupplierID(359);
            Assert.IsTrue(testResult.Any());
        }


        [TestMethod]
        public void GetSupplierSiteAuditBySupplierSiteAuditID()
        {
            int supplierSiteAuditID = 4;
            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);
            SupplierSiteAudit testResult = supplierSiteAudit.GetSupplierSiteAuditBySupplierSiteAuditID(supplierSiteAuditID);
            Assert.IsTrue(testResult != null, "unable to get Result");
        }

        [TestMethod]
        public void GetSupplierSiteAuditByUserID()
        {
            
            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);
            IEnumerable<SupplierSiteAudit> testResult = supplierSiteAudit.GetSupplierSiteAuditByUserID(254);
            Assert.IsTrue(testResult.Any());
        }

        [TestMethod]
        public void AddSupplierSiteAudit()
        {

            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);

            SupplierSiteAudit _supplierSiteAuditObj = new SupplierSiteAudit();


            _supplierSiteAuditObj.AuditNotes = "askl_TEST_insert";
            _supplierSiteAuditObj.AuditDate = DateTime.Now.Date;
            _supplierSiteAuditObj.AuditPass = false;
            _supplierSiteAuditObj.UserID = 21;
            _supplierSiteAuditObj.SupplierDocumentID = 2;
            _supplierSiteAuditObj.SupplierID = 91;

            int testResult = supplierSiteAudit.AddSupplierSiteAudit(_supplierSiteAuditObj);
            Assert.IsTrue(testResult != 0, "unable to get Result");
        }

        [TestMethod]
        public void AddSupplierSiteAuditAndDocument()
        {

            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);

            SupplierSiteAudit _supplierSiteAuditObj = new SupplierSiteAudit();


            _supplierSiteAuditObj.AuditNotes = "askl_TEST_insert";
            _supplierSiteAuditObj.AuditDate = DateTime.Now.Date;
            _supplierSiteAuditObj.AuditPass = false;
            _supplierSiteAuditObj.UserID = 21;
            _supplierSiteAuditObj.SupplierDocumentID = 2;
            _supplierSiteAuditObj.SupplierID = 91;

            SupplierDocument _supplierDocumentObj = new SupplierDocument();
            _supplierDocumentObj.DocumentTypeID = 2;
            _supplierDocumentObj.SupplierID = 90;
            _supplierDocumentObj.UserID = 21;
            _supplierDocumentObj.UploadDate = DateTime.Now.Date;
            _supplierDocumentObj.DocumentName = "Insuraj_Test_Name";
            _supplierDocumentObj.UploadPath = "sadgflier_Test_upload_Path";
            int testResult = supplierSiteAudit.AddSupplierSiteAuditAndDocument(_supplierSiteAuditObj, _supplierDocumentObj);
            Assert.IsTrue(testResult != 0, "unable to get Result");
        }


        [TestMethod]
        public void UpdateSupplierSiteAuditBySupplierSiteAuditID()
        {

            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);

            SupplierSiteAudit _supplierSiteAuditObj = new SupplierSiteAudit();

            _supplierSiteAuditObj.SupplierSiteAuditID = 6;
            _supplierSiteAuditObj.AuditNotes = "askl_TEST_Update";
            _supplierSiteAuditObj.AuditDate = DateTime.Now.Date;
            _supplierSiteAuditObj.AuditPass = false;
            _supplierSiteAuditObj.UserID = 21;
            _supplierSiteAuditObj.SupplierDocumentID = 2;
            _supplierSiteAuditObj.SupplierID = 91;

            int testResult = supplierSiteAudit.UpdateSupplierSiteAuditBySupplierSiteAuditID(_supplierSiteAuditObj);
            Assert.IsTrue(testResult != 0, "unable to get Result");
        }

        [TestMethod]
        public void DeleteSupplierSiteAuditBySupplierSiteAuditID()
        {

            ITS.Core.BL.ISupplierSiteAudit supplierSiteAudit = new ITS.Core.BL.Implementation.SupplierSiteAuditImpl(_supplierSiteAudit, _supplierDocumentRepository);

            int supplierSiteAuditID = 7;


            int testResult = supplierSiteAudit.DeleteSupplierSiteAuditBySupplierSiteAuditID(supplierSiteAuditID);
            Assert.IsTrue(testResult != 0, "unable to get Result");
        }
    }
}
