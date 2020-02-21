using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comments

/*
 * Latest Version : 1.0
 * 
 * Author      : Pardeep Kumar
 * Date        : 24-Dec-2012
 * Version     : 1.0
 * Description : Added Interface methods AddSupplierInsurance,UpdateSupplierInsurance and GetSupplierInsuranceBySupplierID
 * 
 */

#endregion

namespace ITS.Core.Data
{
    public interface ISupplierInsuranceRepository : IBaseRepository<SupplierInsurance>
    {
        int AddSupplierInsurance(SupplierInsurance supplierInsurance);
        int UpdateSupplierInsurance(SupplierInsurance supplierInsurance);
        IEnumerable<SupplierInsurance> GetSupplierInsuranceBySupplierID(int supplierID);
        int DeleteSupplierInsuranceBySupplierInsuredID(int supplierInsuredID);
    }
}
