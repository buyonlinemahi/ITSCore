using ITS.Core.Data.Model;


namespace ITS.Core.BL
{
    public interface ICaseAssessmentRating
    {
        int AddCaseAssessmentRating(CaseAssessmentRating caseAssessmentRating);
        int UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID, decimal rating);
        CaseAssessmentRating GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID);
    }
}
