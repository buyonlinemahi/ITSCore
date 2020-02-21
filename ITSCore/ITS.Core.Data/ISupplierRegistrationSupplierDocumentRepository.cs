using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ISupplierRegistrationSupplierDocumentRepository
    {
        IEnumerable<SupplierRegistrationSupplierDocument> GetSupplierRegistrationSupplierDocumentBySupplierID(int supplierID);
    }
}
