using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class PracitionerSupplierTreatmentCategoryRepository : BaseRepository<PracitionerSupplierTreatmentCategory, ITSDBContext>, IPracitionerSupplierTreatmentCategoryRepository
    {

        public PracitionerSupplierTreatmentCategoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public IEnumerable<PracitionerSupplierTreatmentCategory> GetPracitionersByTreatmentCategoryIDAndSupplierID(int supplierID, int treatmentCategoryID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            SqlParameter _treatmentCategoryID = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);

            return Context.Database.SqlQuery<PracitionerSupplierTreatmentCategory>(Global.StoredProcedureConst.PracitionerSupplierTreatmentCategoryRepositoryProcedure.GetPracitionersByTreatmentCategoryIDAndSupplierID, _supplierID, _treatmentCategoryID);

        }
    }
}
