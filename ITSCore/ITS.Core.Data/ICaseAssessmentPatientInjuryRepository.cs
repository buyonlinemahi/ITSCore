using ITS.Core.Data.Model;
using System.Collections.Generic;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data
{    
    public interface ICaseAssessmentPatientInjuryRepository
    {
        int AddCaseAssessmentPatientInjury(CaseAssessmentPatientInjury caseAssessmentPatientInjury);
        int UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(CaseAssessmentPatientInjury caseAssessmentPatientInjury);
        IEnumerable<CaseAssessmentPatientInjury> GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(int caseAssessmentDetailID);
        void DeleteCaseAssessmentPatientInjuryByCaseAssessmentDetailID(int caseAssessmentDetailID);
        System.Collections.Generic.IEnumerable<ReportModels.CaseAssessmentPatientInjuryAndCaseAssessment> GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailIDReports(int caseAssessmentDetailID);
         
    }
}
