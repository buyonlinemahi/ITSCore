using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SupplierClinicalAuditSupplierDocumentImpl : ISupplierClinicalAuditSupplierDocument
    {
        private readonly ISupplierClinicalAuditSupplierDocumentRepository _repository;

        public SupplierClinicalAuditSupplierDocumentImpl(ISupplierClinicalAuditSupplierDocumentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SupplierClinicalAuditSupplierDocument> GetSupplierClinicalAuditSupplierDocumentBySupplierID(int supplierID)
        {
            return _repository.GetSupplierClinicalAuditSupplierDocumentBySupplierID(supplierID);
        }
    }
}
