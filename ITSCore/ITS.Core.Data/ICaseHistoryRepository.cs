using global::Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseHistoryRepository : IBaseRepository<CaseHistory>
    {
        int AddCaseHistory(CaseHistory caseHistory);
        int UpdateCaseHistory(CaseHistory caseHistory);
        IEnumerable<CaseHistory> GetCaseHistories();
        IEnumerable<CaseHistoryUser> GetCaseHistoriesByCaseID(int caseID);
    }
}
