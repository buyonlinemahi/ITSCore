using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class TreatmentCategoriesPricingTypesRepository : BaseRepository<TreatmentCategoriesPricingTypes, ITSDBContext>, ITreatmentCategoriesPricingTypesRepository
    {
        public TreatmentCategoriesPricingTypesRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<TreatmentCategoriesPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID)
        {
            return Context.Database.SqlQuery<TreatmentCategoriesPricingTypes>(Global.StoredProcedureConst.TreatmentCategoriesPricingTypesRepositoryProcedure.GetTreatmentCategoriesPricingTypesByTreatmentCategoryID, new SqlParameter("@TreatmentCategoryID", treatmentCategoryID));

        }

     

    }
}