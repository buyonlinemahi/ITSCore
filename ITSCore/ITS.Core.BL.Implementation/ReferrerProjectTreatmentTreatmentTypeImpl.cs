using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentTreatmentTypeImpl : IReferrerProjectTreatmentTreatmentType
    {
        private readonly IReferrerProjectTreatmentTreatmentTypeRepository _referrerProjectTreatmentTreatmentTypeRepository;

        public ReferrerProjectTreatmentTreatmentTypeImpl(IReferrerProjectTreatmentTreatmentTypeRepository referrerProjectTreatmentTreatmentTypeRepository)
        {
            _referrerProjectTreatmentTreatmentTypeRepository = referrerProjectTreatmentTreatmentTypeRepository;
        }

        public IEnumerable<ReferrerProjectTreatmentTreatmentType> GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentTreatmentTypeRepository.GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID(
                referrerProjectTreatmentID);
        }
    }
}
