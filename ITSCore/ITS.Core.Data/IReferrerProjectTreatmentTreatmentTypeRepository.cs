using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentTreatmentTypeRepository
    {
        IEnumerable<ReferrerProjectTreatmentTreatmentType> GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID(int referrerProjectTreatmentID);
    }
}
