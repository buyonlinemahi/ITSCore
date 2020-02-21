using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace CoreTest
{

    [TestClass]
    public class ReferrerDocumentTest
    {

        IReferrerDocumentRepository _referrerDocumentRepository;

        public ReferrerDocumentTest()
        {
        }

        [TestInitialize()]
        public void ReferrerDocumentTestInit()
        {
            _referrerDocumentRepository = new ReferrerDocumentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Get_ReferrerDocumentsByReferrerIDAndDocumentTypeID()
        {
            IReferrerDocument service = new ReferrerDocumentImpl(_referrerDocumentRepository);
            var ret = service.GetReferrerDocumentsByReferrerIDAndDocumentTypeID(549,11);
            Assert.IsTrue(ret.Any());
        }
        [TestMethod]
        public void Get_ReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID()
        {
            IReferrerDocument service = new ReferrerDocumentImpl(_referrerDocumentRepository);
            var ret = service.GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID(540, 11,9982);
            Assert.IsTrue(ret.Any());
        }

        [TestMethod]
        public void Get_ReferrerDocumentsByCaseId()
        {
            IReferrerDocument service = new ReferrerDocumentImpl(_referrerDocumentRepository);
            var ret = service.GetReferrerDocumentsByCaseId(623,11);
            Assert.IsTrue(ret.Any());
        }
        

        [TestMethod]
        public void AddReferrerProject_Test()
        {
            ReferrerDocument _referrerDocumentObj = new ReferrerDocument();
            _referrerDocumentObj.ReferrerID = 446;
            _referrerDocumentObj.DocumentTypeID = 1;
            _referrerDocumentObj.UploadDate = System.DateTime.Now;
            _referrerDocumentObj.UserID = 267;
            _referrerDocumentObj.UploadPath = "xyz.pdf";            
            _referrerDocumentObj.ReferrerDocumentTypeID = 2;
            _referrerDocumentObj.CaseID = 123;
            _referrerDocumentObj.ReferrerCheck = true;
            _referrerDocumentObj.SupplierCheck = false;
             IReferrerDocument service = new ReferrerDocumentImpl(_referrerDocumentRepository);
            var ret = service.AddReferrerDocument(_referrerDocumentObj);

            Assert.IsTrue(ret != 0, "Error in inserting ReferrerDocument !!!");
        }

        [TestMethod]
        public void AddReferrerProjectCustom_Test()
        {
            ReferrerDocument _referrerDocumentObj = new ReferrerDocument();
            _referrerDocumentObj.ReferrerID = 446;
            _referrerDocumentObj.DocumentTypeID = 11;
            _referrerDocumentObj.UploadDate = System.DateTime.Now;
            _referrerDocumentObj.UserID = 267;
            _referrerDocumentObj.UploadPath = "xyz.pdf";
            _referrerDocumentObj.ReferrerProjectTreatmentID = 9997;
            IReferrerDocument service = new ReferrerDocumentImpl(_referrerDocumentRepository);
            var ret = service.AddReferrerDocumentCustom(_referrerDocumentObj);

            Assert.IsTrue(ret != 0, "Error in inserting ReferrerDocument !!!");
        }

        [TestMethod]
        public void UpdateReferrerProject_Test()
        {
            ReferrerDocument _referrerDocumentObj = new ReferrerDocument();
            _referrerDocumentObj.ReferrerID = 549;
            _referrerDocumentObj.DocumentTypeID = 13;
            _referrerDocumentObj.UploadDate = System.DateTime.Now;
            _referrerDocumentObj.UserID = 267;
            _referrerDocumentObj.UploadPath = "xyz.pdf";
            _referrerDocumentObj.ReferrerProjectTreatmentID = 9997;
            IReferrerDocument service = new ReferrerDocumentImpl(_referrerDocumentRepository);
            var ret = service.UpdateReferrerDocument(_referrerDocumentObj);

            Assert.IsTrue(ret != 0, "Error in inserting ReferrerDocument !!!");
        }

        [TestMethod]
        public void GetReferrerDocumentType()
        {
            var res = _referrerDocumentRepository.GetReferrerDocumentType();
            Assert.IsTrue(res != null, "Error");
        }
    }
}
