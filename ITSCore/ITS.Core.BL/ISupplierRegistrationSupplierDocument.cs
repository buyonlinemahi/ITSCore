using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ISupplierRegistrationSupplierDocument
    {
        IEnumerable<SupplierRegistrationSupplierDocument> GetSupplierRegistrationSupplierDocumentBySupplierID(int supplierID);
    }
}
