using ITS.Core.Data;
using ITS.Core.Data.Model;

/*
   Latest Version: 1.0
   Author: Robin Singh Chauhan
   Reason :- Implement Interface Method for ICaseAssessmentRating
 * ======================================================================
  */
namespace ITS.Core.BL.Implementation
{

    public class CaseAssessmentRatingImpl : ICaseAssessmentRating
    {
        private readonly ICaseAssessmentRatingRepository _caseAssessmentRatingRepository;

        public CaseAssessmentRatingImpl(ICaseAssessmentRatingRepository caseAssessmentRatingRepository)
        {
            _caseAssessmentRatingRepository = caseAssessmentRatingRepository;
        }


        public int AddCaseAssessmentRating(CaseAssessmentRating caseAssessmentRating)
        {
            return _caseAssessmentRatingRepository.AddCaseAssessmentRating(caseAssessmentRating);
        }

        public int UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID, decimal rating)
        {
            return _caseAssessmentRatingRepository.UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(caseID, assessmentServiceID, rating);
        }

        public CaseAssessmentRating GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID)
        {
            return _caseAssessmentRatingRepository.GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(caseID, assessmentServiceID);
        }
    }
}
