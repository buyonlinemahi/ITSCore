using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;
namespace ITS.Core.BL.Implementation.ExtensionMethods
{
    public static class CaseAssessmentPatientInjuryExtension
    {
        public static IEnumerable<CaseAssessmentPatientInjury> ToCaseAssessmentPatientInjuriesDL(this IEnumerable<ITS.Core.BL.Model.CaseAssessmentPatientInjury> patientInjuries,int caseAssessmentDetailID)
        {
            return patientInjuries.Select(injury =>
                new CaseAssessmentPatientInjury { AffectedArea = injury.AffectedArea, CaseAssessmentPatientInjuryID = injury.CaseAssessmentPatientInjuryID, CaseAssessmentDetailID = caseAssessmentDetailID, Score = injury.Score, Restriction = injury.Restriction,
                                                  AffectedAreaID = injury.AffectedAreaID,
                                                  RestrictionRangeID = injury.RestrictionRangeID,
                                                  StrengthTestingID = injury.StrengthTestingID,
                                                  SymptomDescriptionID = injury.SymptomDescriptionID,
                                                  OtherSymptomDesciption = injury.OtherSymptomDesciption
                }
            );
        }

        public static IEnumerable<CaseAssessmentPatientInjuryHistory> ToCaseAssessmentPatientInjuriesHistoryDL(this IEnumerable<ITS.Core.BL.Model.CaseAssessmentPatientInjury> patientInjuries, int caseAssessmentDetailHistoryID)
        {
            return patientInjuries.Select(injury =>
                new CaseAssessmentPatientInjuryHistory { AffectedArea = injury.AffectedArea, CaseAssessmentDetailHistoryID = caseAssessmentDetailHistoryID, Score = injury.Score, Restriction = injury.Restriction, AffectedAreaID = injury.AffectedAreaID,
                                                         RestrictionRangeID = injury.RestrictionRangeID,
                                                         SymptomDescriptionID = injury.SymptomDescriptionID,
                                                         StrengthTestingID = injury.StrengthTestingID,
                                                         OtherSymptomDesciption = injury.OtherSymptomDesciption
                }
            );
        }
    }
}
