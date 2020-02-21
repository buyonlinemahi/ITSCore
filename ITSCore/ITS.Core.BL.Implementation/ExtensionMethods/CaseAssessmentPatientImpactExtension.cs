using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.BL.Implementation.ExtensionMethods
{
    public static class CaseAssessmentPatientImpactExtension
    {
        public static IEnumerable<CaseAssessmentPatientImpact> ToCaseAssessmentPatientImpactsDL(this IEnumerable<ITS.Core.BL.Model.CaseAssessmentPatientImpact> patientImpacts,int caseAssessmentDetailID)
        {
            IEnumerable<ITS.Core.Data.Model.CaseAssessmentPatientImpact> impactBL;
            return impactBL = patientImpacts != null ? patientImpacts.Select(impact =>
                new CaseAssessmentPatientImpact { CaseAssessmentPatientImpactID = impact.CaseAssessmentPatientImpactID, CaseAssessmentDetailID = caseAssessmentDetailID, Comment = impact.Comment, PatientImpactID = impact.PatientImpactID, PatientImpactValueID = impact.PatientImpactValueID }
                ) : new List<ITS.Core.Data.Model.CaseAssessmentPatientImpact>();
        }

        public static IEnumerable<CaseAssessmentPatientImpactHistory> ToCaseAssessmentPatientImpactsHistoryDL(this IEnumerable<ITS.Core.BL.Model.CaseAssessmentPatientImpact> patientImpacts, int caseAssessmentDetailHistoryID)
        {

            IEnumerable<ITS.Core.Data.Model.CaseAssessmentPatientImpactHistory> impactHistoryBL;
            return impactHistoryBL = patientImpacts != null ? patientImpacts.Select(impact =>
               new CaseAssessmentPatientImpactHistory { CaseAssessmentDetailHistoryID = caseAssessmentDetailHistoryID,  Comment = impact.Comment, PatientImpactID = impact.PatientImpactID, PatientImpactValueID = impact.PatientImpactValueID }
               ) : new List<ITS.Core.Data.Model.CaseAssessmentPatientImpactHistory>();
        }
    }
}
