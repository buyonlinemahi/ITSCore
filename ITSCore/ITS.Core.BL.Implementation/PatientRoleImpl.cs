using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.BL.Implementation
{

    public class PatientRoleImpl : IPatientRole
    {
       
        private readonly IPatientRoleRepository _patientRoleRepository;

        public PatientRoleImpl(IPatientRoleRepository patientRoleRepository)
        {
            _patientRoleRepository = patientRoleRepository;
        }


        public IEnumerable<PatientRole> GetAllPatientRole()
        {
            return _patientRoleRepository.GetAll();
        }

    }
}
