using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class CasePatientContactAttemptImpl : ICasePatientContactAttempt
    {
        private readonly ICasePatientContactAttemptRepository _CasePatientContactAttemptRepository;


        public CasePatientContactAttemptImpl(ICasePatientContactAttemptRepository CasePatientContactAttemptRepository)
        {
            _CasePatientContactAttemptRepository = CasePatientContactAttemptRepository;
        }

        public int AddPatientContactAttempt(Data.Model.CasePatientContactAttempt casePatientContactAttempt)
        {

            return _CasePatientContactAttemptRepository.AddPatientContactAttempt(casePatientContactAttempt);
        }

        public IEnumerable<Data.Model.CasePatientContactAttempt> GetPatientContactAttemptsByCaseID(int caseID)
        {
            return _CasePatientContactAttemptRepository.GetPatientContactAttemptsByCaseID(caseID);
        }

        public int DeletePatientContactAttempt(int CasePatientContactAttemptID)
        {
            return _CasePatientContactAttemptRepository.DeletePatientContactAttemptByID(CasePatientContactAttemptID);
        }
    }
}
