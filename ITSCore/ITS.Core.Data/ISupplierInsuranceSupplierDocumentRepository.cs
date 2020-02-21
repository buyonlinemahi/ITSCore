using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ISupplierInsuranceSupplierDocumentRepository
    {
        IEnumerable<SupplierInsuranceSupplierDocument> GetSupplierInsuranceSupplierDocumentBySupplierID(int supplierID);
    }
}
