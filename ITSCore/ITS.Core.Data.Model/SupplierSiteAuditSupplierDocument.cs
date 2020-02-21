using System;

namespace ITS.Core.Data.Model
{
    public class SupplierSiteAuditSupplierDocument
    {
        public string Username { get; set; }
        public int DocumentTypeID { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentName { get; set; }
        public string UploadPath { get; set; }
        public int SupplierSiteAuditID { get; set; }
        public string AuditNotes { get; set; }
        public int SupplierID { get; set; }
        public Boolean AuditPass { get; set; }
        public int UserID { get; set; }
        public DateTime AuditDate { get; set; }
        public int SupplierDocumentID { get; set; }

    }
}
