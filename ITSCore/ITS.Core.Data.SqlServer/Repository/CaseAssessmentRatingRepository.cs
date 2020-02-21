using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  CaseAssessmentRatingRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create CaseAssessmentRatingRepository model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 05/01/2013 Robin 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentRatingRepository : BaseRepository<CaseAssessmentRating, ITSDBContext>, ICaseAssessmentRatingRepository
    {
        public CaseAssessmentRatingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public int AddCaseAssessmentRating(CaseAssessmentRating caseAssessmentRating)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessmentRating.CaseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", caseAssessmentRating.AssessmentServiceID);
            SqlParameter _Rating = new SqlParameter("@Rating", caseAssessmentRating.Rating);
            SqlParameter _RatingDate = new SqlParameter("@RatingDate", caseAssessmentRating.RatingDate);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRatingsRepositoryProcedures.AddCaseAssessmentRating, _CaseID, _AssessmentServiceID, _Rating, _RatingDate);
        }

        public int UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID, decimal rating)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", assessmentServiceID);
            SqlParameter _Rating = new SqlParameter("@Rating", rating);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRatingsRepositoryProcedures.UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID, _CaseID, _AssessmentServiceID, _Rating);
        }

        public CaseAssessmentRating GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", assessmentServiceID);
            return Context.Database.SqlQuery<CaseAssessmentRating>(Global.StoredProcedureConst.CaseAssessmentRatingsRepositoryProcedures.GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID, _CaseID, _AssessmentServiceID).SingleOrDefault();

        }
    }
}
