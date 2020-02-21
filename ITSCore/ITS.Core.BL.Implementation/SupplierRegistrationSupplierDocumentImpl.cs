using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SupplierRegistrationSupplierDocumentImpl : ISupplierRegistrationSupplierDocument
    {
        private readonly ISupplierRegistrationSupplierDocumentRepository _repository;

        public SupplierRegistrationSupplierDocumentImpl(ISupplierRegistrationSupplierDocumentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SupplierRegistrationSupplierDocument> GetSupplierRegistrationSupplierDocumentBySupplierID(int supplierID)
        {
            return _repository.GetSupplierRegistrationSupplierDocumentBySupplierID(supplierID);
        }
    }
}
