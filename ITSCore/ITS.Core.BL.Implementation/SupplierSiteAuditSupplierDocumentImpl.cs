using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SupplierSiteAuditSupplierDocumentImpl : ISupplierSiteAuditSupplierDocument
    {
        private readonly ISupplierSiteAuditSupplierDocumentRepository _repository;

        public SupplierSiteAuditSupplierDocumentImpl(ISupplierSiteAuditSupplierDocumentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SupplierSiteAuditSupplierDocument> GetSupplierSiteAuditSupplierDocumentBySupplierID(int supplierID)
        {
            return _repository.GetSupplierSiteAuditSupplierDocumentBySupplierID(supplierID);
        }
    }
}
