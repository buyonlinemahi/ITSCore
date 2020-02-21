
namespace ITS.Core.Data.Model
{
    public class DrugTest
    {
        public int DrugTestID { get; set; }
        public bool IsDrugAndAlcohalTest { get; set; }
        public int NetworkRailStandardApplicableID { get; set; }
        public int ReasonForReferralID { get; set; }
        public bool IsSentinalUpdating { get; set; }
        public string SentinalNumber { get; set; }
        public int AdditionalTestID { get; set; }
        public string AdditionalTestOther { get; set; }

    }
}
