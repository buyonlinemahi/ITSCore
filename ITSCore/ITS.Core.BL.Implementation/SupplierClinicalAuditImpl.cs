using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
Page Name:  SupplierClinicalAuditImpl.cs                      
Version:  1.0                                              
Purpose: Create CURD operation for SupplierClinicalAuditImpl contract.                                          
Revision History:                                       
                                                           
  1.0 – 12/29/2012 Vishal 
   */

namespace ITS.Core.BL.Implementation
{
    public class SupplierClinicalAuditImpl : ISupplierClinicalAudit
    {
        private readonly ISupplierClinicalAuditRepository _supplierClinicalAuditRepository;
        private readonly ISupplierDocumentRepository _supplierDocumentRepository;

        public SupplierClinicalAuditImpl(ISupplierClinicalAuditRepository supplierClinicalAuditRepository, ISupplierDocumentRepository supplierDocumentRepository)
        {
            _supplierClinicalAuditRepository = supplierClinicalAuditRepository;
            _supplierDocumentRepository = supplierDocumentRepository;
        }


        public int AddSupplierClinicalAudit(SupplierClinicalAudit supplierClinicalAudit)
        {
            return _supplierClinicalAuditRepository.AddSupplierClinicalAudit(supplierClinicalAudit);
        }

        public int UpdateSupplierClinicalAuditBySupplierClinicalAuditID(SupplierClinicalAudit supplierClinicalAudit)
        {
            return _supplierClinicalAuditRepository.UpdateSupplierClinicalAuditBySupplierClinicalAuditID(supplierClinicalAudit);
        }

        public IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditByUserID(int userID)
        {
            return _supplierClinicalAuditRepository.GetSupplierClinicalAuditByUserID(userID);
        }

        public IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditBySupplierID(int supplierID)
        {
            return _supplierClinicalAuditRepository.GetSupplierClinicalAuditBySupplierID(supplierID);
        }


        public int DeleteSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID)
        {
            return _supplierClinicalAuditRepository.DeleteSupplierClinicalAuditBySupplierClinicalAuditID(supplierClinicalAuditID);
        }


        public int AddSupplierClinicalAuditAndDocument(SupplierClinicalAudit supplierClinicalAudit, SupplierDocument supplierDocument)
        {
            int supplierDocumentID = _supplierDocumentRepository.AddSupplierDocument(supplierDocument);
            supplierClinicalAudit.SupplierDocumentID = supplierDocumentID;
            return _supplierClinicalAuditRepository.AddSupplierClinicalAudit(supplierClinicalAudit);
        }

        public int AddSupplierDocumentCustom(SupplierDocument supplierdocument)
        {
            return _supplierClinicalAuditRepository.AddSupplierDocumentCustom(supplierdocument);
        }

        public SupplierClinicalAudit GetSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID)
        {
            return _supplierClinicalAuditRepository.GetSupplierClinicalAuditBySupplierClinicalAuditID(supplierClinicalAuditID);
        }
    }
}
