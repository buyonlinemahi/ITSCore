using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierInsuranceSupplierDocumentRepository : BaseRepository<SupplierInsuranceSupplierDocument, ITSDBContext>, ISupplierInsuranceSupplierDocumentRepository
    {
        public SupplierInsuranceSupplierDocumentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierInsuranceSupplierDocument> GetSupplierInsuranceSupplierDocumentBySupplierID(
            int supplierID)
        {
            SqlParameter sqlSupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierInsuranceSupplierDocument>(Global.StoredProcedureConst.SupplierInsuranceSupplierDocumentRepositoryProcedure.GetSupplierInsuranceSupplierDocumentBySupplierID, sqlSupplierID);
        }
    }
}
