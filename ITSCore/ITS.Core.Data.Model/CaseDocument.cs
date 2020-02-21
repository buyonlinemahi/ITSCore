using System;

namespace ITS.Core.Data.Model
{
    public class CaseDocument
    {
        public int CaseDocumentID { get; set; }
        public int CaseID { get; set; }
        public int DocumentTypeID { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentName { get; set; }
        public string UploadPath { get; set; }
        public int? UserID { get; set; }
        public bool? SupplierCheck { get; set; }
        public bool? ReferrerCheck { get; set; }
    }
}
