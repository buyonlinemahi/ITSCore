using System.Collections.Generic;
using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{

    public interface IReferrerProjectTreatmentNameRepository
    {
        IEnumerable<ReferrerProjectTreatmentName> GetReferrerProjectTreatmentNamesByReferrerProjectID(
            int referrerProjectID);
        IEnumerable<ReferrerProjectTreatmentName> GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID(
           int referrerProjectID);

    }
}
