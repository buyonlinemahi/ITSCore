using System;


namespace ITS.Core.Data.Model
{
    public class SupplierComplaintAndStatusAndType
    {
        public int SupplierComplaintID { get; set; }
        public int ComplaintTypeID { get; set; }
        public int ComplaintStatusID { get; set; }
        public string ComplaintDescription { get; set; }
        public DateTime ComplaintDate { get; set; }
        public int SupplierID { get; set; }
        public string ComplaintTypeName { get; set; }
        public string ComplaintStatusName { get; set; }
    }
}
