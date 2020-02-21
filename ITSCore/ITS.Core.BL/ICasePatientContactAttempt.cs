using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ICasePatientContactAttempt
    {
        int AddPatientContactAttempt(CasePatientContactAttempt casePatientContactAttempt);
        IEnumerable<CasePatientContactAttempt> GetPatientContactAttemptsByCaseID(int caseID);
        int DeletePatientContactAttempt(int CasePatientContactAttemptID);
    }
}
