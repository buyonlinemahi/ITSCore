using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{ 

    public class PatientImpactValueImpl : IPatientImpactValue
    {

        private readonly IPatientImpactValueRepository _patientImpactValueRepository;

        public PatientImpactValueImpl(IPatientImpactValueRepository patientImpactValueRepository)
        {
            _patientImpactValueRepository = patientImpactValueRepository;
        }

        public IEnumerable<Data.Model.PatientImpactValue> GetAllPatientImpactValues()
        {
            return _patientImpactValueRepository.GetAll();
        }
    }
}
