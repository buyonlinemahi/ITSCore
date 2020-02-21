using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
  Page Name:      ReferrerProjectTreatmentInvoiceTest.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 11/22/2012 Satya
 * Description : add test method for ReferrerProjectTreatmentInvoiceTest
 
 */
#endregion


namespace CoreTest
{

    [TestClass]
    public class ReferrerProjectTreatmentInvoiceTest
    {

        IReferrerProjectTreatmentInvoiceRepository _referrerProjectTreatmentInvoiceRepository;
        IInvoiceMethodRepository _invoiceMethodRepository;

        public ReferrerProjectTreatmentInvoiceTest()
        {
        }

        [TestInitialize()]
        public void ReferrerProjectTreatmentInvoiceTestInit()
        {
            _referrerProjectTreatmentInvoiceRepository = new ReferrerProjectTreatmentInvoiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _invoiceMethodRepository = new InvoiceMethodRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddReferrerProjectTreatmentInvoiceTest()
        {
            ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice = new ReferrerProjectTreatmentInvoice();
            referrerProjectTreatmentInvoice.InvoicePrice = 1000;
            referrerProjectTreatmentInvoice.ManagementPrice = 2000;
            referrerProjectTreatmentInvoice.ManagementFeeEnabled = true;
            referrerProjectTreatmentInvoice.InvoiceMethodID = 2;
            referrerProjectTreatmentInvoice.ReferrerProjectTreatmentID = 2;
            int _referrerProjectTreatmentInvoiceResult = _referrerProjectTreatmentInvoiceRepository.AddReferrerProjectTreatmentInvoice(referrerProjectTreatmentInvoice);

            Assert.IsTrue(_referrerProjectTreatmentInvoiceResult != 0, "Error on add ReferrerProjectTreatmentInvoice !!!");
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentIDTest()
        {
            IEnumerable<ReferrerProjectTreatmentInvoice> referrerProjectTreatmentInvoice = _referrerProjectTreatmentInvoiceRepository.GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(8361);
            Assert.IsTrue(referrerProjectTreatmentInvoice.Any());
        }

        [TestMethod]
        public void ReferrerProjectTreatmentInvoiceMethodByReferrerProjectTreatmentIDTest()
        {
            IReferrerProjectTreatmentInvoice service = new ReferrerProjectTreatmentInvoiceImpl(_referrerProjectTreatmentInvoiceRepository, _invoiceMethodRepository);
            var referrerProjectTreatmentInvoice = service.GetReferrerProjectTreatmentInvoiceMethodByReferrerProjectTreatmentID(8361);
            Assert.IsTrue(referrerProjectTreatmentInvoice!=null);
        }

        [TestMethod]
        public void UpdateReferrerProjectTreatmentEmailTest()
        {
            ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice = new ReferrerProjectTreatmentInvoice();
            referrerProjectTreatmentInvoice.InvoicePrice = 2000;
            referrerProjectTreatmentInvoice.ManagementPrice = 3000;
            referrerProjectTreatmentInvoice.ManagementFeeEnabled = false;
            referrerProjectTreatmentInvoice.InvoiceMethodID = 2;
            referrerProjectTreatmentInvoice.ReferrerProjectTreatmentID = 2;
            referrerProjectTreatmentInvoice.ReferrerProjectTreatmentInvoiceID = 1;
            int _referrerProjectTreatmentInvoiceResult = _referrerProjectTreatmentInvoiceRepository.UpdateReferrerProjectTreatmentInvoice(referrerProjectTreatmentInvoice);

            Assert.IsTrue(_referrerProjectTreatmentInvoiceResult != 0, "Error on updating ReferrerProjectTreatmentInvoice !!!");
        }

    }
}
