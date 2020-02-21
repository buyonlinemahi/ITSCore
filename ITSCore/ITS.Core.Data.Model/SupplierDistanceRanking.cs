
namespace ITS.Core.Data.Model
{
    public class SupplierDistanceRanking
    {
        public int SupplierID { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Distance { get; set; }
        public string SupplierName { get; set; }
    }
}
