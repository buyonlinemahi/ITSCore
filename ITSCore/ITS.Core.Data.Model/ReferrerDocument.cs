using System;
namespace ITS.Core.Data.Model
{

    public class ReferrerDocument
    {
        public int ReferrerDocumentID { get; set; }
        public int ReferrerID { get; set; }
        public string DocumentName { get; set; }
        public int DocumentTypeID { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserID { get; set; }
        public string UploadPath { get; set; }
        public int?  ReferrerProjectTreatmentID { get; set; }
        public int? ReferrerDocumentTypeID { get; set; }
        public int? CaseID { get; set; }
        public DateTime? DocumentDate { get; set; }
        public bool? SupplierCheck { get; set; }
        public bool? ReferrerCheck { get; set; }
    }
}
