using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface ICaseAssessmentProposedTreatmentMethodHistoryRepository : IBaseRepository<CaseAssessmentProposedTreatmentMethodHistory>
    {

        int AddCaseAssessmentProposedTreatmentMethodHistory(CaseAssessmentProposedTreatmentMethodHistory caseAssessmentProposedTreatmentMethodHistory);
    }
}
