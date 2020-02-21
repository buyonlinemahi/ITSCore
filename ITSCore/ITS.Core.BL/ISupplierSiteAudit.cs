using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
 Page Name:  ISupplierSiteAudit.cs                      
 Latest Version:  1.1
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 12-24-2012
  Version : 1.0
  Description : Add following Interfaces For SupplierSiteAudit
 
 * GetSupplierSiteAuditBySupplierDocumentID
 * GetSupplierSiteAuditBySupplierID
 * GetSupplierSiteAuditByUserID
 * GetSupplierSiteAuditBySupplierSiteAuditID
 * UpdateSupplierSiteAuditBySupplierSiteAuditID
 * AddSupplierSiteAudit
 * DeleteSupplierSiteAuditBySupplierSiteAuditID
===================================================================================
  Edited By : Vishal
  Date : 12-26-2012
  Version : 1.1
  Description : Modify Interface add Parameter supplierDocument in AddSupplierSiteAudit 
 
===================================================================================
*/
#endregion
namespace ITS.Core.BL
{
    public interface ISupplierSiteAudit
    {
        IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierDocumentID(int supplierDocumentID);
        IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierID(int supplierID);
        IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditByUserID(int userID);
        SupplierSiteAudit GetSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID);
        int UpdateSupplierSiteAuditBySupplierSiteAuditID(SupplierSiteAudit supplierSiteAudit);
        int AddSupplierSiteAudit(SupplierSiteAudit supplierSiteAudit);
        int AddSupplierSiteAuditAndDocument(SupplierSiteAudit supplierSiteAudit, SupplierDocument supplierDocument);
        int DeleteSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID);
    }
}
