using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class TreatmentPeriodTypeImpl : ITreatmentPeriodType
    {
        private readonly ITreatmentPeriodTypeRepository _ITreatmentPeriodTypeRepository;

        public TreatmentPeriodTypeImpl(ITreatmentPeriodTypeRepository TreatmentPeriodTypeRepository)
        {
            _ITreatmentPeriodTypeRepository = TreatmentPeriodTypeRepository;
        }
        
        public IEnumerable<TreatmentPeriodType> GetTreatmentPeriodTypes()
        {
            return _ITreatmentPeriodTypeRepository.GetAll();
        }        
    }
}
