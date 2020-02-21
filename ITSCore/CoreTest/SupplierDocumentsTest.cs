using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
/*
Page Name:  SupplierDocumentTest.cs                      
Version:  1.1  
 
 
 * ============================================================================================================================================================ 
  Author  : Manjit Singh
  Date    : 15-Dec-2012
  Version : 1.0
  Purpose : to test methods for SupplierDocument 
  ============================================================================================================================================================
  Updated By: Anuj Batra
  Date    : 02-26-2013
  Version : 1.1
  Purpose : Created a test method for UpdateSupplierDocumentNameBySupplierDocumentID
 */
namespace CoreTest
{
    [TestClass]
    public class SupplierDocumentTest
    {
        ISupplierDocumentRepository _supplierDocumentRepository;
        public SupplierDocumentTest()
        {

        }
        [TestInitialize()]
        public void SupplierDocumentInit()
        {
            _supplierDocumentRepository = new SupplierDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }
        [TestMethod]
        public void AddSupplierDocument()
        {
            SupplierDocument supplierDocument = new SupplierDocument();
            supplierDocument.DocumentTypeID = 1;
            supplierDocument.SupplierID = 290;
            supplierDocument.UserID = 21;
            supplierDocument.UploadDate = Convert.ToDateTime("1/1/12");
            supplierDocument.DocumentName = "DocumentName1";
            supplierDocument.UploadPath = "UploadPath";
            
            int _SupplierDocumentResult = _supplierDocumentRepository.AddSupplierDocument(supplierDocument);

            Assert.IsTrue(_SupplierDocumentResult != 0, "Error in inserting _Supplier !!!");
        }
        [TestMethod]
        public void AddSupplierDocumentCustom()
        {
            SupplierDocument supplierDocument = new SupplierDocument();
            supplierDocument.DocumentTypeID = 15;
            supplierDocument.SupplierID = 617;
            supplierDocument.UserID = 254;
            supplierDocument.UploadDate = Convert.ToDateTime("12/12/12");
            supplierDocument.DocumentName = "InitialAssessmentSupplierCustom";
            supplierDocument.UploadPath = "InitialAssessmentSupplierCustom.doc";
            supplierDocument.ReferrerProjectTreatmentID = 9982;
            supplierDocument.CaseId = 641;
            int _SupplierDocumentResult = _supplierDocumentRepository.AddSupplierDocumentCustom(supplierDocument);

            Assert.IsTrue(_SupplierDocumentResult != 0, "Error in inserting _Supplier !!!");
        }
        

        [TestMethod]
        public void UpdateSupplierDocument()
        {
            SupplierDocument supplierDocument = new SupplierDocument();
            supplierDocument.SupplierDocumentID = 468;
            supplierDocument.DocumentTypeID = 2;
            supplierDocument.SupplierID = 290;
            supplierDocument.UserID = 20;
            supplierDocument.UploadDate = Convert.ToDateTime("1/1/12");
            supplierDocument.DocumentName = "DocumentName";
            supplierDocument.UploadPath = "UploadPath";

            int _SupplierDocumentResult = _supplierDocumentRepository.UpdateSupplierDocument(supplierDocument);

            Assert.IsTrue(_SupplierDocumentResult != 0, "Error in inserting _Supplier !!!");
        }
        [TestMethod]
        public void GetSupplierDocumentBySupplierIDAndDocumentTypeID()
        {
            IEnumerable<SupplierDocumentUser> _SupplierDocumentResult = _supplierDocumentRepository.GetSupplierDocumentBySupplierIDAndDocumentTypeID(476, 1);

            Assert.IsTrue(_SupplierDocumentResult.Any());
        }

        [TestMethod]
        public void GetSupplierDocumentByCaseIdAndDocumentTypeId()
        {
            IEnumerable<SupplierDocument> _SupplierDocumentRslt = _supplierDocumentRepository.GetSupplierDocumentByCaseIdAndDocumentTypeId(666, 15);

            Assert.IsTrue(_SupplierDocumentRslt.Any());
        }


        [TestMethod]
        public void DeleteSupplierDocumentBySupplierDocumentID()
        {
            int  result = _supplierDocumentRepository.DeleteSupplierDocumentBySupplierDocumentID(481);

            Assert.IsTrue(result != 0, "unable to delete");
        }
        [TestMethod]
        public void UpdateSupplierDocumentNameBySupplierDocumentID()
        {
            ITS.Core.BL.ISupplierDocument supplierDocumentRepo = new ITS.Core.BL.Implementation.SupplierDocumentImpl( _supplierDocumentRepository);
            SupplierDocument supplierDocument = new SupplierDocument();
            supplierDocument.SupplierDocumentID = 468;
            supplierDocument.DocumentTypeID = 2;
            supplierDocument.SupplierID = 290;
            supplierDocument.UserID = 20;
            supplierDocument.UploadDate = Convert.ToDateTime("1/1/12");
            supplierDocument.DocumentName = "DocumentName";
            
            int result = supplierDocumentRepo.UpdateSupplierDocument(supplierDocument);
            Assert.IsTrue(result != 0, "unable to update");
        }

        [TestMethod]
        public void GetSupplierDocumentByCaseId()
        {
            IEnumerable<SupplierDocumentCustomReport> _SupplierDocumentRslt = _supplierDocumentRepository.GetSupplierDocumentByCaseId(649);

            Assert.IsTrue(_SupplierDocumentRslt.Any());
        }

    }
}


