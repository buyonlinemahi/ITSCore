using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICasePatientContactAttemptRepository : IBaseRepository<CasePatientContactAttempt>
    {
        int AddPatientContactAttempt(CasePatientContactAttempt casePatientContactAttempt);
        IEnumerable<CasePatientContactAttempt> GetPatientContactAttemptsByCaseID(int caseID);
        int DeletePatientContactAttemptByID(int CasePatientContactAttemptID);
    }
}
