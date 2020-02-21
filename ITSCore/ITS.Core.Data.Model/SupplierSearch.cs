using System;

namespace ITS.Core.Data.Model
{
    public class SupplierSearch
    {
        public string SupplierName { get; set; }
        public int SupplierID { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime DateAdded { get; set; }
        public string TreatmentCategoryName { get; set; }
    }
}
