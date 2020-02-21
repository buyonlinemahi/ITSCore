﻿using System;

#region Comment
/*
 Page Name:  Case.cs                      
 Latest Version:  1.0
 Author : Robin
 Description: Created Case model class                                             
===================================================================================

*/
#endregion
namespace ITS.Core.Data.Model
{
    public class Case
    {
        public int CaseID { get; set; }
        public int PatientID { get; set; }
        public int ReferrerID { get; set; }
        public int ReferrerProjectID { get; set; }
        public string CaseNumber { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public int TreatmentTypeID { get; set; }
        public string CaseReferrerReferenceNumber { get; set; }
        public string CaseSpecialInstruction { get; set; }
        public DateTime? CaseReferrerDueDate { get; set; }
        public DateTime? CaseSubmittedDate { get; set; }
        public int? SupplierID { get; set; }
        public int WorkflowID { get; set; }
        public DateTime? PatientContactDate { get; set; }
        public bool IsTreatmentRequired { get; set; }
        public bool IsTriage { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InjuryType { get; set; }
        public bool IsCustom { get; set; }
        public string SendInvoiceTo { get; set; }
        public string SendInvoiceName { get; set; }
        public string SendInvoiceEmail { get; set; }
        public int? ReferrerAssignedUser { get; set; }
        public int? SupplierAssignedUser { get; set; }
        public string InnovateNote { get; set; }
        public int? OfficeLocationID { get; set; }
        public int? EmployeeDetailID { get; set; }
        public int? DrugTestID { get; set; }
        public int? JobDemandID { get; set; }
        public int? IsNewPolicyTypeID { get; set; }
        public string NewPolicyReferenceNumber { get; set; }
    }
}
