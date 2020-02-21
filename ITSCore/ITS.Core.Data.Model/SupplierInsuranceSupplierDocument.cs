using System;

namespace ITS.Core.Data.Model
{
    public class SupplierInsuranceSupplierDocument
    {
        public int DocumentTypeID { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentName { get; set; }
        public string UploadPath { get; set; }
        public string Username { get; set; }
        public int UserID { get; set; }
        public int SupplierInsuredID { get; set; }
        public string LevelOfCover { get; set; }
        public DateTime RenewalDate { get; set; }
        public int SupplierDocumentID { get; set; }
        public int SupplierID { get; set; }

    }
}
