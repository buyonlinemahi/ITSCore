using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ISupplierSiteAuditSupplierDocument
    {
        IEnumerable<SupplierSiteAuditSupplierDocument> GetSupplierSiteAuditSupplierDocumentBySupplierID(int supplierID);
    }
}
