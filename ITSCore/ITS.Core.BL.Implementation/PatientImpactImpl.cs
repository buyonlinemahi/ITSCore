using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class PatientImpactImpl : IPatientImpact
    {

        private readonly IPatientImpactRepository _patientImpactRepository;

        public PatientImpactImpl(IPatientImpactRepository patientImpactRepository)
        {
            _patientImpactRepository = patientImpactRepository;
        }


        public IEnumerable<Data.Model.PatientImpact> GetAllPatientImpacts()
        {
            return _patientImpactRepository.GetAll();
        }
    }
}