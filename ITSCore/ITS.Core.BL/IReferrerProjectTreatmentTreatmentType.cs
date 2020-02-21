using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface IReferrerProjectTreatmentTreatmentType
    {
        IEnumerable<ReferrerProjectTreatmentTreatmentType> GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID(int referrerProjectTreatmentID);
    }
}
