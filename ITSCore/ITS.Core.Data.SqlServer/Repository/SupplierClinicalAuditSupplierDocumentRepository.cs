using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierClinicalAuditSupplierDocumentRepository : BaseRepository<SupplierClinicalAuditSupplierDocument, ITSDBContext>, ISupplierClinicalAuditSupplierDocumentRepository
    {
        public SupplierClinicalAuditSupplierDocumentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierClinicalAuditSupplierDocument> GetSupplierClinicalAuditSupplierDocumentBySupplierID(
            int supplierID)
        {
            SqlParameter sqlSupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierClinicalAuditSupplierDocument>(Global.StoredProcedureConst.SupplierClinicalAuditSupplierDocumentRepositoryProcedure.GetSupplierClinicalAuditSupplierDocumentBySupplierID, sqlSupplierID);
        }
    }
}
