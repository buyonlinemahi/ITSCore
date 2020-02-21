using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentNameImpl : IReferrerProjectTreatmentName
    {
        private readonly IReferrerProjectTreatmentNameRepository _repository;

        public ReferrerProjectTreatmentNameImpl(IReferrerProjectTreatmentNameRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ReferrerProjectTreatmentName> GetReferrerProjectTreatmentNamesByReferrerProjectID(int referrerProjectID)
        {
            return _repository.GetReferrerProjectTreatmentNamesByReferrerProjectID(referrerProjectID);
        }


        public IEnumerable<ReferrerProjectTreatmentName> GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID(int referrerProjectID)
        {
            return _repository.GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID(referrerProjectID);
        }
    }
}
