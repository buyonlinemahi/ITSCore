using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierSiteAuditSupplierDocumentRepository : BaseRepository<SupplierSiteAuditSupplierDocument, ITSDBContext>, ISupplierSiteAuditSupplierDocumentRepository
    {
        public SupplierSiteAuditSupplierDocumentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierSiteAuditSupplierDocument> GetSupplierSiteAuditSupplierDocumentBySupplierID(
            int supplierID)
        {
            SqlParameter sqlSupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierSiteAuditSupplierDocument>(Global.StoredProcedureConst.SupplierSiteAuditSupplierDocumentRepositoryProcedure.GetSupplierSiteAuditSupplierDocumentBySupplierID, sqlSupplierID);
        }
    }
}
