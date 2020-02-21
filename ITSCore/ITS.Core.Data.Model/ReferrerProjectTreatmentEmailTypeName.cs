using System.Collections.Generic;

namespace ITS.Core.Data.Model
{
    public class ReferrerProjectTreatmentEmailTypeName
    {
        public int ReferrerProjectTreatmentEmailID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public int EmailTypeID { get; set; }
        public int EmailTypeValueID { get; set; }
        public string EmailTypeName { get; set; }
        public int UserTypeID { get; set; }
        public IEnumerable<EmailTypeValue> EmailTypeValues { get; set; }
    }
}
