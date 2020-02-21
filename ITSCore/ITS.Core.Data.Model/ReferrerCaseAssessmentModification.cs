
namespace ITS.Core.Data.Model
{
   public class ReferrerCaseAssessmentModification
    {
        public int ReferrerCaseAssessmentModificationID { get; set; }
        public int CaseID { get; set; }
        public int TreatmentSession { get; set; }
        public int AssessmentServiceID { get; set; }
        public string AssessmentServiceName { get; set; }
    }
}
