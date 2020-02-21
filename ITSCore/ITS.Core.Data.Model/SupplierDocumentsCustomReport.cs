using System;
namespace ITS.Core.Data.Model
{
   public class SupplierDocumentCustomReport
    {
        public int SupplierDocumentID { get; set; }
        public int DocumentTypeID { get; set; }
        public int SupplierID { get; set; }
        public int UserID { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentName { get; set; }
        public string UploadPath { get; set; }
        public int? ReferrerProjectTreatmentID { get; set; }
        public int? CaseId { get; set; }
        public string Username { get; set; }
        public string Documentfullname { get; set; }
    }
}
