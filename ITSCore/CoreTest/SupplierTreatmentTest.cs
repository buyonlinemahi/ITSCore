using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;



namespace CoreTest
{


    [TestClass]
    public class SupplierTreatmentTest
    {

        ISupplierTreatmentRepository _supplierTreatmentRepository;
        public SupplierTreatmentTest()
        {
        }

        [TestInitialize()]
        public void SupplierTreatmentInit()
        {
            _supplierTreatmentRepository = new SupplierTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void Add_SupplierTreatment()
        {
            ISupplierTreatment supplierTreatmentService = new SupplierTreatmentImpl(_supplierTreatmentRepository);
            SupplierTreatment _SupplierTreatmentObj = new SupplierTreatment();
            _SupplierTreatmentObj.TreatmentCategoryID = 1;
            _SupplierTreatmentObj.SupplierID = 290;
            _SupplierTreatmentObj.Enabled = true;

            int _SupplierResult = supplierTreatmentService.AddSupplierTreatment(_SupplierTreatmentObj);
            Assert.IsTrue(_SupplierResult != 0, "Error in inserting SupplierTreatment !!!");
        }

        [TestMethod]
        public void Update_SupplierTreatment()
        {
            ISupplierTreatment supplierTreatmentService = new SupplierTreatmentImpl(_supplierTreatmentRepository);
            SupplierTreatment _SupplierTreatmentObj = new SupplierTreatment();
            _SupplierTreatmentObj.SupplierTreatmentID = 1;
            _SupplierTreatmentObj.TreatmentCategoryID = 1;
            _SupplierTreatmentObj.SupplierID = 41;
            _SupplierTreatmentObj.Enabled = false;

            int _SupplierResult = supplierTreatmentService.UpdateSupplierTreatmentBySupplierTreatmentID(_SupplierTreatmentObj);
            Assert.IsTrue(_SupplierResult != 0, "Error in Updating the SupplierTreatment !!!");
        }

        [TestMethod]
        public void Get_SupplierTreatmentBySupplierID()
        {
            ISupplierTreatment supplierTreatmentService = new SupplierTreatmentImpl(_supplierTreatmentRepository);
            IEnumerable<SupplierTreatment> _SupplierResult = supplierTreatmentService.GetSupplierTreatmentBySupplierID(256);
            Assert.IsTrue(_SupplierResult.Any());
        }

    }
}
