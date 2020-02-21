using System;

namespace ITS.Core.Data.Model
{
    public class SupplierClinicalAuditSupplierDocument
    {
        public int SupplierClinicalAuditID { get; set; }
        public int SupplierID { get; set; }
        public Boolean AuditPass { get; set; }
        public int UserID { get; set; }
        public DateTime AuditDate { get; set; }
        public int CaseID { get; set; }
        public int SupplierDocumentID { get; set; }
        public int DocumentTypeID { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentName { get; set; }
        public string UploadPath { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string CaseNumber { get; set; }
        public string Username { get; set; }
            

    }
}
