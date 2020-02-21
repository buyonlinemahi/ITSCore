using Core.Base.Data;
using ITS.Core.Data.Model;


namespace ITS.Core.Data
{
    public interface ICaseAssessmentCustomRepository : IBaseRepository<CaseAssessmentCustom>
    {
        int AddCaseAssessmentCustom(CaseAssessmentCustom caseAssessmentCustom);
        CaseAssessmentCustom GetCaseAssessmentCustomByCaseID(int CaseID);
        int UpdateCaseAssessmentCustom(CaseAssessmentCustom caseAssessmentCustom);
        int UpdateCaseRiewAssessmentMessageCustom(CaseAssessmentCustom caseAssessmentCustom);
        int UpdateCaseInitialAssessmentMessageCustom(CaseAssessmentCustom caseAssessmentCustom);
        int UpdateCaseFinalAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom);
    }
}
