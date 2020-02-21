using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
 Page Name:  ISupplierRepository.cs                      
 Latest Version:  1.1
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-17-2012
  Version : 1.0
  Description : Add interface For Get_SupplierBySupplierID
  Description : Add interface For Get_SuppliersLikeSupplierName
  Description : Add interface For Add_Supplier
  Description : Add interface For Update_SupplierBySupplierID
===================================================================================

Updated By: Anuj Batra
Date:       12-18-2012
Version     1.1
Desc:       Added method to GetSuppliersLikePostCode.
===================================================================================
*/
#endregion

namespace ITS.Core.Data
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Supplier GetSupplierBySupplierID(int supplierID);
       
        int AddSupplier(Supplier supplier);
        int UpdateSupplierBySupplierID(Supplier supplier);
        int UpdateSupplierStatusBySupplierID(int supplierID,int statusID);
        bool GetSupplierExistsByName(string supplierName);
        bool GetSupplierExistsByEmail(string email);
        
        IEnumerable<Supplier> GetSuppliersRecentlyAdded();
        IEnumerable<SuppliersName> GetAllSuppliers();
    }
}
