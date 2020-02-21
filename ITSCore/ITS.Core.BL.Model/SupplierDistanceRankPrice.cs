using System.Collections.Generic;

namespace ITS.Core.BL.Model
{
    public class SupplierDistanceRankPrice
    {
        public int SupplierID { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SupplierName { get; set; }
        public double Ranking { get; set; }
        public IEnumerable<PriceAverage> PriceAverages { get; set; }
        public double Distance { get; set; }
    }
}
