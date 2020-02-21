
namespace ITS.Core.Data.Model
{
    public class CaseAssessmentPatientImpact
    {
        public int CaseAssessmentPatientImpactID { get; set; }
        public int PatientImpactID { get; set; }
        public int PatientImpactValueID { get; set; }
        public string Comment { get; set; }
        public int CaseAssessmentDetailID { get; set; }

    }
}
