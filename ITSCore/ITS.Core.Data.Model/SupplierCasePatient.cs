using System;

namespace ITS.Core.Data.Model
{
    public class SupplierCasePatient
    {
        public int CaseID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CaseNumber { get; set; }
        public int WorkflowID { get; set; }
        public string WorkflowName { get; set; }
        public DateTime InitialAssessmentDate { get; set; }
        
    }
}
