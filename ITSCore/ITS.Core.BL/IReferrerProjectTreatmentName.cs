using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    
    public interface IReferrerProjectTreatmentName
    {
        IEnumerable<ReferrerProjectTreatmentName> GetReferrerProjectTreatmentNamesByReferrerProjectID(
            int referrerProjectID);
        IEnumerable<ReferrerProjectTreatmentName> GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID(
        int referrerProjectID);

    }
}
