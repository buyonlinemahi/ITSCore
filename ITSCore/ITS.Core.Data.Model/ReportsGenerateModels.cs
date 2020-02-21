using ITS.Core.Data.Model.Reports;
using System.Collections.Generic;

namespace ITS.Core.Data.Model
{
    public class ReportsGenerateModels
    {
        public IEnumerable<CaseAssessmentProposedTreatmentMethodsAndValues> CaseAssessmentProposedTreatmentMethodsAndValuesDetails { get; set; }
        public IEnumerable<CaseAssessmentPatientImpactAndCaseAssessment> CaseAssessmentPatientImpactAndCaseAssessmentDetails { get; set; }
        public IEnumerable<CaseAssessmentPatientInjuryAndCaseAssessment> CaseAssessmentPatientInjuryAndCaseAssessmentDetails { get; set; }
        public CaseAssessments CaseAssessmentsDetails { get; set; }
        public CaseAssessmentsDetails CaseAssessmentsDetailsModel { get; set; }
        public PatientAndCase PatientAndCaseDetails { get; set; }
    }
}
