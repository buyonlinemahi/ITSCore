using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class PatientWorkstatusImpl : IPatientWorkstatus
    {

        private readonly IPatientWorkstatusRepository _patientWorkstatusRepository;

        public PatientWorkstatusImpl(IPatientWorkstatusRepository patientWorkstatusRepository)
        {
            _patientWorkstatusRepository = patientWorkstatusRepository;
        }

        public IEnumerable<Data.Model.PatientWorkstatus> GetAllPatientWorkstatus()
        {
            return _patientWorkstatusRepository.GetAll();
        }
    }
}