namespace ITS.Core.Data.Model
{

    public class ReferrerProjectTreatmentTreatmentCategory
    {
        public int ReferrerProjectTreatmentID { get; set; }
        public int ReferrerProjectID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public int? AccountReceivableChasingPoint { get; set; }
        public int? AccountReceivableCollection { get; set; }
        public bool Enabled { get; set; }
        public string TreatmentCategoryName { get; set; }
    }
}
