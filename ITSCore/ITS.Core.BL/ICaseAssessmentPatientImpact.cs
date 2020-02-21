using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL
{
    public interface ICaseAssessmentPatientImpact
    {
        int AddCaseAssessmentPatientImpact(CaseAssessmentPatientImpact caseAssessmentPatientImpact);
        int UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(CaseAssessmentPatientImpact caseAssessmentPatientImpact);
        IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(int CaseAssessmentDetailID);
IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactID(int patientImpactID);
        IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactValueID(int patientImpactValueID);
        IEnumerable<CaseAssessmentPatientImpact> GetAllCaseAssessmentPatientImpacts();
    }
}
