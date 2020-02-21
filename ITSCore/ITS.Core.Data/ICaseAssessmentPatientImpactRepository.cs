using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data
{
    public interface ICaseAssessmentPatientImpactRepository : IBaseRepository<CaseAssessmentPatientImpact>
    {
        int AddCaseAssessmentPatientImpact(CaseAssessmentPatientImpact caseAssessmentPatientImpact);
        int UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(CaseAssessmentPatientImpact caseAssessmentPatientImpact);
        IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(int CaseAssessmentDetailID);
        IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactID(int patientImpactID);
        IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactValueID(int patientImpactValueID);
        IEnumerable<ReportModels.CaseAssessmentPatientImpactAndCaseAssessment> GetCaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID(int CaseAssessmentDetailID);

    }
}
