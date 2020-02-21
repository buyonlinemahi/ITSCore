using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
/*
 Page Name:  SupplierComplaintTest.cs                      
 Latest Version:  1.1                                                                                                
 History:                                                                                              
   1.0 – 12/15/2012 Harpreet Singh 
 * ==============================================================================================
  Description : Add CURD to SupplierComplaintRepository
 * 
 ===================================================================================
 Version : 1.1
 Updated By : vishal
 Date : 12/21/2012
 Task : #333
 Description : Add test method For DeleteSupplierComplaintBySupplierComplaintID
 * 
 */
namespace CoreTest
{
    [TestClass]
    public class SupplierComplaintTest
    {
        ISupplierComplaintRepository _supplierComplaintRepository;

        [TestInitialize()]
        public void SupplierComplaintInit()
        {
            _supplierComplaintRepository = new SupplierComplaintRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddSupplierCompaliant()
        {
            SupplierComplaint supplierComplaint = new SupplierComplaint();
            supplierComplaint.SupplierID = 42;
            supplierComplaint.ComplaintTypeID = 1;
            supplierComplaint.ComplaintStatusID = 1;
            supplierComplaint.ComplaintDescription = "This Is Test";
            supplierComplaint.ComplaintDate = DateTime.Now;
            int result = _supplierComplaintRepository.AddSupplierComplaint(supplierComplaint);
            Assert.IsTrue(result != 0, "Error in inserting Supplier Complaint !!!");
        }
        [TestMethod]
        public void UpdateSupplierCompaliantBySupplierCompaintId()
        {
            SupplierComplaint supplierComplaint = new SupplierComplaint();
            supplierComplaint.SupplierComplaintID = 1;
            supplierComplaint.SupplierID = 42;
            supplierComplaint.ComplaintTypeID = 2;
            supplierComplaint.ComplaintStatusID = 2;
            supplierComplaint.ComplaintDescription = "This Is update Test";
            supplierComplaint.ComplaintDate = DateTime.Now;
            int result = _supplierComplaintRepository.UpdateSupplierComplaintBySupplierComplaintID(supplierComplaint);
            Assert.IsTrue(result != 0, "Error in update Supplier Complaint !!!");
        }
        [TestMethod]
        public void GetSupplierCompalintSupplierID()
        {
            IEnumerable<SupplierComplaint> supplierComplaint = _supplierComplaintRepository.GetSupplierComplaintBySupplierID(357);
            Assert.IsTrue(supplierComplaint.Any());
        }
        [TestMethod]
        public void DeleteSupplierComplaintBySupplierComplaintID()
        {
            // BL Test
            //ISupplierComplaint supplierService = new SupplierComplaintImpl(_supplierComplaintRepository);
            //int result = supplierService.DeleteSupplierComplaintBySupplierComplaintID(8);
            //DL Test
            int result = _supplierComplaintRepository.DeleteSupplierComplaintBySupplierComplaintID(7);
            Assert.IsTrue(result != 0, "Error in Deleting Supplier Complaint !!!");
        }
        [TestMethod]
        public void GetSupplierComplaintAndStatusAndTypesBySupplierID()
        {
            IEnumerable<SupplierComplaintAndStatusAndType> supplierComplantAndStatusAndType = _supplierComplaintRepository.GetSupplierComplaintAndStatusAndTypesBySupplierID(496);
            Assert.IsTrue(supplierComplantAndStatusAndType.Any());
        }
    }
}
