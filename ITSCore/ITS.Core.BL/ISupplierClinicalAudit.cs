using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
Page Name:  ISupplierClinicalAudit.cs                      
Version:  1.0                                              
Purpose: Create CURD operation for ISupplierClinicalAudit contract.                                          
Revision History:                                       
                                                           
  1.0 – 12/29/2012 Vishal 
   */

namespace ITS.Core.BL
{
    public interface ISupplierClinicalAudit
    {
        int AddSupplierClinicalAudit(SupplierClinicalAudit supplierClinicalAudit);
        int UpdateSupplierClinicalAuditBySupplierClinicalAuditID(SupplierClinicalAudit supplierClinicalAudit);
        IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditByUserID(int userID);
        IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditBySupplierID(int supplierID);
        int DeleteSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID);
        int AddSupplierClinicalAuditAndDocument(SupplierClinicalAudit supplierClinicalAudit, SupplierDocument supplierDocument);
        SupplierClinicalAudit GetSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID);
    }
}
