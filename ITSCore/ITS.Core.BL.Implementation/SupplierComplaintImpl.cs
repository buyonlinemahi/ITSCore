using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
#region Comment
/*
 Page Name:  ISupplierComplaint.cs                      
 Latest Version:  1.2
 Author : Harpreet Singh
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Harpreet Singh
  Date : 12-15-2012
  Version : 1.1
  Description : Add Interface For AddSupplierComplaint
  Description : Add Interface For UpdateSupplierComplaintBySupplierComplaintID
  Description : Add Interface For GetSupplierComplaintBySupplierID
===================================================================================
  Version : 1.2
 Updated By : vishal
 Date : 12/21/2012
 Task : #333
 Description : Implement interface For DeleteSupplierComplaintBySupplierComplaintID
 =============================================================
*/
#endregion
namespace ITS.Core.BL.Implementation
{
    public class SupplierComplaintImpl : ISupplierComplaint
    {
        private readonly ISupplierComplaintRepository _supplierComplaint;

        public SupplierComplaintImpl(ISupplierComplaintRepository supplierComplaint)
        {
            _supplierComplaint = supplierComplaint;
        }
        public int AddSupplierComplaint(SupplierComplaint supplierComplaint)
        {
            return _supplierComplaint.AddSupplierComplaint(supplierComplaint);
        }

        public int UpdateSupplierComplaintBySupplierComplaintID(SupplierComplaint supplierComplaint)
        {
            return _supplierComplaint.UpdateSupplierComplaintBySupplierComplaintID(supplierComplaint);
        }

        public IEnumerable<SupplierComplaint> GetSupplierComplaintBySupplierID(int supplierId)
        {
            return _supplierComplaint.GetSupplierComplaintBySupplierID(supplierId);
        }



        public int DeleteSupplierComplaintBySupplierComplaintID(int supplierComplaintID)
        {
            return _supplierComplaint.DeleteSupplierComplaintBySupplierComplaintID(supplierComplaintID);
        }


        public IEnumerable<SupplierComplaintAndStatusAndType> GetSupplierComplaintAndStatusAndTypesBySupplierID(int supplierId)
        {
            return _supplierComplaint.GetSupplierComplaintAndStatusAndTypesBySupplierID(supplierId);
        }
    }
}
