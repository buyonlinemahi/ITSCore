using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ISupplierClinicalAuditSupplierDocumentRepository
    {
        IEnumerable<SupplierClinicalAuditSupplierDocument> GetSupplierClinicalAuditSupplierDocumentBySupplierID(int supplierID);
    }
}
