namespace ITS.Core.Data.Model
{
    public class CaseAssessmentProposedTreatmentMethodHistory
    {
        public int CaseAssessmentProposedTreatmentMethodHistoryID { get; set; }

        public int CaseAssessmentHistoryID { get; set; }

        public int CaseID { get; set; }

        public int ProposedTreatmentMethodID { get; set; }
    }
}