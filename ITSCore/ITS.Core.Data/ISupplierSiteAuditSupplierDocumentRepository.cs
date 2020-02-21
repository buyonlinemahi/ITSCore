using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ISupplierSiteAuditSupplierDocumentRepository
    {
        IEnumerable<SupplierSiteAuditSupplierDocument> GetSupplierSiteAuditSupplierDocumentBySupplierID(int supplierID);
    }
}
