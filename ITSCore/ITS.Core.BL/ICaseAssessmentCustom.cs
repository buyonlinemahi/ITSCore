using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ICaseAssessmentCustom
    {
        int AddCaseAssessmentCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom);
        CaseAssessmentCustom GetCaseAssessmentCustomByCaseID(int CaseID);
        int UpdateCaseAssessmentCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom);
        int UpdateCaseRiewAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom);
        int UpdateCaseInitialAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom);
        int UpdateCaseFinalAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom);
    }
}
