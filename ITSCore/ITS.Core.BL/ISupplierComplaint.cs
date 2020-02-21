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
 Description : Add interface For DeleteSupplierComplaintBySupplierComplaintID
 =============================================================
*/
#endregion
namespace ITS.Core.BL
{
    public interface ISupplierComplaint
    {
        int AddSupplierComplaint(SupplierComplaint supplierComplaint);
        int UpdateSupplierComplaintBySupplierComplaintID(SupplierComplaint supplierComplaint);
        IEnumerable<SupplierComplaint> GetSupplierComplaintBySupplierID(int supplierId);
        int DeleteSupplierComplaintBySupplierComplaintID(int supplierComplaintID);
        IEnumerable<SupplierComplaintAndStatusAndType> GetSupplierComplaintAndStatusAndTypesBySupplierID(int supplierId);
    }
}
