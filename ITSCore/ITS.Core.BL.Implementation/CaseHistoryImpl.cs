
using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    using System.Collections.Generic;

    public class CaseHistoryImpl : ICaseHistory
    {
        private readonly ICaseHistoryRepository _repo;

        public CaseHistoryImpl(ICaseHistoryRepository repo)
        {
            _repo = repo;
        }

        public int AddCaseHistory(CaseHistory caseHistory)
        {
            return _repo.AddCaseHistory(caseHistory);
        }

        public IEnumerable<CaseHistory> GetCaseHistories()
        {
            return _repo.GetCaseHistories();
        }
        public IEnumerable<CaseHistoryUser> GetCaseHistoriesByCaseID(int caseID)
        {
            return _repo.GetCaseHistoriesByCaseID(caseID);
        }
    }
}
