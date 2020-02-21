using System;

namespace ITS.Core.Data.Model
{
    public class ReferrerSupplierCases
    {
        public int PatientID { get; set; }
        public DateTime CaseSubmittedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public int CaseID { get; set; }
        public string CaseNumber { get; set; }
        public int WorkflowID { get; set; }
        public string CaseReferrerReferenceNumber { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? InitialAssessmentDate { get; set; }
        public DateTime? FinalAssessmentDate { get; set; }
        public int? InitialCaseAssessmentDetailID { get; set; }
        public int? FinalCaseAssessmentDetailID { get; set; }
        public int? InitialAssessmentServiceID { get; set; }
        public int? FinalAssessmentServiceID { get; set; }
        public string UserFullName { get; set; }

        
       
    }
}
