using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;



namespace CoreTest
{


    [TestClass]
    public class InvoiceTest
    {

        IInvoiceRepository _invoiceRepository;
        IInvoice invoiceService;

        public InvoiceTest()
        {
        }

        [TestInitialize()]
        public void InvoiceInit()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();
            _invoiceRepository = new InvoiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            invoiceService = new InvoiceImpl(_invoiceRepository);
        }

        [TestMethod]
        public void Update_InvoiceIsCompleteByInvoiceID()
        {
            Assert.IsTrue(invoiceService.UpdateInvoiceIsCompleteByInvoiceID(false, 1) != 0, "Error in updating the InvoiceIsComplete By InvoiceID");
        }

        [TestMethod]
        public void Get_InvoicesByCaseId()
        {
            var _invoiceServiceResult = invoiceService.GetInvoicesByCaseId(356).Count();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in updating the Get Invoices By CaseId");
        }

        [TestMethod]
        public void Add_Invoice()
        {
            Invoice _InvoiceObj = new Invoice();
            _InvoiceObj.InvoiceNumber = "Test-350";
            _InvoiceObj.Amount = 2000;
            _InvoiceObj.CaseID = 350;
            _InvoiceObj.UserID = 254;
            _InvoiceObj.InvoiceDate = DateTime.Now;

            int _invoiceServiceResult = invoiceService.AddInvoice(_InvoiceObj);
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in inserting invoice !!!");
        }


        [TestMethod]
        public void Get_InvoiceByInvoiceID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoiceByInvoiceID(1);

            Assert.IsTrue(_invoiceServiceResult != null, "Error in Get Invoice By InvoiceID !!!"); ;
        }

        [TestMethod]
        public void Add_InvoicePayment()
        {
            InvoicePayment _InvoiceObj = new InvoicePayment();
            _InvoiceObj.InvoiceID = 3;
            _InvoiceObj.Payment = 900;
            _InvoiceObj.AdjustedPayment = 100;
            _InvoiceObj.UserID = 254;
            _InvoiceObj.CheckNumber = "AWD3232";
            _InvoiceObj.BACS = "BACS";
            _InvoiceObj.InvoicePaymentDate = DateTime.Now;

            int _invoiceServiceResult = invoiceService.AddInvoicePayment(_InvoiceObj);
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in inserting invoice !!!");
        }


        [TestMethod]
        public void Add_InvoiceCollectionAction()
        {
            InvoiceCollectionAction _InvoiceObj = new InvoiceCollectionAction();
            _InvoiceObj.InvoiceID = 1;
            _InvoiceObj.Action = "Action";
            _InvoiceObj.UserID = 256;
            _InvoiceObj.FollowUpDate = DateTime.Now;
            _InvoiceObj.DateofAction = DateTime.Now;
            int _invoiceServiceResult = invoiceService.AddInvoiceCollectionAction(_InvoiceObj);
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in inserting invoice !!!");
        }


        [TestMethod]
        public void Get_InvoiceCollectionActionByInvoiceCollectionActionID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoiceCollectionActionByInvoiceCollectionActionID(1);

            Assert.IsTrue(_invoiceServiceResult != null, "Error in Get Invoice By InvoiceID !!!"); ;
        }


        [TestMethod]
        public void Get_InvoicePaymentByInvoicePaymentID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoicePaymentByInvoicePaymentID(1);

            Assert.IsTrue(_invoiceServiceResult != null, "Error in Get Invoice By InvoiceID !!!"); ;
        }

        [TestMethod]
        public void Get_InvoiceCollectionActionByInvoiceID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoiceCollectionActionByInvoiceID(1).Count();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in updating the GetInvoiceCollectionActionByInvoiceID");
        }

        [TestMethod]
        public void Get_InvoiceCollectionActionByUserID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoiceCollectionActionByUserID(256).Count();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in updating the GetInvoiceCollectionActionByUserID");
        }

        [TestMethod]
        public void Get_InvoicePaymentByInvoiceID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoicePaymentByInvoiceID(1).Count();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in updating the GetInvoicePaymentByInvoiceID");
        }

        [TestMethod]
        public void Get_InvoicePaymentByUserID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoicePaymentByUserID(254).Count();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in updating the GetInvoicePaymentByUserID");
        }

        [TestMethod]
        public void Get_InvoicesByUserID()
        {
            var _invoiceServiceResult = invoiceService.GetInvoicesByUserID(254).Count();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in updating the GetInvoicesByUserID");
        }

        [TestMethod]
        public void GetOutstandingInvoicesCasePatientReferrer()
        {
            var _invoiceServiceResult = invoiceService.GetOutstandingInvoicesCasePatientReferrer(0,4).ToList();
            var df = _invoiceServiceResult.Count();
            Assert.IsTrue(df != 4, "Error in updating the GetOutstandingInvoicesCasePatientReferrer");
        }


        [TestMethod]
        public void Get_CaseInvoicePatientReferrerCount()
        {
            int _invoiceServiceResult = invoiceService.GetCaseInvoicePatientReferrerCount();
            Assert.IsTrue(_invoiceServiceResult != 0, "Error in  invoice count !!!");
        }


    }
}
