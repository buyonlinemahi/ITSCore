using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
  Page Name:  ISupplierSiteAuditRepository.cs                      
  Latest Version:  1.0                                           
 
 * Revision History:                                                                                                   
 * Created by   : Vishal
 * Version      : 1.0
 * Dated        : 12/24/2012 
 * Descriptiobn : Add Methods  GetSupplierSiteAuditBySupplierDocumentID, GetSupplierSiteAuditBySupplierID, GetSupplierSiteAuditByUserID, GetSupplierSiteAuditBySupplierSiteAuditID
                                ,UpdateSupplierSiteAuditBySupplierSiteAuditID, AddSupplierSiteAudit, DeleteSupplierSiteAuditBySupplierSiteAuditID 

 */
namespace ITS.Core.Data
{
    public interface ISupplierSiteAuditRepository : IBaseRepository<SupplierSiteAudit>
    {
        IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierDocumentID(int supplierDocumentID);
        IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierID(int supplierID);
        IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditByUserID(int userID);
        SupplierSiteAudit GetSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID);
        int UpdateSupplierSiteAuditBySupplierSiteAuditID(SupplierSiteAudit supplierSiteAudit);
        int AddSupplierSiteAudit(SupplierSiteAudit supplierSiteAudit);
        int DeleteSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID);
    }
}
