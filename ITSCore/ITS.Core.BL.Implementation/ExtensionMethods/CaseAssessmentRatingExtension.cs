using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation.ExtensionMethods
{
    public static class CaseAssessmentRatingExtension
    {

        public static CaseAssessmentRating ToCaseAsssessmentRatingDL(this ITS.Core.BL.Model.CaseAssessmentRating rating)
        {
            CaseAssessmentRating ratingDL = rating != null ? new CaseAssessmentRating { AssessmentServiceID = rating.AssessmentServiceID, CaseAssessmentRatingID = rating.CaseAssessmentRatingID, CaseID = rating.CaseID, Rating = rating.Rating, RatingDate = rating.RatingDate } : null;
            return ratingDL;
        }
    }
}
