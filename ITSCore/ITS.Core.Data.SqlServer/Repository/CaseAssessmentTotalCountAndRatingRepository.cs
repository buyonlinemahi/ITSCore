using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
	public class CaseAssessmentTotalCountAndRatingRepository : BaseRepository<CaseAssessmentTotalCountAndRating, ITSDBContext>, ICaseAssessmentTotalCountAndRatingRepository 
	{
		public CaseAssessmentTotalCountAndRatingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public CaseAssessmentTotalCountAndRating GetCaseAssessmentTotalCountAndRatingBySupplierID(int supplierID)
        {
            SqlParameter supplierIDParam = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<CaseAssessmentTotalCountAndRating>(Global.StoredProcedureConst.AssessmentRatingTotalCountAndRatingRepositoryProcedure.GetAssessmentRatingTotalCountAndRatingBySupplierID, supplierIDParam).SingleOrDefault();
        }
	}
}

