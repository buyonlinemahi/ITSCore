
namespace ITS.Core.Data.Model
{
    public class CaseAssessmentCustom
    {
        public int CaseAssessmentID {get;set;}
        public int CaseID {get;set;}
        public string Message {get;set;}
        public bool IsFurtherTreatment { get; set; }
        public bool isAccepted { get; set; }
        public string ReviewAssessmentMessage { get; set; }
        public string FinalAssessmentMessage { get; set; }
    }
}
