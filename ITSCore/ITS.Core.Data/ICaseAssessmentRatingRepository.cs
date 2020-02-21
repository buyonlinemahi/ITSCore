using ITS.Core.Data.Model;
using Core.Base.Data;

#region Comment
/*
    * Author : Robin Singh
    * Latest Version : 1.0
    * Reason :- Interface For CaseAssessmentRating
    * Created on 04-30-2013
*/
#endregion

namespace ITS.Core.Data
{
    public interface ICaseAssessmentRatingRepository : IBaseRepository<CaseAssessmentRating>
    {
        int AddCaseAssessmentRating(CaseAssessmentRating caseAssessmentRating);
        int UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID, decimal rating);
        CaseAssessmentRating GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID);

    }
}
