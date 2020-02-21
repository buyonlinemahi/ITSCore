
#region Comment
/*
 Page Name:  CasePatientTreatmentWorkflow.cs                      
 Latest Version:  1.0
 Author : Robin Singh
 Description: Created CasePatientTreatmentWorkflow model class                                             
===================================================================================

*/
#endregion
namespace ITS.Core.Data.Model
{
    public class CasePatientTreatmentWorkflow 
    {

        public int CaseID { get; set; }
        public string TreatmentTypeName { get; set; }
        public int? TreatmentTypeID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string TreatmentCategoryName { get; set; }
        public string Definition { get; set; }
        public int WorkflowID { get; set; }
        public string CaseReferrerReferenceNumber { get; set; }
        public string CaseNumber { get; set; }
        public string PostCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PatientID { get; set; }
        public string ReferrerName { get; set; }


    }
}
