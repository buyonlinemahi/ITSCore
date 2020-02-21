using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierRegistrationSupplierDocumentRepository : BaseRepository<SupplierRegistrationSupplierDocument, ITSDBContext>, ISupplierRegistrationSupplierDocumentRepository
    {
        public SupplierRegistrationSupplierDocumentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierRegistrationSupplierDocument> GetSupplierRegistrationSupplierDocumentBySupplierID(
            int supplierID)
        {
            SqlParameter sqlSupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierRegistrationSupplierDocument>(Global.StoredProcedureConst.SupplierRegistrationSupplierDocumentRepositoryProcedure.GetSupplierRegistrationSupplierDocumentBySupplierID, sqlSupplierID);
        }
    }
}
