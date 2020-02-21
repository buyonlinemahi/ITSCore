using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.BL.Implementation.ExtensionMethods
{
    public static class CaseAssessmentProposedTreatmentMethodExtension
    {
        public static IEnumerable<CaseAssessmentProposedTreatmentMethod> ToCaseAssessmentProposedTreatmentMethodsDL(this IEnumerable<ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod> proposedTreatmentMethods)
        {
            IEnumerable<ITS.Core.Data.Model.CaseAssessmentProposedTreatmentMethod> proposedBL;
            return proposedBL = proposedTreatmentMethods != null ? proposedTreatmentMethods.Select(proposed =>
                new CaseAssessmentProposedTreatmentMethod { ProposedTreatmentMethodID = proposed.ProposedTreatmentMethodID, CaseID = proposed.CaseID }
                ) : new List<ITS.Core.Data.Model.CaseAssessmentProposedTreatmentMethod>();
        }

        public static IEnumerable<CaseAssessmentProposedTreatmentMethodHistory> ToCaseAssessmentProposedTreatmentMethodsHistoryDL(this IEnumerable<ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod> proposedTreatmentMethods, int caseAssessmentHistoryID)
        {

            IEnumerable<ITS.Core.Data.Model.CaseAssessmentProposedTreatmentMethodHistory> proposedHistoryBL;
            return proposedHistoryBL = proposedTreatmentMethods != null ? proposedTreatmentMethods.Select(proposed =>
               new CaseAssessmentProposedTreatmentMethodHistory { CaseAssessmentHistoryID = caseAssessmentHistoryID, CaseID = proposed.CaseID, ProposedTreatmentMethodID = proposed.ProposedTreatmentMethodID }
               ) : new List<ITS.Core.Data.Model.CaseAssessmentProposedTreatmentMethodHistory>();
        }
    }
}
