using Core.Base.Data;
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
  Version : 1.0
  Description : Add Interface For AddSupplierComplaint
  Description : Add Interface For UpdateSupplierComplaintBySupplierComplaintID
  Description : Add Interface For GetSupplierComplaintBySupplierID
===================================================================================
 Updated By : Anuj Batra
  Date : 12-17-2012
  Version : 1.1
  Description : Updated the file as interface was not inheriting the IBaseRepository 
 ===================================================================================  
 Version : 1.2
 Updated By : vishal
 Date : 12/21/2012
 Task : #333
 Description : Add interface For DeleteSupplierComplaintBySupplierComplaintID
 =============================================================
  */
#endregion
namespace ITS.Core.Data
{
    public interface ISupplierComplaintRepository : IBaseRepository<SupplierComplaint>
    {
        int AddSupplierComplaint(SupplierComplaint supplierComplaint);
        int UpdateSupplierComplaintBySupplierComplaintID(SupplierComplaint supplierComplaint);
        IEnumerable<SupplierComplaint> GetSupplierComplaintBySupplierID(int supplierId);
        int DeleteSupplierComplaintBySupplierComplaintID(int supplierComplaintID);
        //IEnumerable<ComplaintSupplier> GetComplaintSupplierBySupplierID(int supplierId);
        IEnumerable<SupplierComplaintAndStatusAndType> GetSupplierComplaintAndStatusAndTypesBySupplierID(int supplierId);
        
    }
}
