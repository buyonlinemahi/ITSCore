using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SupplierInsuranceSupplierDocumentImpl : ISupplierInsuranceSupplierDocument
    {
        private readonly ISupplierInsuranceSupplierDocumentRepository _repository;

        public SupplierInsuranceSupplierDocumentImpl(ISupplierInsuranceSupplierDocumentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SupplierInsuranceSupplierDocument> GetSupplierInsuranceSupplierDocumentBySupplierID(int supplierID)
        {
            return _repository.GetSupplierInsuranceSupplierDocumentBySupplierID(supplierID);
        }
    }
}
