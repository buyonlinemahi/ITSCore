using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

/*
 *
 * Latest Version : 1.0
 *
 * Author         : Pardeep Kumar
 * Date           : 15-Nov-2012
 * Version        : 1.0
 *
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class TreatmentCategoryPricingTypesRepository : BaseRepository<TreatmentCategoryPricingTypes, ITSDBContext>, ITreatmentCategoryPricingTypesRepository
    {
        public TreatmentCategoryPricingTypesRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<TreatmentCategoryPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID)
        {
            return Context.Database.SqlQuery<TreatmentCategoryPricingTypes>(Global.StoredProcedureConst.TreatmentCategoryPricingTypesRepositoryProcedure.GetPricingTypesByTreatmentCategoryID, new SqlParameter("@TreatmentCategoryID", treatmentCategoryID));
        }
    }
}