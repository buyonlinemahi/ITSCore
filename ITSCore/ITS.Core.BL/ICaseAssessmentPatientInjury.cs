using ITS.Core.BL.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ICaseAssessmentPatientInjury
    {
        int AddCaseAssessmentPatientInjury(Data.Model.CaseAssessmentPatientInjury caseAssessmentPatientInjury);
        int UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(Data.Model.CaseAssessmentPatientInjury caseAssessmentPatientInjury);
        IEnumerable<CaseAssessmentPatientInjuryBL> GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(int caseAssessmentID);        
    }
}
