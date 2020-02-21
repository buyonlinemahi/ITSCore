
namespace ITS.Core.Data.Model
{
    public class CaseAssessmentPatientImpactHistory
    {
        public int CaseAssessmentPatientImpactHistoryID { get; set; }
        public int PatientImpactID { get; set; }
        public int PatientImpactValueID { get; set; }
        public int CaseAssessmentDetailHistoryID { get; set; }
        public string Comment { get; set; }

    }
}
