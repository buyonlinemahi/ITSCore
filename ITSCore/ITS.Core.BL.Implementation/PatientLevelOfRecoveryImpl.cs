using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{

    public class PatientLevelOfRecoveryImpl : IPatientLevelOfRecovery
    {
        private readonly IPatientLevelOfRecoveryRepository _patientLevelOfRecoveryRepository;

        public PatientLevelOfRecoveryImpl(IPatientLevelOfRecoveryRepository patientLevelOfRecoveryRepository)
        {
            _patientLevelOfRecoveryRepository = patientLevelOfRecoveryRepository;
        }

        public IEnumerable<PatientLevelOfRecovery> GetAllPatientLevelOfRecovery()
        {
            return _patientLevelOfRecoveryRepository.GetAll();
        }
    }
}
