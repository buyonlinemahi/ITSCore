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
    public class CaseDocumentTest
    {

        ICaseDocumentRepository _caseDocumentRepository;
        public CaseDocumentTest()
        {
        }

        [TestInitialize()]
        public void CaseDocumentRepositoryTestInit()
        {
            _caseDocumentRepository = new CaseDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddCaseDocument_BLtest()
        {
            ICaseDocument _caseDocument = new CaseDocumentImpl(_caseDocumentRepository);
            CaseDocument caseDocument = new CaseDocument();
            caseDocument.CaseID = 4378;
            caseDocument.DocumentTypeID = 8;
            caseDocument.UploadDate = Convert.ToDateTime("18/06/2015");
            caseDocument.DocumentName = "TestCase";
            caseDocument.UploadPath = "TestUpload";
            caseDocument.UserID = 497;
            int _caseDocumentResult = _caseDocument.AddCaseDocument(caseDocument);
            Assert.IsTrue(_caseDocumentResult != 0, "Error in inserting _CaseDocument !!!");
        }

        [TestMethod]
        public void UpdateTriageCaseDocumentByCaseID_BLtest()
        {

            CaseDocument caseDocument = new CaseDocument();
            caseDocument.CaseID = 256;
            caseDocument.UploadDate = Convert.ToDateTime("15/06/2013");
            caseDocument.DocumentName = "gdf";
            caseDocument.UploadPath = "fg";
            caseDocument.UserID = 255;

            ICaseDocument ObjBL = new CaseDocumentImpl(_caseDocumentRepository);
            int _caseDocumentResult = ObjBL.UpdateTriageCaseDocumentByCaseID(caseDocument);
            // int _caseDocumentResult = _caseDocumentRepository.UpdateCaseDocumentByCaseIDAndDocumentTypeID(caseDocument);
            Assert.IsTrue(_caseDocumentResult != 0, "Error in Updating _CaseDocument !!!");
        }

        [TestMethod]
        public void GetTriageCaseDocumentByCaseID_BLtest()
        {
            ICaseDocument caseDocumentResult = new CaseDocumentImpl(_caseDocumentRepository);
            CaseDocument _caseDocumentResultResult = caseDocumentResult.GetTriageCaseDocumentByCaseID(104);
            Assert.IsTrue(_caseDocumentResultResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetReferralCaseDocumentByCaseID_BLtest()
        {
            ICaseDocument caseDocumentResult = new CaseDocumentImpl(_caseDocumentRepository);
            CaseDocument _caseDocumentResultResult = caseDocumentResult.GetReferralCaseDocumentByCaseID(256);
            Assert.IsTrue(_caseDocumentResultResult != null, "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseDocumentUserByCaseID()
        {
            ICaseDocument caseDocumentResult = new CaseDocumentImpl(_caseDocumentRepository);
            IEnumerable<CaseDocumentUser> _caseDocumentResultResult = caseDocumentResult.GetCaseDocumentUserByCaseID(2269);
            Assert.IsTrue(_caseDocumentResultResult.Any(), "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetCaseDocumentForSupplierUserByCaseID()
        {
            ICaseDocument caseDocumentResult = new CaseDocumentImpl(_caseDocumentRepository);
            IEnumerable<CaseDocumentUser> _caseDocumentResultResult = caseDocumentResult.GetCaseDocumentForSupplierUserByCaseID(2269);
            Assert.IsTrue(_caseDocumentResultResult.Any(), "Error in Getting result !!!");
        }

        [TestMethod]
        public void UpdateCaseandReferreDocumentByCaseID()
        {
            CaseDocumentUser caseDocumentUser = new CaseDocumentUser();
            /*caseDocumentUser.CaseID = 2269;
            caseDocumentUser.DocumentTypeID = 5;
            caseDocumentUser.UploadDate = Convert.ToDateTime("2018-08-09 00:00:00.000");*/
            caseDocumentUser.CaseDocumentID = 5;
            caseDocumentUser.ReferrerDocumentID = 3690;
            caseDocumentUser.SupplierCheck = true;
            caseDocumentUser.ReferrerCheck = true;
            int _caseDocumentResult = _caseDocumentRepository.UpdateCaseAndReferrerDocumentByCaseID(caseDocumentUser);
            Assert.IsTrue(_caseDocumentResult != 0, "Error in inserting _CaseDocument !!!");
        }
        

    }

}