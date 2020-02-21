using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{

    public class PatientImpactOnWorkImpl : IPatientImpactOnWork
    {
        private readonly IPatientImpactOnWorkRepository _patientImpactOnWorkRepository;

        public PatientImpactOnWorkImpl(IPatientImpactOnWorkRepository patientImpactOnWorkRepository)
        {
            _patientImpactOnWorkRepository = patientImpactOnWorkRepository;
        }


        public IEnumerable<PatientImpactOnWork> GetAllPatientImpactOnWork()
        {
            return _patientImpactOnWorkRepository.GetAll();
        }
    }
}
