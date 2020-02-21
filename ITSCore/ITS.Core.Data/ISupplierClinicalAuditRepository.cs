using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
Page Name:  ISupplierClinicalAuditRepository.cs                      
Version:  1.0                                              
Purpose: Added,Update,GetSupplierClinicalAuditByUserID, GetSupplierClinicalAuditBySupplierID added methods                                                 
Revision History:                                        
                                                           
  1.0 – 12/29/2012 Vishal
   */
namespace ITS.Core.Data
{
   public interface ISupplierClinicalAuditRepository
    {
       int AddSupplierClinicalAudit(SupplierClinicalAudit supplierClinicalAudit);
       int UpdateSupplierClinicalAuditBySupplierClinicalAuditID(SupplierClinicalAudit supplierClinicalAudit);
       IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditByUserID(int userID);
       IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditBySupplierID(int supplierID);
       int DeleteSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID);
       SupplierClinicalAudit GetSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID);


       int AddSupplierDocumentCustom(SupplierDocument supplierdocument);
    }
}
