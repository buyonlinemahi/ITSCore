using ITS.Core.Data.Model;

using System.Collections.Generic;

namespace ITS.Core.BL
{
    

    public interface ICaseHistory
    {
        int AddCaseHistory(CaseHistory caseHistory);
        IEnumerable<CaseHistory> GetCaseHistories();
        IEnumerable<CaseHistoryUser> GetCaseHistoriesByCaseID(int caseID);
    }
}
