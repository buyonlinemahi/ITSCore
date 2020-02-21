using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


#region Comment
/*
 Page Name:  SupplierSiteAudit.cs                      
 Latest Version:  1.1
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 12-24-2012
  Version : 1.0
  Description : Add following Methods For SupplierSiteAudit
 
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
  Description : Modify Method add Parameter supplierDocument in AddSupplierSiteAudit 
 
===================================================================================
*/
#endregion
namespace ITS.Core.BL.Implementation
{

    public class SupplierSiteAuditImpl : ISupplierSiteAudit
    {

        private readonly ISupplierSiteAuditRepository _supplierSiteAuditRepository;
        private readonly ISupplierDocumentRepository _supplierDocumentRepository;

        public SupplierSiteAuditImpl(ISupplierSiteAuditRepository supplierSiteAuditRepository, ISupplierDocumentRepository supplierDocumentRepository)
        {
            _supplierSiteAuditRepository = supplierSiteAuditRepository;
            _supplierDocumentRepository = supplierDocumentRepository;
        }

        public IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierDocumentID(int supplierDocumentID)
        {
            return _supplierSiteAuditRepository.GetSupplierSiteAuditBySupplierDocumentID(supplierDocumentID);
        }

        public IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierID(int supplierID)
        {
            return _supplierSiteAuditRepository.GetSupplierSiteAuditBySupplierID(supplierID);
        }

        public IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditByUserID(int userID)
        {
            return _supplierSiteAuditRepository.GetSupplierSiteAuditByUserID(userID);
        }

        public SupplierSiteAudit GetSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID)
        {
            return _supplierSiteAuditRepository.GetSupplierSiteAuditBySupplierSiteAuditID(supplierSiteAuditID);
        }

        public int UpdateSupplierSiteAuditBySupplierSiteAuditID(SupplierSiteAudit supplierSiteAudit)
        {
            return _supplierSiteAuditRepository.UpdateSupplierSiteAuditBySupplierSiteAuditID(supplierSiteAudit);
        }

        public int AddSupplierSiteAudit(SupplierSiteAudit supplierSiteAudit)
        {
            return _supplierSiteAuditRepository.AddSupplierSiteAudit(supplierSiteAudit);
        }

        public int AddSupplierSiteAuditAndDocument(SupplierSiteAudit supplierSiteAudit, SupplierDocument supplierDocument)
        {
            int supplierDocumentID = _supplierDocumentRepository.AddSupplierDocument(supplierDocument);
            supplierSiteAudit.SupplierDocumentID = supplierDocumentID;
            return _supplierSiteAuditRepository.AddSupplierSiteAudit(supplierSiteAudit);
        }

        public int DeleteSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID)
        {
            return _supplierSiteAuditRepository.DeleteSupplierSiteAuditBySupplierSiteAuditID(supplierSiteAuditID);
        }
    }
}