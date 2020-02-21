using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{

    [TestClass]
    public class InvoiceMethodTest
    {

        IInvoiceMethodRepository _invoiceMethodRepository;
        public InvoiceMethodTest()
        {
        }

        [TestInitialize()]
        public void InvoiceMethodInit()
        {
            _invoiceMethodRepository = new InvoiceMethodRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAllInvoiceMethod()
        {
            IEnumerable<InvoiceMethod> _invoiceMethod = _invoiceMethodRepository.GetAll();
            Assert.IsTrue(_invoiceMethod.Any());
        }

    }

}