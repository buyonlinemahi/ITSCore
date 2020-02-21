
namespace ITS.Core.Data.Model
{
    public class UKPostCode
    {
        public string PostCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Easting { get; set; }
        public int Northing { get; set; }
        public string GridRef { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string CountyCode { get; set; }
        public double RadiansLatitude { get; set; }
        public double RadiansLongitude { get; set; }
    }
}
